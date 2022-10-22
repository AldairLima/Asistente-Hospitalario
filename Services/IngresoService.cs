using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class IngresoService
    {

        public IngresoService() { }

        //SELECT QUERIES
        public static DataTable getIngresosActivos() {
            try
            {
                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
                Conex.Open();

                string query = "SELECT ig.CodigoIngreso as Codigo, ig.NumExpediente as Expediente, ex.NombrePaciente as Nombres, ex.ApellidoPaciente as Apellidos, ig.FechaIngreso as Ingresado, ig.Diagnostico as Caso, ig.CodigoDoctor as Doctor, ig.CodigoSala as Sala, ig.NumeroCamilla as Camilla FROM ingreso AS ig JOIN expediente AS ex ON ex.NumExpediente = ig.NumExpediente WHERE ig.FechaAlta is null;";
                MySqlDataAdapter bruteData = new MySqlDataAdapter(query, Conex);
                 
                DataTable Ingresos = new DataTable();
                bruteData.Fill(Ingresos);

                bruteData.Dispose();
                Conex.Close();

                return Ingresos;
            }
            catch (Exception error) {
                MessageBox.Show(error.ToString());
                return null;
            }
        }

        public static DataTable getAltas() {
            try
            {
                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
                Conex.Open();

                string query = "SELECT ig.CodigoIngreso as Codigo, ig.NumExpediente as Expediente, ex.NombrePaciente as Nombres, ex.ApellidoPaciente as Apellidos, ig.FechaIngreso as Ingresado, ig.FechaAlta as Alta, ig.Diagnostico as Caso, ig.DiagnosticoFinal as Diagnostico, ig.CodigoDoctor as Doctor, ig.CodigoSala as Sala, ig.NumeroCamilla as Camilla\r\nFROM ingreso AS ig\r\nJOIN expediente AS ex ON ex.NumExpediente = ig.NumExpediente\r\nWHERE ig.FechaAlta is not null;";
                MySqlDataAdapter bruteData = new MySqlDataAdapter(query, Conex);

                DataTable Ingresos = new DataTable();
                bruteData.Fill(Ingresos);

                bruteData.Dispose();
                Conex.Close();
                Conex.Dispose();

                return Ingresos;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return null;
            }
        }

        public static Ingreso getIngreso(string codigoIngreso) {
            try
            {
                MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
                conex.Open();

                string query = string.Format("{0}",codigoIngreso);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                DateTime? altaF = null;
                if (bruteData.GetValue(3) != null) altaF = DateTime.Parse(bruteData.GetValue(3).ToString());

                Ingreso foundIngreso = new Ingreso(
                    codigoIngreso,
                    int.Parse(bruteData.GetValue(0).ToString()),
                    DateTime.Parse(bruteData.GetValue(1).ToString()),
                    bruteData.GetValue(2).ToString(),
                    altaF,
                    bruteData.GetValue(4).ToString(),
                    bruteData.GetValue(5).ToString(),
                    int.Parse(bruteData.GetValue(6).ToString()),
                    bruteData.GetValue(7).ToString()
                    );

                bruteData.Close();
                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();
                conex.Close();
                conex.Dispose();

                return foundIngreso;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
