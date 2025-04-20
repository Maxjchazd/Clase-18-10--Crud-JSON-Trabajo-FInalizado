using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace Crud
{
    public class Datos : IAccesoADatos<Usuario>
    {
        public static List<Usuario> listaUsuarios;

        private static int lastId;


        private static void Read()
        {

            try {
                
                string path = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\usuarios.json";
                string json= File.ReadAllText(path);    
                listaUsuarios= JsonSerializer.Deserialize <List<Usuario>>(json);
            }
            catch  (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write()
        {

            try
            {
                string path= "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\usuarios.json";
                string json=JsonSerializer.Serialize(listaUsuarios);
                File.WriteAllText(path, json);
                                            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Limpiar()
        {
            listaUsuarios.Clear();
        }


        public void Add(Usuario data)
        {
            Read();
            string pathID = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\usuarioLastId.txt";

            lastId = int.Parse(File.ReadAllText(pathID));

            data.ID=++lastId;

            File.WriteAllText(pathID, lastId.ToString()); // guarda el ultimo ID en el archivo de texto
            listaUsuarios.Add(data);


            Write();
            Limpiar();

        
        
        
        }

        public void Erase(Usuario data)
        {
            Read(); // Cargar los datos antes de modificar la lista

            // Buscar el índice del usuario por su ID
            int indexToRemove = -1;
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios[i].ID == data.ID)
                {
                    indexToRemove = i;
                    break; // Salir del ciclo cuando encontramos el usuario
                }
            }

            if (indexToRemove != -1)
            {
                listaUsuarios.RemoveAt(indexToRemove); // Eliminar el usuario por índice

                Write(); // Guardar cambios en la base de datos o archivo

                Console.WriteLine("Usuario eliminado con éxito");
                Console.WriteLine(listaUsuarios); // Mostrar la lista actualizada

                return; // Salir del método después de eliminar el usuario
            }

            throw new Exception("No se encontró el usuario a eliminar");
        }







        public List<Usuario> Find(Usuario data)
        {
            Read(); // Cargar listaUsuarios
            List<Usuario> resultados = new List<Usuario>();

            foreach (Usuario u in listaUsuarios)
            {
                bool coincide = false;

                if (data.ID != 0 && data.ID == u.ID)
                    coincide = true;

                if (!string.IsNullOrEmpty(data.Nombre) && u.Nombre.IndexOf(data.Nombre, StringComparison.OrdinalIgnoreCase) >= 0)
                    coincide = true;

                if (data.Dni != 0 && data.Dni == u.Dni)
                    coincide = true;

                if (!string.IsNullOrEmpty(data.Mail) && u.Mail.IndexOf(data.Mail, StringComparison.OrdinalIgnoreCase) >= 0)
                    coincide = true;

                if (coincide)
                    resultados.Add(u);
            }

            return resultados;
        }



        public void Modify(Usuario data)
        {
            Read();
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios[i].ID == data.ID)
                {
                    listaUsuarios[i].Nombre = data.Nombre;
                    listaUsuarios[i].Dni = data.Dni;
                    listaUsuarios[i].Mail = data.Mail;

                    Write();
                    Limpiar();
                    return;

                }
            }
            throw new Exception("No se puede modificar el Usuario: no se encuentra en la lista");
            

        }

        public string List()
        {
            Read();
            string json = JsonSerializer.Serialize(listaUsuarios);
            return json;
            throw new Exception("No hay lista para mostrar");

        }

        public void Login(Usuario data)
        {
            throw new NotImplementedException();
        }
    }
}
