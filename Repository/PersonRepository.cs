using SQLite;
using squispe5A.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace squispe5A.Repository
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;

        public string statusMessage { get; set; }
        public PersonRepository(string Path)
        {
            dbPath = Path;
        }
        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name, string lastname)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");
                Persona person = new() {Name=name, LastName = lastname};
                result = conn.Insert(person);
                statusMessage = String.Format("Dato Ingresado");
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR "+ex);
            }
        }

        public List<Persona> GetAllPerson()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("ERROR" + ex);
               
            }
            return new List<Persona>();
        }

        public void UpdatePerson(int id, string name, string lastName)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    person.Name = name;
                    person.LastName = lastName;
                    conn.Update(person);
                    statusMessage = $"Persona con ID {id} actualizada correctamente.";
                }
                else
                {
                    statusMessage = $"Persona con ID {id} no encontrada.";
                }
            }
            catch (Exception ex)
            {
                statusMessage = "ERROR al actualizar: " + ex.Message;
            }
        }
        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    conn.Delete(person);
                    statusMessage = $"Persona con ID {id} eliminada correctamente.";
                }
                else
                {
                    statusMessage = $"Persona con ID {id} no encontrada.";
                }
            }
            catch (Exception ex)
            {
                statusMessage = "ERROR al eliminar: " + ex.Message;
            }
        }
        public void ResetPersonTable()
        {
            try
            {
                Init();
                conn.DropTable<Persona>();
                conn.CreateTable<Persona>();
                statusMessage = "Tabla reiniciada exitosamente.";
            }
            catch (Exception ex)
            {
                statusMessage = "Error al reiniciar tabla: " + ex.Message;
            }
        }
    }
}
