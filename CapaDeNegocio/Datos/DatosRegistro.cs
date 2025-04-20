using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using CapaDeNegocio.Clases;
using System.Linq;



namespace Crud
{
    public class DatosRegistro : IAccesoADatos<Registro>
    {
        public static List<Registro> listaRegistros;

        private static int lastId;


        private static void Read()
        {

            try
            {

                string path = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\registros.json";
                string json = File.ReadAllText(path);
                listaRegistros = JsonSerializer.Deserialize<List<Registro>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write()
        {

            try
            {
                string path = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\registros.json";
                string json = JsonSerializer.Serialize(listaRegistros);
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Limpiar()
        {
            listaRegistros.Clear();
        }


        public void Add(Registro data)
        {
            Read();
            string pathID = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\registrosLastId.txt";

            lastId = int.Parse(File.ReadAllText(pathID));

            data.ID = ++lastId;

            File.WriteAllText(pathID, lastId.ToString()); // guarda el ultimo ID en el archivo de texto
            listaRegistros.Add(data);


            Write();
            Limpiar();




        }

        public void Erase(Registro data)
        {
            Read(); // Cargar los datos antes de modificar la lista

            // Buscar el índice del usuario por su ID
            int indexToRemove = -1;
            for (int i = 0; i < listaRegistros.Count; i++)
            {
                if (listaRegistros[i].ID == data.ID)
                {
                    indexToRemove = i;
                    break; // Salir del ciclo cuando encontramos el usuario
                }
            }

            if (indexToRemove != -1)
            {
                listaRegistros.RemoveAt(indexToRemove); // Eliminar el usuario por índice

                Write(); // Guardar cambios en la base de datos o archivo

                Console.WriteLine("Usuario eliminado con éxito");
                Console.WriteLine(listaRegistros); // Mostrar la lista actualizada

                return; // Salir del método después de eliminar el usuario
            }

            throw new Exception("No se encontró el usuario a eliminar");
        }







        public List<Registro> Find(Registro data)
        {
            Read(); // Cargar listaUsuarios
            List<Registro> resultados = new List<Registro>();

            foreach (Registro r in listaRegistros)
            {
                bool coincide = false;

                if (data.ID != 0 && data.ID == r.ID)
                    coincide = true;

                if (!string.IsNullOrEmpty(data.Nombre) && r.Nombre.IndexOf(data.Nombre, StringComparison.OrdinalIgnoreCase) >= 0)
                    coincide = true;

                if (data.Dni != 0 && data.Dni == r.Dni)
                    coincide = true;

                if (!string.IsNullOrEmpty(data.Mail) && r.Mail.IndexOf(data.Mail, StringComparison.OrdinalIgnoreCase) >= 0)
                    coincide = true;

                if (coincide)
                    resultados.Add(r);
            }

            return resultados;
        }



        public void Modify(Registro data)
        {
            Read();
            for (int i = 0; i < listaRegistros.Count; i++)
            {
                if (listaRegistros[i].ID == data.ID)
                {
                    listaRegistros[i].Nombre = data.Nombre;
                    listaRegistros[i].Dni = data.Dni;
                    listaRegistros[i].Mail = data.Mail;
                    listaRegistros[i].Apellido = data.Apellido;
                    listaRegistros[i].Célular = data.Célular;
                    listaRegistros[i].Contraseña = data.Contraseña;
                    listaRegistros[i].FechaRegistro = data.FechaRegistro;
                    listaRegistros[i].Correo_Postal = data.Correo_Postal;
                    listaRegistros[i].Direccion_Física = data.Direccion_Física;




                    Write();
                    Limpiar();
                    return;

                }
            }
            throw new Exception("No se puede modificar el Usuario: no se encuentra en la lista");


        }

        public string ListaRegistro()
        {
            Read();
            string json = JsonSerializer.Serialize(listaRegistros);
            return json;
            throw new Exception("No hay lista para mostrar");

        }
    


        public void Login(Registro data)
        {
            Read(); // Carga los registros guardados

            if (listaRegistros == null || !listaRegistros.Any())
            {
                throw new Exception("No hay registros disponibles para iniciar sesión.");
            }

            foreach (var r in listaRegistros)
            {
                if (string.Equals(r.Mail?.Trim(), data.Mail?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(r.Contraseña?.Trim(), data.Contraseña?.Trim(), StringComparison.Ordinal))
                {
                    Console.WriteLine("Login exitoso");
                    return;
                }
            }

            throw new Exception("Usuario o contraseña incorrectos");
        }
    }
}