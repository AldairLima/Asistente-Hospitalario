using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using Microsoft.SqlServer.Server;
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

        public DoctorService() {  }

        public static DataTable getDoctors() {
            try
            {
                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
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
                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
                string query = string.Format("SELECT dt.CodigoDoctor, dt.CodigoUsuario, dt.CodigoEspecialidad,  sp.NombreEspecialidad FROM doctor as dt JOIN especialidad as sp ON dt.CodigoEspecialidad = sp.CodigoEspecialidad WHERE dt.CodigoDoctor = '{0}';", CodigoDoctor);
                MySqlCommand executer = new MySqlCommand(query, Conex);
                MySqlDataReader bruteData = executer.ExecuteReader();

                Doctor doctor = new Doctor(
                        bruteData.GetValue(0).ToString(),
                        bruteData.GetValue(1).ToString(), //Usuario
                        bruteData.GetValue(2).ToString() //Especialidad
                    );
                Usuario usuario = UsuarioService.getUsuarioByKey(bruteData.GetValue(1).ToString());
                Especialidad especialidad = new Especialidad(bruteData.GetValue(2).ToString(), bruteData.GetValue(4).ToString());

                doctor.setUsuario(usuario);
                doctor.setEspecialidad(especialidad);

                bruteData.Close();
                executer.Connection.Close();
                Conex.Close();
                bruteData.Dispose();
                executer.Dispose();
                Conex.Dispose();
                

                return doctor;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static void createDoctor(Doctor doctor, Usuario userD) {
            try
            {
                if (userD.getCodigoUsuario() == null && userD != null) UsuarioService.createUsuario(userD);

                MySqlConnection Conex = new MySqlConnection(Settings.Default.ConnectionString);
                Conex.Open();

                string codigoDoctor = null;
                if (userD.getCodigoUsuario() != null) codigoDoctor = doctor.getCodigoEspecialidad()[0].ToString() + userD.getCodigoUsuario();
                else codigoDoctor = doctor.getCodigoEspecialidad()[0].ToString() + UsuarioService.getUsuarioByKey(userD.getDUI()).getCodigoUsuario();

                
                string queryDoctor = string.Format("insert into doctor(CodigoDoctor, CodigoUsuario, CodigoEspecialidad) values('{0}','{1}','{2}');", doctor.getCodigoDoctor(), doctor.getCodigoUsuario(), doctor.getCodigoEspecialidad());
                MySqlCommand executer = new MySqlCommand(queryDoctor, Conex);
                executer.ExecuteNonQuery();
                executer.Connection.Close();
                executer.Dispose();

                Conex.Close();
                Conex.Dispose();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }
    }
}
