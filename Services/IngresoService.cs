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
        private string ConnString;

        public IngresoService() {
            this.ConnString = Settings.Default.ConnectionString.ToString();
        }

        //SELECT QUERIES
        public DataTable getAllActive() {
            try
            {
                MySqlConnection Conex = new MySqlConnection(this.ConnString);
                Conex.Open();

                string query = "SELECT ig.CodigoIngreso, ig.NumExpediente, ex.NombrePaciente, ig.FechaIngreso, ig.Diagnostico, ig.CodigoDoctor, ig.CodigoSala, ig.NumeroCamilla FROM ingreso AS ig JOIN expediente AS ex ON ex.NumExpediente = ig.NumExpediente WHERE ig.FechaAlta is null;";
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
    }
}
