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
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class IngresoService
    {

        public IngresoService() { }

        //SELECT QUERIES
        public static ArrayList getIngresosFor(int NumExpediente) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList ingresos = new ArrayList();
                string query = string.Format("SELECT CodigoIngreso, FechaIngreso, FechaAlta, Diagnostico, CodigoDoctor, CodigoSala, NumeroCamilla, DiagnosticoFinal FROM Ingreso WHERE NumExpediente={0};", NumExpediente);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        DateTime? altaF = null;
                        if (bruteData.GetValue(3) != null) altaF = bruteData.GetDateTime(4);

                        Ingreso foundIngreso = new Ingreso(bruteData.GetString(0),
                            NumExpediente,
                            bruteData.GetDateTime(1),
                            bruteData.GetString(2),
                            altaF,
                            bruteData.GetString(4),
                            bruteData.GetString(5),
                            bruteData.GetInt32(6),
                            bruteData.GetString(7));
                        
                        ingresos.Add(foundIngreso);
                    }
                }
                bruteData.Close();
                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();

                return ingresos;
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

        public static DataTable getIngresosActivos() {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
            Conex.Open();
            try
            {
                string query = "SELECT ig.CodigoIngreso as Codigo, ig.NumExpediente as Expediente, ex.NombrePaciente as Nombres, ex.ApellidoPaciente as Apellidos, ig.FechaIngreso as Ingresado, ig.Diagnostico as Caso, ig.CodigoDoctor as Doctor, ig.CodigoSala as Sala, ig.NumeroCamilla as Camilla FROM ingreso AS ig JOIN expediente AS ex ON ex.NumExpediente = ig.NumExpediente WHERE ig.FechaAlta is null;";
                MySqlDataAdapter bruteData = new MySqlDataAdapter(query, Conex);

                DataTable Ingresos = new DataTable();
                bruteData.Fill(Ingresos);

                bruteData.Dispose();
                
                return Ingresos;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return null;
            }
            finally 
            {
                Conex.Close();
                Conex.Dispose();
            }
        }

        public static DataTable getAltas() {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
            Conex.Open();
            try
            {
                string query = "SELECT ig.CodigoIngreso as Codigo, ig.NumExpediente as Expediente, ex.NombrePaciente as Nombres, ex.ApellidoPaciente as Apellidos, ig.FechaIngreso as Ingresado, ig.FechaAlta as Alta, ig.Diagnostico as Caso, ig.DiagnosticoFinal as Diagnostico, ig.CodigoDoctor as Doctor, ig.CodigoSala as Sala, ig.NumeroCamilla as Camilla FROM ingreso AS ig\r\nJOIN expediente AS ex ON ex.NumExpediente = ig.NumExpediente\r\nWHERE ig.FechaAlta is not null;";
                MySqlDataAdapter bruteData = new MySqlDataAdapter(query, Conex);

                DataTable Ingresos = new DataTable();
                bruteData.Fill(Ingresos);
                bruteData.Dispose();
                
                return Ingresos;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                return null;
            }
            finally
            {
                Conex.Close();
                Conex.Dispose();
            }
        }

        public static Ingreso getIngreso(string codigoIngreso)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {

                string query = string.Format("SELECT NumExpediente, FechaIngreso, FechaAlta, Diagnostico, CodigoDoctor, CodigoSala, NumeroCamilla, DiagnosticoFinal FROM Ingreso WHERE CodigoIngreso='{0}';", codigoIngreso);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Ingreso foundIngreso = null;
                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    DateTime? altaF = null;
                    if (bruteData.GetValue(3) != null) altaF = bruteData.GetDateTime(3);

                    foundIngreso = new Ingreso(codigoIngreso,
                        bruteData.GetInt32(0),
                        bruteData.GetDateTime(1),
                        bruteData.GetString(2),
                        altaF,
                        bruteData.GetString(4),
                        bruteData.GetString(5),
                        bruteData.GetInt32(6),
                        bruteData.GetString(7));
                }

                bruteData.Close();
                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();

                return foundIngreso;
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

        public static Ingreso getIngresoActivo(int NumExpediente)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {

                string query = string.Format("SELECT CodigoIngreso, FechaIngreso, Diagnostico, CodigoDoctor, CodigoSala, NumeroCamilla FROM Ingreso WHERE NumExpediente={0} and FechaAlta is null;", NumExpediente);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Ingreso foundIngreso = null;
                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    foundIngreso = new Ingreso(bruteData.GetString(0),
                        NumExpediente,
                        bruteData.GetDateTime(1),
                        bruteData.GetString(2),
                        null,
                        bruteData.GetString(3),
                        bruteData.GetString(4),
                        bruteData.GetInt32(5), 
                        null);
                }

                bruteData.Close();
                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();

                return foundIngreso;
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

        public static ArrayList getIngresosByRoom(string codigoSala) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList ingresos = new ArrayList();
                string query = string.Format("SELECT CodigoIngreso, NumExpediente, FechaIngreso, FechaAlta, Diagnostico, CodigoDoctor, NumeroCamilla, DiagnosticoFinal FROM Ingreso WHERE CodigoSala='{0}' and FechaAlta is NULL;", codigoSala);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        DateTime? altaF = null;
                        if (bruteData.GetValue(4) != null) altaF = bruteData.GetDateTime(4);

                        Ingreso foundIngreso = new Ingreso(bruteData.GetString(0),
                            bruteData.GetInt32(1),
                            bruteData.GetDateTime(2),
                            bruteData.GetString(3),
                            altaF,
                            bruteData.GetString(5),
                            codigoSala,
                            bruteData.GetInt32(6),
                            bruteData.GetString(7)); ;

                        ingresos.Add(foundIngreso);
                    }
                }
                bruteData.Close();
                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();

                return ingresos;
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

        //INSERTAR
        public static void createIngreso(Ingreso nuevoIngreso) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                //CREAR CODIGO Y REVISAR VALORES
                string cont = string.Format("SELECT COUNT(*) + 1 FROM ingreso WHERE CodigoIngreso LIKE '{0}%'",nuevoIngreso.getCodigoSala());
                MySqlCommand executer = new MySqlCommand(cont, conex);
                int codNum = (int)executer.ExecuteScalar();
                string codigoIngreso = nuevoIngreso.getCodigoSala() + codNum.ToString("D4");
                string fechaDeAlta = "null", diagnosticoFinal = "null";
                if (nuevoIngreso.getFechaAlta() != null) fechaDeAlta = "'" + nuevoIngreso.getFechaAlta().Value.ToString("yyyy-MM-dd") + "'";
                if (nuevoIngreso.getDiagnosticoFinal() != null || nuevoIngreso.getDiagnosticoFinal() != "") diagnosticoFinal = "'" + nuevoIngreso.getDiagnosticoFinal() + "'";

                //CREAR EL INGRESO
                string SQLQuery = string.Format("insert into ingreso(CodigoIngreso, NumExpediente, FechaIngreso, FechaAlta, Diagnostico, CodigoDoctor, CodigoSala, NumeroCamilla, DiagnosticoFinal) values('{0}',{1},'{2}',{3},'{4}','{5}','{6}',{7},{8});",
                    codigoIngreso, nuevoIngreso.getNumeroExpediente(), nuevoIngreso.getFechaCaso().ToString("yyyy-MM-dd"), fechaDeAlta,
                    nuevoIngreso.getDiagnosticoInicial(), nuevoIngreso.getCodigoDoctor(), nuevoIngreso.getCodigoSala(), nuevoIngreso.getNumeroCamilla(), diagnosticoFinal);
                executer.CommandText = SQLQuery;
                executer.ExecuteNonQuery();

                executer.Connection.Close();
                executer.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }

        //UPDATE
        public static void updateIngreso(Ingreso ingreso) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                if (ingreso.getCodigoIngreso() != null)
                {
                    string alta = "null", finalD = "null";
                    if (ingreso.getFechaAlta() != null) alta = "'" + ingreso.getFechaAlta().Value.ToString("yyyy-MM-dd") + "'";
                    if (ingreso.getDiagnosticoFinal() != null || ingreso.getDiagnosticoFinal().Length > 0) finalD = "'" + ingreso.getDiagnosticoFinal() + "'";
                    string SQLQuery = string.Format("update ingreso set NumExpediente={1}, FechaIngreso='{2}', FechaAlta={3}, Diagnostico='{4}', CodigoDoctor='{5}', CodigoSala='{6}', NumeroCamilla={7}, DiagnosticoFinal={8} where CodigoIngreso='{0}';",
                        ingreso.getCodigoIngreso(), ingreso.getNumeroExpediente(), ingreso.getFechaCaso().ToString("yyyy-MM-dd"), alta, 
                        ingreso.getDiagnosticoInicial(), ingreso.getCodigoDoctor(), ingreso.getCodigoSala(), ingreso.getNumeroCamilla(), finalD);
                    MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
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
                conex.Close();
                conex.Dispose();
            }
        }

        public static void putAlta(string codigoIngreso, DateTime fechaAlta, string diagnosticoFinal = "null") {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                if (diagnosticoFinal != "null") diagnosticoFinal = "'" + diagnosticoFinal + "'";
                string SQLQuery = string.Format("update ingreso set FechaAlta='{1}', DiagnosticoFinal={2} where CodigoIngreso='{0}';",
                        codigoIngreso, fechaAlta.ToString("yyyy-MM-dd"), diagnosticoFinal);
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                executer.ExecuteNonQuery();

                executer.Connection.Close();
                executer.Dispose();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }

        //DELETE
        public static void deleteIngreso(string codigoIngreso) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string SQLQuery = string.Format("DELETE FROM ingreso WHERE CodigoIngreso='{0}';", codigoIngreso);
                MySqlCommand executer = new MySqlCommand(SQLQuery, conex);
                executer.ExecuteNonQuery();

                executer.Connection.Close();
                executer.Dispose();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            finally
            {
                conex.Close();
                conex.Dispose();
            }
        }
    }
}
