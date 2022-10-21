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

        public UsuarioService() { }

        public static Usuario ValidateLogin(string UsuarioLogin, string Password, int rango) {
            try
            {
                MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
                conex.Open();
                string SQLQuery;
                if (UsuarioLogin.Length <= 6 && !UsuarioLogin.Contains(' '))
                {
                    SQLQuery = string.Format("SELECT CodigoUsuario, CarnetUsuario, DUI, NombreUsuario, ApellidoUsuario, Contrasena, EdadUsuario, SexoUsuario, CodigoDepartamento, CargoUsuario, RangoUsuario FROM usuario WHERE CarnetUsuario='{0}' and Contrasena='{1}' and RangoUsuario={2};", UsuarioLogin, Password, rango.ToString());
                }
                else
                {
                    string[] nombreapellido = UsuarioLogin.Split(' ');
                    string nombre = "";
                    string apellido = "";
                    if (nombreapellido.Length > 3)
                    {
                        nombre = nombreapellido[0] + " " + nombreapellido[1];
                        apellido = nombreapellido[2] + " " + nombreapellido[3];
                    }
                    else if (nombreapellido.Length < 3 && nombreapellido.Length > 1) {
                        nombre = nombreapellido[0];
                        apellido = nombreapellido[1];
                    }
                    SQLQuery = string.Format("SELECT CodigoUsuario, CarnetUsuario, DUI, NombreUsuario, ApellidoUsuario, Contrasena, EdadUsuario, SexoUsuario, CodigoDepartamento, CargoUsuario, RangoUsuario FROM usuario WHERE (NombreUsuario LIKE '%{0}%' or ApellidoUsuario LIKE '%{1}%') and Contrasena='{2}' and RangoUsuario={3};", nombre, apellido, Password, rango.ToString());
                }
                
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Usuario session = null;

                if (bruteData != null || bruteData.HasRows) {
                    session = new Usuario(bruteData.GetValue(0).ToString(),
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
                }

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
