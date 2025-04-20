using CapaDeNegocio.Clases;
using Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio.Interfaces
{
    internal interface ICarrera
    {

            string Nombre { get; set; }
            int Código { get; set; }
            string Mail { get; set; }
        string Cátedra { get; set; }


        bool CódigoExist(int dni);
            bool MailExist(string mail);
            Carrera FindMail(string mail);
            Carrera FindCódigo(int dni);

            string List();
        
    }
}
