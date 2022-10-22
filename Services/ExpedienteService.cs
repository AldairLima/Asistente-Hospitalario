using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using MySql.Data.MySqlClient;
using System;
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
            try
            {
                MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
                conex.Open();

                string SQLQuery = string.Format("SELECT NombrePaciente, ApellidoPaciente, DUIPaciente, EdadPaciente, SexoPaciente FROM expediente WHERE NumeroExpediente={0};", numExpediente);
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Expediente expediente = null;

                if (bruteData != null || bruteData.HasRows)
                {
                    expediente = new Expediente(numExpediente,
                        bruteData.GetString(0),
                        bruteData.GetString(1),
                        bruteData.GetString(2),
                        bruteData.GetInt32(3),
                        bruteData.GetChar(4));
                }

                executer.Connection.Close();
                bruteData.Close();
                conex.Close();
                executer.Dispose();
                bruteData = null;
                conex = null;

                return expediente;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static DataTable getAllExpedientes()
        {
            try
            {
                MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
                conex.Open();

                string query = "SELECT NumeroExpediente, NombrePaciente, ApellidoPaciente, DUIPaciente, EdadPaciente, SexoPaciente FROM expediente;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conex);
                DataTable expedientes = new DataTable();
                adapter.Fill(expedientes);

                adapter = null;
                conex.Close();
                conex = null;

                return expedientes;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        //
        //INSERT
        //
        public static void createExpediente(Expediente expediente)
        {
            try
            {
                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
                Conex.Open();

                if (expediente != null && !(expediente.getNumeroExpediente() > 0))
                {
                    
                    string query = string.Format("insert into expediente(NombrePaciente, ApellidoPaciente, DUIPaciente, EdadPaciente, SexoPaciente) values('{0}','{1}','{2}',{3},'{4}');",
                        expediente.getNombre(), expediente.getApellido(), expediente.getDUI(), expediente.getEdad(), expediente.getCharSexo());
                    MySqlCommand executer = new MySqlCommand(query, Conex);
                    executer.ExecuteNonQuery();

                    executer.Connection.Close();
                    executer.Dispose();
                }
                Conex.Close();
                Conex = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        //
        //UPDATE
        //
        public static void updateExpediente(Expediente expediente)
        {
            try
            {
                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
                Conex.Open();

                if (expediente != null && expediente.getNumeroExpediente() > 0)
                {

                    string query = string.Format("update expediente set NombrePaciente='{1}', ApellidoPaciente='{2}', DUIPaciente='{3}', EdadPaciente={4}, SexoPaciente='{5}' where NumeroExpediente={0};",
                      expediente.getNumeroExpediente(), expediente.getNombre(), expediente.getApellido(), expediente.getDUI(), expediente.getEdad(), expediente.getCharSexo());
                    MySqlCommand executer = new MySqlCommand(query, Conex);
                    executer.ExecuteNonQuery();

                    executer.Connection.Close();
                    executer.Dispose();
                }
                Conex.Close();
                Conex = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        //
        //DELETE
        //
        public static void deleteExpediente(int numExpediente)
        {
            try
            {
                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
                Conex.Open();

                if (numExpediente > 0)
                {

                    string SQLQuery = string.Format("DELETE FROM expediente WHERE NumeroExpediente={0};", numExpediente);
                    MySqlCommand executer = new MySqlCommand(SQLQuery, Conex);
                    executer.ExecuteNonQuery();

                    executer.Connection.Close();
                    executer.Dispose();
                }
                Conex.Close();
                Conex = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}
