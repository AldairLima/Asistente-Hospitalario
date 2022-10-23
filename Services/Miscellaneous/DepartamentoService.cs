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
    public class DepartamentoService
    {
        public static ArrayList getAll()
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList departamentos = new ArrayList();
                string query = "select CodigoEspecialidad, NombreEspecialidad from Especialidad;";
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        Departamento departamento = new Departamento(bruteData.GetString(0), bruteData.GetString(1));
                        departamentos.Add(departamento);
                    }
                }

                conex.Close();
                conex.Dispose();

                return departamentos;
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static Departamento getByKey(string codigo)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("select NombreDepartamento from departamento where CodigoDepartamento='{0}';", codigo);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Departamento departamento = null;
                if (bruteData.HasRows) departamento = new Departamento(codigo, bruteData.GetString(0));

                conex.Close();
                conex.Dispose();

                return departamento;
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void createDepartamento(Departamento nuevo)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("insert into departamento() values('{0}','{1}');", nuevo.Codigo, nuevo.Nombre);
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

        public static void updateDepartamento(Departamento actualizado)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("update departamento set CodigoDepartamento='{0}', NombreDepartamento='{1}');", actualizado.Codigo, actualizado.Nombre);
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

        public static void deleteDepartamento(string codigo)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                string query = string.Format("delete from departamento where CodigoDepartamento='{0}';", codigo);
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
