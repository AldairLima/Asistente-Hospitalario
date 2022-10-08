using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class UsuarioService
    {
        private string ConnString;

        public UsuarioService() { ConnString = Settings.Default.ConnectionString.ToString(); }

        public bool ValidateLogin(Usuario usuario) {
            try
            {
                MySqlConnection conex = new MySqlConnection(this.ConnString);
                conex.Open();

                string SQLQuery = "";
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();



                executer = null;
                bruteData = null;
                conex.Close();
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
