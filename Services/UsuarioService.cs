using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class UsuarioService
    {
        private string ConnString;

        public UsuarioService() { ConnString = Settings.Default.ConnectionString.ToString(); }

        public Usuario ValidateLogin(string NombreUsuario, string Password, int rango) {
            try
            {
                MySqlConnection conex = new MySqlConnection(this.ConnString);
                conex.Open();

                string SQLQuery = string.Format("SELECT CodigoUsuario, CarnetUsuario, DUI, NombreUsuario, ApellidoUsuario, Contrasena, EdadUsuario, SexoUsuario, CodigoDepartamento, CargoUsuario, RangoUsuario FROM usuario \r\nWHERE (CarnetUsuario='{0}') and Contrasena='{1}' and RangoUsuario={2};", NombreUsuario, Password, rango.ToString());
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Usuario session = new Usuario(bruteData.GetValue(0).ToString(),
                                             bruteData.GetValue(1).ToString(),
                                             bruteData.GetValue(2).ToString(),
                                             bruteData.GetValue(3).ToString(),
                                             bruteData.GetValue(4).ToString(),
                                             bruteData.GetValue(5).ToString(),
                                             int.Parse(bruteData.GetValue(6).ToString()),
                                             bruteData.GetValue(7).ToString().ToCharArray()[0],
                                             bruteData.GetValue(8).ToString(),
                                             bruteData.GetValue(9).ToString(),
                                             int.Parse(bruteData.GetValue(10).ToString()));

                executer.Connection.Close();
                bruteData.Close();
                conex.Close();

                return session;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
