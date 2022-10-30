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
    public class AreaMedService
    {
        public static ArrayList getAll()
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList areamedicas = new ArrayList();
                string query = "select CodigoArea, AreaMedica from areamedica;";
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        AreaMedica areamedica = new AreaMedica(bruteData.GetString(0), bruteData.GetString(1));
                        areamedicas.Add(areamedica);
                    }
                }

                return areamedicas;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }

        public static AreaMedica getByKey(string codigo)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("select AreaMedica from areamedica where CodigoArea='{0}';", codigo);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                AreaMedica areamedica = null;
                if (bruteData.HasRows)
                { 
                    bruteData.Read();
                    areamedica = new AreaMedica(codigo, bruteData.GetString(0)); 
                }

                return areamedica;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }

        public static void createAreaMedica(AreaMedica nuevo)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("insert into areamedica() values('{0}','{1}');", nuevo.Codigo, nuevo.Nombre);
                MySqlCommand executer = new MySqlCommand(query, conex);
                executer.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }

        public static void updateAreaMedica(AreaMedica actualizado)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("update areamedica set CodigoArea='{0}', AreaMedica='{1}');", actualizado.Codigo, actualizado.Nombre);
                MySqlCommand executer = new MySqlCommand(query, conex);
                executer.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }

        public static void deleteAreaMedica(string codigo)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("delete from areamedica where CodigoArea='{0}';", codigo);
                MySqlCommand executer = new MySqlCommand(query, conex);
                executer.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }
    }
}
