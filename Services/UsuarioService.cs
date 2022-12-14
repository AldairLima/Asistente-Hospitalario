using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Numerics;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class UsuarioService
    {

        public UsuarioService() { }

        //
        //CONSULTA
        //
        public static Usuario ValidateLogin(string UsuarioLogin, string Password, int rango) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
            conex.Open();
            try
            {
                
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
                if (bruteData.HasRows) {
                    bruteData.Read();
                    session = new Usuario(bruteData.GetString(0), //CODIGO
                                          bruteData.GetString(1), //CARNET
                                          bruteData.GetString(2), //DUI
                                          bruteData.GetString(3), //NOMBRE
                                          bruteData.GetString(4), //APELLIDO
                                          bruteData.GetString(5), //CONTRASENA
                                          bruteData.GetInt32(6),  //EDAD
                                          bruteData.GetChar(7),   //SEXO
                                          bruteData.GetString(8), //DEPARTAMENTO
                                          bruteData.GetString(9), //CARGO
                                          bruteData.GetInt32(10)); //RANGO
                }

                executer.Connection.Close();
                executer.Dispose();
                bruteData.Close();
                bruteData.Dispose();
                conex.Close();
                conex.Dispose();

                return session;
            }
            catch (Exception e)
            {
                conex.Close();
                conex.Dispose();
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static Usuario getUsuarioByKey(string idUsuario) 
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
            conex.Open();
            try
            {
                string SQLQuery = string.Format("SELECT CodigoUsuario, CarnetUsuario, DUI, NombreUsuario, ApellidoUsuario, Contrasena, EdadUsuario, SexoUsuario, CodigoDepartamento, CargoUsuario, RangoUsuario FROM usuario WHERE CodigoUsuario='{0}' or DUI='{0}';", idUsuario);
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Usuario userFound = null;
                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    userFound = new Usuario(bruteData.GetString(0), //CODIGO
                                          bruteData.GetString(1), //CARNET
                                          bruteData.GetString(2), //DUI
                                          bruteData.GetString(3), //NOMBRE
                                          bruteData.GetString(4), //APELLIDO
                                          bruteData.GetString(5), //CONTRASENA
                                          bruteData.GetInt32(6),  //EDAD
                                          bruteData.GetChar(7),   //SEXO
                                          bruteData.GetString(8), //DEPARTAMENTO
                                          bruteData.GetString(9), //CARGO
                                          bruteData.GetInt32(10)); //RANGO
                }

                executer.Connection.Close();
                executer.Dispose();
                bruteData.Close();
                bruteData.Dispose();

                
                return userFound;
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

        public static DataTable getAllUsuarios() 
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string query = "SELECT CodigoUsuario, CarnetUsuario, DUI, NombreUsuario, ApellidoUsuario, Contrasena, EdadUsuario, SexoUsuario, CodigoDepartamento, CargoUsuario, RangoUsuario FROM usuario;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conex);
                DataTable usuarios = new DataTable();
                adapter.Fill(usuarios);

                adapter.Dispose();

                return usuarios;
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
        public static void createUsuario(Usuario newUser) 
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {        
                if (newUser != null && newUser.getCodigoUsuario() == null) {
                    /*CREACIÓN CODIGO USUARIO*/
                    string iniciales = newUser.getNombre()[0].ToString() + newUser.getApellido()[0].ToString();
                    string queryCount = string.Format("SELECT COUNT(*) + 1 FROM usuario WHERE CodigoUsuario LIKE '{0}%';", iniciales);
                    MySqlCommand executer = new MySqlCommand(queryCount, Conex);
                    int iter = (int)executer.ExecuteScalar();
                    string codigoUsuario = iniciales + iter.ToString("D2");

                    //CREACIÓN USUARIO
                    string queryUsuario = string.Format("insert into usuario(CodigoUsuario, CarnetUsuario, DUI, NombreUsuario, ApellidoUsuario, Contrasena, EdadUsuario, SexoUsuario, CodigoDepartamento, CargoUsuario, RangoUsuario) values('{0}','{1}','{2}','{3}',{4},'{5}',{6},'{7}','{8}','{9}',{10});",
                        codigoUsuario, newUser.getCarnetUsuario(), newUser.getDUI(), newUser.getNombre(), newUser.getApellido(),
                        newUser.getContrasena(), newUser.getEdad(), newUser.getCharSexo(),
                        newUser.getCodigoDepartamento(), newUser.getCargoUsuario(), newUser.getRangoUsuario());
                    executer.CommandText = queryUsuario;
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
        public static void updateUsuario(Usuario usuario)
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                
                if (usuario != null && usuario.getCodigoUsuario() != null)
                {
                    
                    string queryUsuario = string.Format("update usuario set CarnetUsuario='{1}', DUI='{2}', NombreUsuario='{3}', ApellidoUsuario='{4}', Contrasena='{5}', EdadUsuario={6}, SexoUsuario='{7}', CodigoDepartamento='{8}', CargoUsuario='{9}', RangoUsuario={10} where CodigoUsuario='{0}';",
                        usuario.getCodigoUsuario(), usuario.getCarnetUsuario(),     usuario.getDUI(), usuario.getNombre(), usuario.getApellido(),
                        usuario.getContrasena(),         usuario.getEdad(),         usuario.getCharSexo(),
                        usuario.getCodigoDepartamento(), usuario.getCargoUsuario(), usuario.getRangoUsuario());
                    MySqlCommand executer = new MySqlCommand(queryUsuario, Conex);
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

        public static void setNewPassword(string codigoUsuario, string nuevaContrasena) 
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                if (codigoUsuario != null)
                {
                    string queryUsuario = string.Format("update usuario set Contrasena='{1}' where CodigoUsuario='{0}';",
                        codigoUsuario, nuevaContrasena);
                    MySqlCommand executer = new MySqlCommand(queryUsuario, Conex);
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
        public static void deleteUsuario(string codigoUsuario) 
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                if (codigoUsuario != null)
                {            
                    string queryUsuario = string.Format("DELETE FROM usuario WHERE CodigoUsuario='{0}';",codigoUsuario);
                    MySqlCommand executer = new MySqlCommand(queryUsuario, Conex);
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
