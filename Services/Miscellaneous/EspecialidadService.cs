using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services.Miscellaneous
{
    public class EspecialidadService
    {
        public static ArrayList getAll() {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList especialidades = new ArrayList();
                string query = "select CodigoEspecialidad, NombreEspecialidad from Especialidad;";
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read()) {
                        Especialidad especialidad = new Especialidad(bruteData.GetString(0), bruteData.GetString(1));
                        especialidades.Add(especialidad);
                    }
                }

                conex.Close();
                conex.Dispose();

                return especialidades;
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static Especialidad getByKey(string codigo) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("select NombreEspecialidad from especialidad where CodigoEspecialidad='{0}';",codigo);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Especialidad especialidad = null;
                if (bruteData.HasRows) especialidad = new Especialidad(codigo, bruteData.GetString(0));

                conex.Close();
                conex.Dispose();

                return especialidad;
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void createEspecialidad(Especialidad nuevo) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("insert into especialidad() values('{0}','{1}');", nuevo.Codigo, nuevo.Nombre);
                MySqlCommand executer = new MySqlCommand(query, conex);
                executer.ExecuteNonQuery();

                conex.Close();
                conex.Dispose();
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public static void updateEspecialidad(Especialidad actualizado) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("update especialidad set CodigoEspecialidad='{0}', NombreEspecialidad='{1}');", actualizado.Codigo, actualizado.Nombre);
                MySqlCommand executer = new MySqlCommand(query, conex);
                executer.ExecuteNonQuery();

                conex.Close();
                conex.Dispose();
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public static void deleteEspecialidad(string codigo) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("delete from especialidad where CodigoEspecialidad='{0}';", codigo);
                MySqlCommand executer = new MySqlCommand(query, conex);
                executer.ExecuteNonQuery();

                conex.Close();
                conex.Dispose();
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}
