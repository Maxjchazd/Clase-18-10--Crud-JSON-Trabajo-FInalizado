using CapaDeNegocio.Clases;
using Crud;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;


namespace CapaDeNegocio.Datos
{
    public class DatosCarrera: IAccesoADatos<Carrera>
    {

        public static List<Carrera> listaCarreras;

        private static int lastId;


        private static void Read()
        {

            try
            {

                string pathC = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\carreras.json";
                string jsonc = File.ReadAllText(pathC);
                listaCarreras = JsonSerializer.Deserialize<List<Carrera>>(jsonc);
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
                string pathC = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\carreras.json";
                string jsonc = JsonSerializer.Serialize(listaCarreras);
                File.WriteAllText(pathC, jsonc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Limpiar()
        {
            listaCarreras.Clear();
        }


        public void Add(Carrera data)
        {
            Read();
            string pathCID = "C:\\Users\\A6\\source\\repos\\CapaDeNegocio\\Datos\\carrerasLastId.txt";

            lastId = int.Parse(File.ReadAllText(pathCID));

            data.ID = ++lastId;

            File.WriteAllText(pathCID, lastId.ToString()); // guarda el ultimo ID en el archivo de texto
            listaCarreras.Add(data);


            Write();
            Limpiar();




        }

        public void Erase(Carrera data)
        {
            Read(); // Cargar los datos antes de modificar la lista

            // Buscar el índice del usuario por su ID
            int indexToRemove = -1;
            for (int i = 0; i < listaCarreras.Count; i++)
            {
                if (listaCarreras[i].ID == data.ID)
                {
                    indexToRemove = i;
                    break; // Salir del ciclo cuando encontramos el usuario
                }
            }

            if (indexToRemove != -1)
            {
                listaCarreras.RemoveAt(indexToRemove); // Eliminar el usuario por índice

                Write(); // Guardar cambios en la base de datos o archivo

                Console.WriteLine("Carrera eliminada con éxito");
                Console.WriteLine(listaCarreras); // Mostrar la lista actualizada

                return; // Salir del método después de eliminar el carrera
            }

            throw new Exception("No se encontró la carrera a eliminar");
        }







        public List<Carrera> Find(Carrera data)
        {
            Read(); // Cargar listaUsuarios
            List<Carrera> Encontrados = new List<Carrera>();

            foreach (Carrera c in listaCarreras)
            {
                bool coincide = false;

                if (data.ID != 0 && data.ID == c.ID)
                    coincide = true;

                if (!string.IsNullOrEmpty(data.Nombre) && c.Nombre.IndexOf(data.Nombre, StringComparison.OrdinalIgnoreCase) >= 0)
                    coincide = true;

                if (data.Código != 0 && data.Código == c.Código)
                    coincide = true;

                if (!string.IsNullOrEmpty(data.Cátedra) && c.Cátedra != null && c.Cátedra.IndexOf(data.Cátedra, StringComparison.OrdinalIgnoreCase) >= 0)
                    coincide = true;


                if (!string.IsNullOrEmpty(data.Mail) && c.Mail.IndexOf(data.Mail, StringComparison.OrdinalIgnoreCase) >= 0)
                    coincide = true;

                if (coincide)
                    Encontrados.Add(c);
            }

            return Encontrados;
        }



        public void Modify(Carrera data)
        {
            Read();
            for (int i = 0; i < listaCarreras.Count; i++)
            {
                if (listaCarreras[i].ID == data.ID)
                {
                    listaCarreras[i].Nombre = data.Nombre;
                    listaCarreras[i].Código = data.Código;
                    listaCarreras[i].Cátedra = data.Cátedra;
                    listaCarreras[i].Mail = data.Mail;

                    Write();
                    Limpiar();
                    return;

                }
            }
            throw new Exception("No se puede modificar la carrera: no se encuentra en la lista");


        }

        public string List()
        {
            Read();
            string jsonc = JsonSerializer.Serialize(listaCarreras);
            return jsonc;
            throw new Exception("No hay lista para mostrar");

        }

        public void Login(Carrera data)
        {
            throw new NotImplementedException();
        }
    }
}

