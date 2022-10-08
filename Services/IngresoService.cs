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
        public ArrayList getAllActive() {
            ArrayList IngresosActivos = new ArrayList();
            try
            {
                MySqlConnection Conex = new MySqlConnection(this.ConnString);
                Conex.Open();

                string query = "SELECT ig.CodigoIngreso, ig.NumExpediente, ex.NombrePaciente, ig.FechaIngreso, ig.Diagnostico, ig.CodigoDoctor, ig.CodigoSala, ig.NumeroCamilla FROM ingreso AS ig JOIN expediente AS ex ON ex.NumExpediente = ig.NumExpediente WHERE ig.FechaAlta is null;";
                MySqlCommand getActives = new MySqlCommand(query, Conex);
                MySqlDataReader bruteData = getActives.ExecuteReader();
                foreach (IDataRecord Data in bruteData)
                {
                    int NExp = int.Parse(Data[1].ToString());
                    Ingreso NuevoIngreso = new Ingreso(
                        Data[0].ToString(),
                        NExp,
                        DateTime.Parse(Data[3].ToString()),
                        Data[4].ToString(),
                        null,
                        Data[5].ToString(),
                        Data[6].ToString(),
                        int.Parse(Data[7].ToString()),
                        null);
                    Expediente NuevoExpediente = new Expediente();
                    NuevoExpediente.setNumeroExpediente(NExp);
                    NuevoExpediente.setNombre(Data[2].ToString());
                    NuevoIngreso.setExpediente(NuevoExpediente);
                    IngresosActivos.Add(NuevoIngreso);
                }
                getActives = null;
                bruteData = null;
                Conex.Close();
            }
            catch (Exception error) {
                MessageBox.Show(error.ToString());
            }
            return IngresosActivos;
        }
    }
}
