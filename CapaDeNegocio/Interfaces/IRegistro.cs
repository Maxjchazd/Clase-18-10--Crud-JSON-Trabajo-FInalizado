using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Interfaces
{
    internal interface IRegistro<Registro>
    {

        string Nombre { get; set; }
        string Apellido { get; set; }
        int Dni { get; set; }
        string Mail { get; set; }
        string Contraseña { get; set; }
        int Célular { get; set; }
        DateTime FechaRegistro { get; set; }
        string Correo_Postal { get; set; }
        string Direccion_Física { get; set; }




        void Add(Registro registro);
        void Erase(Registro registro);

        void Update();
        
        

        string List();
        bool Exist(Registro registro);
        bool NombreExist(string nombre);
        bool ApellidoExist(string apellido);

        bool DniExist(int dni);
        bool MailExist(string mail);
        bool ContraseñaExist(string contraseña);
        bool IdExist(int id);
        bool CorreoExist(string correo);

        bool DireccionExist(string direccion);
        bool FechaRegistroExist(DateTime fechaRegistro);

        Registro Find(Registro registro);
        Registro FindId(int id);
        Registro FindContraseña(string contraseña);
        Registro FindTelefono(string telefono);
        Registro FindApellido(string apellido);
        Registro FindNombre(string nombre);
        Registro FindDireccion(string direccion);
        Registro FindFechaRegistro(DateTime fechaRegistro);
        Registro FindCorreo(string correo);





    }
}
