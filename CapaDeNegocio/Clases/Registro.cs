using CapaDeNegocio.Interfaces;
using Crud;
using Microsoft.Azure.Amqp.Framing;
using System;

namespace CapaDeNegocio.Clases
{


    public class Registro : IABMC<Registro>, IID, IRegistro<Registro>
    {

        private static DatosRegistro datos = new DatosRegistro();

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }
        public int Célular { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Correo_Postal { get; set; }
        public string Direccion_Física { get; set; }


        /* "ID","Nombre", "Apellido", "DNI", "Mail", "Contraseña", "Telefono", "Célular","Fecha ingreso", "Correo Postal", "Dirección física" */

        public void Add()
        {
            datos.Add(this);
        }
        public void Modify()
        {
            datos.Modify(this);
        }


        public void Erase()
        {
            datos.Erase(this);
        }

        public Registro Find(int iD)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public string List()
        {
            return datos.ListaRegistro();
        }

        public bool Exist(Registro registro)
        {
            throw new NotImplementedException();
        }

        public bool NombreExist(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool ApellidoExist(string apellido)
        {
            throw new NotImplementedException();
        }

        public bool TelefonoExist(string telefono)
        {
            throw new NotImplementedException();
        }

        public bool DniExist(int dni)
        {
            throw new NotImplementedException();
        }

        public bool MailExist(string mail)
        {
            throw new NotImplementedException();
        }

        public bool ContraseñaExist(string contraseña)
        {
            throw new NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool CorreoExist(string correo)
        {
            throw new NotImplementedException();
        }

        public bool DireccionExist(string direccion)
        {
            throw new NotImplementedException();
        }

        public bool FechaRegistroExist(DateTime fechaRegistro)
        {
            throw new NotImplementedException();
        }

        public Registro Find(Registro registro)
        {
            throw new NotImplementedException();
        }

        public Registro FindId(int id)
        {
            throw new NotImplementedException();
        }

        public Registro FindContraseña(string contraseña)
        {
            throw new NotImplementedException();
        }

        public Registro FindTelefono(string telefono)
        {
            throw new NotImplementedException();
        }

        public Registro FindApellido(string apellido)
        {
            throw new NotImplementedException();
        }

        public Registro FindNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Registro FindDireccion(string direccion)
        {
            throw new NotImplementedException();
        }

        public Registro FindFechaRegistro(DateTime fechaRegistro)
        {
            throw new NotImplementedException();
        }

        public Registro FindCorreo(string correo)
        {
            throw new NotImplementedException();
        }

        public void Add(Registro registro)
        {
            throw new NotImplementedException();
        }

        public void Erase(Registro registro)
        {
            throw new NotImplementedException();
        }



        public void Login(Registro registro)
        {
            datos.Login(registro);
        }


    }
}
