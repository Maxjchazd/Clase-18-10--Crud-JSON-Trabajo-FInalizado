using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CapaDeNegocio.Clases;
using CapaDeNegocio.Datos;
using Crud;
using Newtonsoft.Json;





public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["accion"] == null) return;

        switch (Request["accion"])
        {
                  /*sección usuarios*/

            case "ADDUSUARIO": AddUsuario(); break;
            case "LISTUSUARIOS": ListUsuarios(); break;
            case "MOSTRARUSUARIOS": ListUsers(); break;

            case "DELETEUSER": DeleteUser(); break;
            case "MODIFYUSER": ModifyUser(); break;
            case "BUSCARUSUARIOS": findUser(); break;

                /*sección carreras*/

            case "ADDCARRERAS": AddCarrera(); break;
            case "LISTCARRERAS": ListCarrera(); break;
            case "MOSTRARCARRERAS": ListCarers(); break;


            case "DELETECARRERA": DeleteCarrera(); break;
            case "MODIFYCARRERA": ModifyCarrera(); break;
            case "FINDCARRERA": FindCarrera(); break;

            /*sección registro y login*/

            case "ADDREGISTRO": AddRegistro(); break;
            case "LOGIN": Login(); break;
            case "LISTREGISTROS": ListRegistros(); break;



            case "BUSCARREGISTRO": FindRegistro(); break;
            case "DELETEREGISTRO": DeleteReg(); break;
            case "MODIFYREGISTRO": ModifyReg(); break;


        }
    }

    private void AddUsuario()
    {
        Usuario u = new Usuario();

        if (!int.TryParse(Request["Dni"], out int dni) || dni <= 0 || dni > int.MaxValue)
        {
            Response.Write("Ingrese DNI válido");
            return;
        }

        u.Dni = dni;

        Regex regex = new Regex(@"\d"); // Detecta cualquier dígito del 0 al 9

        u.Nombre = Request["Nombre"];

        if (regex.IsMatch(u.Nombre))
        {
            Response.Write("El nombre no debe contener números.");
            return;
        }

        u.Mail = Request["Mail"];

        try
        {
            u.Add();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Console.WriteLine(er.Message);
        }
    }

    private void ListUsuarios()
    {
        Usuario u = new Usuario();
        string lista = u.List();
        Response.Write(lista);

    }
    private void ListUsers()
    {
        Usuario u = new Usuario();
        string lista = u.List();
        Response.Write(lista);

    }


    private void DeleteUser()
    {
        Usuario u = new Usuario();
        u.ID = int.Parse(Request["id"]);
        Console.WriteLine(u.ID);

        try
        {
            u.Erase();
            Response.Write("OK");

        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void ModifyUser()
    {
        Usuario U = new Usuario();

        if (!int.TryParse(Request["Dni"], out int dni) || dni <= 0 || dni > int.MaxValue)
        {
            Response.Write("Ingrese DNI válido");
            return;
        }


        Regex regex = new Regex(@"\d"); // Detecta cualquier dígito del 0 al 9
        U.ID = int.Parse(Request["ID"]);
        U.Mail = Request["Mail"];
        U.Dni = int.Parse(Request["Dni"]);
        U.Nombre = Request["Nombre"];

        try
        {
            U.Modify();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void findUser()
    {
        Usuario u = new Usuario();

        // Validación de parámetros de búsqueda
        if (!int.TryParse(Request["ID"], out int id) || id < 0)
        {
            Response.Write("Ingrese un ID válido");
            return;
        }

        if (!int.TryParse(Request["Dni"], out int dni) || dni <= 0)
        {
            Response.Write("Ingrese un DNI válido");
            return;
        }

        u.ID = id;
        u.Dni = dni;
        u.Nombre = Request["Nombre"];

        try
        {
            // Llamamos al método Find que devuelve una lista de usuarios
            Datos datos = new Datos();
            List<Usuario> encontrados = datos.Find(u);  // Obtener lista de usuarios encontrados

            // Verificar si la lista tiene resultados
            if (encontrados != null && encontrados.Count > 0)
            {
                string json = JsonConvert.SerializeObject(encontrados); // Serializamos la lista de usuarios
                Response.ContentType = "application/json"; // Indicamos que la respuesta es de tipo JSON
                Response.Write(json); // Enviar el resultado al cliente
            }
            else
            {
                Response.Write("No se encontraron usuarios.");
            }
        }
        catch (Exception er)
        {
            // Capturar errores y mostrar el mensaje
            Response.Write("Error: " + er.Message);
        }
    }



    //sección carreras
    /*******************************************************************/
    //sección carreras

    private void AddCarrera() {

        Carrera c = new Carrera();

        if (!int.TryParse(Request["Código"], out int código) || código <= 0 || código > int.MaxValue)
        {
            Response.Write("Ingrese Código válido");
            return;
        }

        c.Código = código;

        Regex regex = new Regex(@"\d"); // Detecta cualquier dígito del 0 al 9

        c.Nombre = Request["Nombre"];



        if (regex.IsMatch(c.Nombre))
        {
            Response.Write("El nombre no debe contener números.");
            return;
        }

        c.Cátedra = Request["Cátedra"]; 

        if (regex.IsMatch(c.Cátedra))

        {
            Response.Write("La cátedra no debe contener números.");
            return;
        }

    
        c.Mail = Request["Mail"];

        try
        {
            c.Add();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Console.WriteLine(er.Message);
        }
    }



    private void ModifyCarrera() {

        Carrera c = new Carrera();

        if (!int.TryParse(Request["Código"], out int código) || código <= 0 || código > int.MaxValue)
        {
            Response.Write("Ingrese código válido");
            return;
        }


        Regex regex = new Regex(@"\d"); // Detecta cualquier dígito del 0 al 9
        c.ID = int.Parse(Request["ID"]);
        c.Mail = Request["Mail"];
        c.Código = int.Parse(Request["Código"]);
        c.Cátedra = Request["Cátedra"];
        c.Nombre = Request["Nombre"];

        try
        {
            c.Modify();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void DeleteCarrera() {
        Carrera c = new Carrera();
        c.ID = int.Parse(Request["id"]);
        Console.WriteLine(c.ID);

        try
        {
            c.Erase();
            Response.Write("OK");

        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void ListCarrera() {
        Carrera c = new Carrera();
        string listaC = c.List();
        Response.Write(listaC);
    }
    private void ListCarers()
    {
        Carrera c = new Carrera();
        string listaC = c.List();
        Response.Write(listaC);
    }


    private void FindCarrera() {
        Carrera c = new Carrera();

        // Validación de parámetros de búsqueda
        if (!int.TryParse(Request["ID"], out int id) || id < 0)
        {
            Response.Write("Ingrese un ID válido");
            return;
        }

        if (!int.TryParse(Request["Código"], out int código) || código <= 0)
        {
            Response.Write("Ingrese un código válido");
            return;
        }

        c.ID = id;
        c.Código = código;
        c.Nombre = Request["Nombre"];
        c.Cátedra = Request["Cátedra"];


        try
        {
            // Llamamos al método Find que devuelve una lista de carreras
            DatosCarrera datos = new DatosCarrera();

            List<Carrera> encontradas = datos.Find(c);  // Obtener lista de carreras encontradas

            // Verificar si la lista tiene resultados
            if (encontradas != null && encontradas.Count > 0)
            {
                string json = JsonConvert.SerializeObject(encontradas); // Serializamos la lista de carreras
                Response.ContentType = "application/json"; // Indicamos que la respuesta es de tipo JSON
                Response.Write(json); // Enviar el resultado al cliente
            }
            else
            {
                Response.Write("No se encontraron carreras.");
            }
        }
        catch (Exception er)
        {
            // Capturar errores y mostrar el mensaje
            Response.Write("Error: " + er.Message);
        }
    }



    //sección registros y logins
    /*******************************************************************/
    //sección registros y logins

    private void AddRegistro()
    {
        Registro r = new Registro();

        if (!int.TryParse(Request["DNI"], out int dni) || dni <= 0 || dni > int.MaxValue)
        {
            Response.Write("Ingrese DNI válido");
            return;
        }

        r.Dni = dni;

  
        if (!int.TryParse(Request["Célular"], out int celular) || celular <= 0 || celular > int.MaxValue)
        {

            Response.Write("Ingrese celular válido");
            return; 
        }

        r.Célular = celular;
        
        Regex regex = new Regex(@"\d"); // Detecta cualquier dígito del 0 al 9

        r.Nombre = Request["Nombre"];

        if (regex.IsMatch(r.Nombre))
        {
            Response.Write("El nombre no debe contener números.");
            return;
        }

        r.Mail = Request["Mail"];
        r.Contraseña = Request["Contraseña"];
        r.Apellido = Request["Apellido"];
        r.Contraseña = Request["Contraseña"];
        r.Correo_Postal = Request["Correo Postal"];
        r.Direccion_Física = Request["Domicilio"];


        try
        {
            r.Add();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Console.WriteLine(er.Message);
        }
    }

    private void ListRegistros()
    {
        Registro r = new Registro();
        string lista = r.List();
        Response.Write(lista);

    }
    private void Login()
    {
        Registro r = new Registro();
        r.Nombre = Request["Nombre"];
        r.Contraseña = Request["Contraseña"];
        try
        {
            r.Login(r); // Pass the current instance of 'Registro' as the required parameter
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }


    private void FindRegistro()
    {
        Registro r = new Registro();
        // Validación de parámetros de búsqueda
        if (!int.TryParse(Request["ID"], out int id) || id < 0)
        {
            Response.Write("Ingrese un ID válido");
            return;
        }
        if (!int.TryParse(Request["Dni"], out int dni) || dni <= 0)
        {
            Response.Write("Ingrese un DNI válido");
            return;
        }
        r.ID = id;
        r.Dni = dni;
        r.Nombre = Request["Nombre"];

        try
        {
            // Llamamos al método Find que devuelve una lista de registros
            DatosRegistro datos = new DatosRegistro();
            List<Registro> encontrados = datos.Find(r);  // Obtener lista de registros encontrados
            // Verificar si la lista tiene resultados
            if (encontrados != null && encontrados.Count > 0)
            {
                string json = JsonConvert.SerializeObject(encontrados); // Serializamos la lista de registros
                Response.ContentType = "application/json"; // Indicamos que la respuesta es de tipo JSON
                Response.Write(json); // Enviar el resultado al cliente
            }
            else
            {
                Response.Write("No se encontraron registros.");
            }
        }
        catch (Exception er)
        {
            // Capturar errores y mostrar el mensaje
            Response.Write("Error: " + er.Message);
        }
    }

    private void DeleteReg()
    {
        Registro r = new Registro();
        r.ID = int.Parse(Request["id"]);
        Console.WriteLine(r.ID);

        try
        {
            r.Erase();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void ModifyReg() {

        Registro r = new Registro();

        if (!int.TryParse(Request["Dni"], out int dni) || dni <= 0 || dni > int.MaxValue)
        {
            Response.Write("Ingrese DNI válido");
            return;
        }

        if (!int.TryParse(Request["Célular"], out int celular) || celular <= 0 || celular > int.MaxValue)
        {
            Response.Write("Ingrese célular válido");
            return;
        }

        r.Célular = celular;

        Regex regex = new Regex(@"\d"); // Detecta cualquier dígito del 0 al 9

        r.ID = int.Parse(Request["ID"]);
        r.Mail = Request["Mail"];
        r.Nombre = Request["Nombre"];
        r.Dni = int.Parse(Request["Dni"]);
        r.Contraseña = Request["Contraseña"];
        r.Célular = int.Parse(Request["Célular"]);
        r.Correo_Postal = Request["Correo Postal"];
        r.Direccion_Física = Request["Domicilio"];

        try
        {
            r.Modify();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

}

