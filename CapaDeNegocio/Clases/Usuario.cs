using System;




namespace Crud
{
    public class Usuario : IABMC<Usuario>, IUsuario
    {
        private static Datos datos =new Datos();
        /* comprenderlo bien */

        #region IID
        public int ID { get ; set ; }

        #endregion

        #region IUsuario
        public string Nombre { get ; set ; }
        public int Dni { get; set; }
        public string Mail { get; set; }

        public bool DniExist(int dni)
        {
         
            return false;
            
        }
        public bool MailExist(string mail)
        {
            return false;

        }
        //-------------realizar los alumnos
        public Usuario FindDni(int dni)
        {
            throw new NotImplementedException();
        }

        public Usuario FindMail(string mail)
        {
            throw new NotImplementedException();
        }
        //---------------------------------

        public string List()
        {

            return datos.List();
        }


        #endregion

        #region IABMC
        public void Add()
        {
            datos.Add(this);
        }
        public void Erase()
        {
            datos.Erase(this);
        }

        public Usuario Find(int iD)
        {
          datos.Find(this);
            return this;



        }
        
        public void Modify()
        {

            datos.Modify(this);
            
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
