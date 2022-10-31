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
    public class CirugiaService
    {
        public CirugiaService() { }

        //SELECT QUERIES
        public static DataTable getCirugias()
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString.ToString());
            Conex.Open();
            try
            {
                string query = "select cc.CodigoCirugia as IDCirujia, ex.NombrePaciente as nombres, ex.ApellidoPaciente as apellidos, ex.EdadPaciente as edad,  cc.FechaCirugia as fecha,  (SELECT ame.AreaMedica FROM areamedica as ame WHERE ame.CodigoArea = ss.CodigoArea) as Area, (SELECT CONCAT(us.NombreUsuario,\" \", us.ApellidoUsuario) FROM usuario as us WHERE us.CodigoUsuario LIKE (select doc.CodigoUsuario FROM doctor as doc WHERE doc.CodigoDoctor = ps.CodigoDoctor)) as Doctor, cc.DiagnosticoFinal FROM cirugia as cc INNER JOIN expediente as ex on cc.NumExpediente =  ex.NumExpediente JOIN salahospital as ss ON cc.CodigoSala = ss.CodigoSala\r\nJOIN personalcirugia as ps ON cc.CodigoCirugia = ps.CodigoCirugia WHERE ps.RolDoctor LIKE '%PRINCIPAL%';";
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
                Conex.Close();
                Conex.Dispose();
                MessageBox.Show(error.ToString());
                return null;
            }
        }

        public static Cirugia getCirugia(string codigoCirugia)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {

                string query = string.Format("SELECT NumExpediente, FechaCirugia, DiagnosticoCirugia, CodigoSala, DiagnosticoFinal FROM cirugia WHERE CodigoCirugia='{0}'", codigoIngreso);
                MySqlCommand executer = new MySqlCommand(query, conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Cirugia foundCirugia = null;
                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    foundCirugia = new Cirugia(codigoCirugia,
                        bruteData.GetDateTime(1), //fecha cirugia
                        bruteData.GetString(2),  //DIAGNOSTICO
                        bruteData.GetString(4),  //diagnostico final
                        bruteData.GetInt32(0),   //EXPEDIENTE
                        bruteData.GetString(3)); //SALA
                }

                bruteData.Dispose();

                string listPersonal = string.Format("SELECT CodigoDoctor, RolDoctor FROM personalcirugia WHERE CodigoCirugia='{0}';", codigoCirugia);
                executer.CommandText = listPersonal;
                bruteData = executer.ExecuteReader();
                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        foundCirugia.addPersonal(bruteData.GetString(0), bruteData.GetString(1));
                    }
                }

                bruteData.Dispose();
                executer.Connection.Close();
                executer.Dispose();

                return foundCirugia;
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
        public static void createCirugia(Cirugia nuevaCirugia)
        {
            MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
            conex.Open();
            try
            {
                //CREAR CODIGO Y REVISAR VALORES
                string cont = string.Format("SELECT COUNT(*) + 1 FROM cirugia WHERE CodigoCirugia LIKE '{0}%'", nuevaCirugia.getPrincipalDoctor());
                MySqlCommand executer = new MySqlCommand(cont, conex);
                int codNum = (int)executer.ExecuteScalar();
                string codigoCirugia = nuevaCirugia.getPrincipalDoctor() + codNum.ToString("D3");
                
                //CREAR EL INGRESO
                string SQLQuery = string.Format("insert into cirugia(CodigoCirugia, NumExpediente, FechaCirugia, DiagnosticoCirugia, CodigoSala, DiagnosticoFinal) values('{0}',{1},'{2}','{3}','{4}','{5}');",
                    codigoCirugia, nuevaCirugia.getNumeroExpediente(), nuevaCirugia.getFechaCaso().ToString("yyyy-MM-dd"), nuevaCirugia.getDiagnosticoInicial(), nuevaCirugia.getCodigoSala(), nuevaCirugia.getDiagnosticoFinal());
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
        public static void updateIngreso(Ingreso ingreso)
        {
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

        public static void putAlta(string codigoIngreso, DateTime fechaAlta, string diagnosticoFinal = "null")
        {
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
        public static void deleteIngreso(string codigoIngreso)
        {
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
