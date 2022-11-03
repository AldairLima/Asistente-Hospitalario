using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class SalaService
    {
        public SalaService() { }

        //CONSULTA
        public ArrayList getSalasDisponibles() {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList salasDisponibles = new ArrayList();

                string SQLquery = "SELECT CodigoSala, NumeroPiso, NumeroHabitacion, CodigoArea, NumeroCamillas, Disponibles FROM salahospital WHERE Disponibles > 0;";
                MySqlCommand executer = new MySqlCommand(SQLquery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        SalaMedica foundSala = new SalaMedica(bruteData.GetString(0), bruteData.GetInt32(1), bruteData.GetInt32(2), bruteData.GetString(3), bruteData.GetInt32(4), bruteData.GetInt32(5));
                        salasDisponibles.Add(foundSala);
                    }
                }

                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();

                return salasDisponibles;
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

        public static ArrayList getAllSalas() {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                ArrayList salas = new ArrayList();
                
                string SQLquery = "SELECT CodigoSala, NumeroPiso, NumeroHabitacion, CodigoArea, NumeroCamillas, Disponibles FROM salahospital;";
                MySqlCommand executer = new MySqlCommand(SQLquery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        SalaMedica foundSala = new SalaMedica(bruteData.GetString(0), bruteData.GetInt32(1), bruteData.GetInt32(2), bruteData.GetString(3), bruteData.GetInt32(4), bruteData.GetInt32(5));
                        salas.Add(foundSala);
                    }
                }

                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();
                
                return salas;
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

        public static SalaMedica getSalaByKey(string codigoSala) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string SQLquery = string.Format("SELECT  NumeroPiso, NumeroHabitacion, CodigoArea, NumeroCamillas, Disponibles FROM salahospital WHERE CodigoSala='{0}';", codigoSala);
                MySqlCommand executer = new MySqlCommand(SQLquery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                SalaMedica foundSala = null;
                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    foundSala = new SalaMedica(codigoSala, bruteData.GetInt32(0), bruteData.GetInt32(1), bruteData.GetString(2), bruteData.GetInt32(3), bruteData.GetInt32(4));
                }

                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();
                
                return foundSala;
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

        public static SalaMedica getSalaByRoom(int Piso, int habitacion)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string SQLquery = string.Format("SELECT CodigoSala, CodigoArea, NumeroCamillas, Disponibles FROM salahospital WHERE NumeroPiso={0} AND NumeroHabitacion={1};", Piso, habitacion);
                MySqlCommand executer = new MySqlCommand(SQLquery, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                SalaMedica foundSala = null;
                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    foundSala = new SalaMedica(bruteData.GetString(0), Piso, habitacion, bruteData.GetString(1), bruteData.GetInt32(2), bruteData.GetInt32(3));
                }

                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();
                
                return foundSala;
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
        public static void createSala(SalaMedica sala) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string codigoSala = sala.getCodigoAreaMedica().Substring(0,2) + sala.getNumeroPiso().ToString() + sala.getNumeroHabitacion().ToString();
                string SQLQuery = string.Format("insert into salahospital(CodigoSala, NumeroPiso, NumeroHabitacion, CodigoArea, NumeroCamillas, Disponibles) values('{0}',{1},{2},'{3}',{4},{4});",
                    codigoSala, sala.getNumeroPiso(), sala.getNumeroHabitacion(), sala.getCodigoAreaMedica(), sala.getNumeroCamillas());
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

        //UPDATE
        public static void updateSala(SalaMedica sala) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string SQLQuery = string.Format("update salahospital set NumeroPiso={1}, NumeroHabitacion={2}, CodigoArea='{3}', NumeroCamillas={4}, Disponibles={5} where CodigoSala='{0}';",
                    sala.getCodigoSala(), sala.getNumeroPiso(), sala.getNumeroHabitacion(), sala.getCodigoAreaMedica(), sala.getNumeroCamillas(), sala.getDisponibles());
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

        public static void updateCamillas(SalaMedica sala) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string SQLQuery = string.Format("update salahospital set Disponibles={1} where CodigoSala='{0}';",
                    sala.getCodigoSala(), sala.getDisponibles());
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

        //ELIMINAR 
        public static void deleteSala(string codigoSala) {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                
                string SQLQuery = string.Format("DELETE FROM salahospital WHERE CodigoSala='{0}';", codigoSala);
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
