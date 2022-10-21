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
    public class DoctorService
    {
        private string ConnString;

        public DoctorService() { this.ConnString = Settings.Default.ConnectionString; }

        public DataTable getDoctors() {
            try
            {
                MySqlConnection Conex = new MySqlConnection(this.ConnString);
                string query = "";
                MySqlDataAdapter bruteData = new MySqlDataAdapter(query, Conex);

                DataTable doctores = new DataTable();
                bruteData.Fill(doctores);

                bruteData.Dispose();
                Conex.Close();
                return doctores;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public Doctor getDoctorByCodigo(string CodigoDoctor) {
            try
            {
                MySqlConnection Conex = new MySqlConnection(this.ConnString);
                string query = "";
                MySqlCommand executer = new MySqlCommand(query, Conex);
                MySqlDataReader bruteDate = executer.ExecuteReader();

                Doctor doctor = new Doctor(
                        bruteDate.GetValue(0).ToString(),
                        bruteDate.GetValue(1).ToString(),
                        bruteDate.GetValue(2).ToString()
                    );

                bruteDate.Close();
                executer.Connection.Close();
                executer = null;
                Conex.Close();

                return doctor;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public void createDoctor(Doctor doctor) {
            try
            {
                MySqlConnection Conex = new MySqlConnection(this.ConnString);
                string queryUsuario = string.Format("");
                MySqlCommand executer = new MySqlCommand(queryUsuario, Conex);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}
