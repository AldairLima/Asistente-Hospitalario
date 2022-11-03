using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class ExpedienteService
    {
        public ExpedienteService() { }

        //
        //CONSULTA
        //
        public static Expediente getExpedienteByKey(int numExpediente)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
            conex.Open();
            try
            {

                string SQLQuery = string.Format("SELECT NombrePaciente, ApellidoPaciente, DUIPaciente, EdadPaciente, SexoPaciente FROM expediente WHERE NumExpediente={0};", numExpediente);
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Expediente expediente = null;

                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    expediente = new Expediente(numExpediente,
                        bruteData.GetString(0),
                        bruteData.GetString(1),
                        bruteData.GetString(2),
                        bruteData.GetInt32(3),
                        bruteData.GetChar(4));
                }

                bruteData.Close();
                bruteData.Dispose();
                executer.Dispose();
                executer.Connection.Close();

                return expediente;
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

        public static ArrayList getAllExpedientes()
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList expedientes = new ArrayList();
                string query = "SELECT NumExpediente, NombrePaciente, ApellidoPaciente, DUIPaciente, EdadPaciente, SexoPaciente FROM expediente;";
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();
                
                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        Expediente exp = new Expediente(bruteData.GetInt32(0),
                            bruteData.GetString(1), bruteData.GetString(2), bruteData.GetString(3),
                                                    bruteData.GetInt32(4), bruteData.GetChar(5));
                        expedientes.Add(exp);
                    }
                }

                return expedientes;
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

        //
        //INSERT
        //
        public static void createExpediente(Expediente expediente)
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                
                if (expediente != null && !(expediente.getNumeroExpediente() > 0))
                {
                    
                    string query = string.Format("insert into expediente(NombrePaciente, ApellidoPaciente, DUIPaciente, EdadPaciente, SexoPaciente) values('{0}','{1}','{2}',{3},'{4}');",
                        expediente.getNombre(), expediente.getApellido(), expediente.getDUI(), expediente.getEdad(), expediente.getCharSexo());
                    MySqlCommand executer = new MySqlCommand(query, Conex);
                    executer.ExecuteNonQuery();

                    executer.Connection.Close();
                    executer.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                Conex.Close();
                Conex.Dispose();
            }
        }

        //
        //UPDATE
        //
        public static void updateExpediente(Expediente expediente)
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                
                if (expediente != null && expediente.getNumeroExpediente() > 0)
                {

                    string query = string.Format("update expediente set NombrePaciente='{1}', ApellidoPaciente='{2}', DUIPaciente='{3}', EdadPaciente={4}, SexoPaciente='{5}' where NumExpediente={0};",
                      expediente.getNumeroExpediente(), expediente.getNombre(), expediente.getApellido(), expediente.getDUI(), expediente.getEdad(), expediente.getCharSexo());
                    MySqlCommand executer = new MySqlCommand(query, Conex);
                    executer.ExecuteNonQuery();

                    executer.Connection.Close();
                    executer.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                Conex.Close();
                Conex.Dispose();
            }
        }

        //
        //DELETE
        //
        public static void deleteExpediente(int numExpediente)
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                
                if (numExpediente > 0)
                {
                    string SQLQuery = string.Format("DELETE FROM expediente WHERE NumExpediente={0};", numExpediente);
                    MySqlCommand executer = new MySqlCommand(SQLQuery, Conex);
                    executer.ExecuteNonQuery();

                    executer.Connection.Close();
                    executer.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                Conex.Close();
                Conex.Dispose();
            }
        }
    }
}
