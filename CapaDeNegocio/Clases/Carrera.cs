using CapaDeNegocio.Datos;
using CapaDeNegocio.Interfaces;
using Crud;
using System;


namespace CapaDeNegocio.Clases
{
    public class Carrera : IABMC<Carrera>, ICarrera

    {

        private static DatosCarrera datos = new DatosCarrera();


        #region IID
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Código { get; set; }
        public string Cátedra { get; set; }

        public string Mail { get; set; }


        #endregion

        public void Add()
        {
            datos.Add(this);
        }

        public bool CódigoExist(int dni)
        {
            throw new NotImplementedException();
        }

        public void Erase()
        {
            datos.Erase(this);
        }

        public Carrera Find(int iD)
        {
            datos.Find(this);
            return this;
        }

        public Carrera FindCódigo(int dni)
        {
            throw new NotImplementedException();
        }

        public Carrera FindMail(string mail)
        {
            throw new NotImplementedException();
        }

        public string List()
        {
            return datos.List();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public bool MailExist(string mail)
        {
            throw new NotImplementedException();
        }

        public void Modify()
        {
            datos.Modify(this);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    } }