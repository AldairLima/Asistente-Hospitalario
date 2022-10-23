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

                conex.Close();
                conex.Dispose();

                return areamedicas;
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                return null;
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
                if (bruteData.HasRows) areamedica = new AreaMedica(codigo, bruteData.GetString(0));

                conex.Close();
                conex.Dispose();

                return areamedica;
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                return null;
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

        public static void updateAreaMedica(AreaMedica actualizado)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("update areamedica set CodigoArea='{0}', AreaMedica='{1}');", actualizado.Codigo, actualizado.Nombre);
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

        public static void deleteAreaMedica(string codigo)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("delete from areamedica where CodigoArea='{0}';", codigo);
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
