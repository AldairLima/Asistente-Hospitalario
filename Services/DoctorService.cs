using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class DoctorService
    {

        public DoctorService() {  }

        //CONSULTAR
        public static DataTable getDoctors() {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                string query = "";
                MySqlDataAdapter bruteData = new MySqlDataAdapter(query, Conex);

                DataTable doctores = new DataTable();
                bruteData.Fill(doctores);

                bruteData.Dispose();

                return doctores;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally 
            {
                Conex.Close();
                Conex.Dispose();
            }
        }

        public static Doctor getDoctorByCodigo(string CodigoDoctor) {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                
                string query = string.Format("SELECT dt.CodigoDoctor, dt.CodigoUsuario, dt.CodigoEspecialidad,  sp.NombreEspecialidad FROM doctor as dt JOIN especialidad as sp ON dt.CodigoEspecialidad = sp.CodigoEspecialidad WHERE dt.CodigoDoctor = '{0}';", CodigoDoctor);
                MySqlCommand executer = new MySqlCommand(query, Conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Doctor doctor = null;
                if (bruteData.HasRows)
                {
                    bruteData.Read();
                    doctor = new Doctor(
                        bruteData.GetString(0),
                        bruteData.GetString(1), //Usuario
                        bruteData.GetString(2) //Especialidad
                    );
                    Usuario usuario = UsuarioService.getUsuarioByKey(bruteData.GetString(1));
                    Especialidad especialidad = new Especialidad(bruteData.GetString(2), bruteData.GetString(4));

                    doctor.setUsuario(usuario);
                    doctor.setEspecialidad(especialidad);

                    bruteData.Close();
                    bruteData.Dispose();
                    executer.Connection.Close();
                    executer.Dispose();
                }

                return doctor;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Conex.Close();
                Conex.Dispose();
            }
        }


        public static ArrayList getDoctoresByEspecialidad(string AreaEspecialidad)
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                ArrayList doctores = new ArrayList();
                string query = string.Format("SELECT dt.CodigoDoctor, dt.CodigoUsuario, dt.CodigoEspecialidad FROM doctor as dt JOIN especialidad as sp ON dt.CodigoEspecialidad = sp.CodigoEspecialidad WHERE sp.NombreEspecialidad = '{0}';", AreaEspecialidad);
                MySqlCommand executer = new MySqlCommand(query, Conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                if (bruteData.HasRows)
                {
                    while (bruteData.Read())
                    {
                        Doctor doctor = new Doctor(
                        bruteData.GetString(0),
                        bruteData.GetString(1), //Usuario
                        bruteData.GetString(2) //Especialidad
                        );
                        Usuario usuario = UsuarioService.getUsuarioByKey(bruteData.GetString(1));
                        Especialidad especialidad = new Especialidad(bruteData.GetString(2), AreaEspecialidad);

                        doctor.setUsuario(usuario);
                        doctor.setEspecialidad(especialidad);

                        doctores.Add(doctor);
                    }
                    bruteData.Close();
                    bruteData.Dispose();
                    executer.Connection.Close();
                    executer.Dispose();
                }

                return doctores;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Conex.Close();
                Conex.Dispose();
            }
        }
        //INSERT
        public static void createDoctor(Doctor doctor, Usuario userD) 
        {
            if (userD.getCodigoUsuario() == null && userD != null) UsuarioService.createUsuario(userD);

            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {
                
                string codigoDoctor = null;
                if (userD.getCodigoUsuario() != null) codigoDoctor = doctor.getCodigoEspecialidad()[0].ToString() + userD.getCodigoUsuario();
                else codigoDoctor = doctor.getCodigoEspecialidad()[0].ToString() + UsuarioService.getUsuarioByKey(userD.getDUI()).getCodigoUsuario();

                
                string queryDoctor = string.Format("insert into doctor(CodigoDoctor, CodigoUsuario, CodigoEspecialidad) values('{0}','{1}','{2}');", doctor.getCodigoDoctor(), doctor.getCodigoUsuario(), doctor.getCodigoEspecialidad());
                MySqlCommand executer = new MySqlCommand(queryDoctor, Conex);
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
                Conex.Close();
                Conex.Dispose();
            }
        }

        //UPDATE
        public static void updateDoctor(Doctor doctor) 
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {

                string queryDoctor = string.Format("update doctor set CodigoUsuario='{1}', CodigoEspecialidad='{2}' where CodigoDoctor='{0}';", 
                    doctor.getCodigoDoctor(), doctor.getCodigoUsuario(), doctor.getCodigoEspecialidad());
                MySqlCommand executer = new MySqlCommand(queryDoctor, Conex);
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
                Conex.Close();
                Conex.Dispose();
            }
        }

        //DELETE
        public static void deleteDoctor(string codigoDoctor) 
        {
            MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
            Conex.Open();
            try
            {

                string queryDoctor = string.Format("delete from doctor where CodigoDoctor='{0}';", codigoDoctor);
                MySqlCommand executer = new MySqlCommand(queryDoctor, Conex);
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
                Conex.Close();
                Conex.Dispose();
            }
        }    
    }
}
