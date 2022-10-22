using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services
{
    public class SalaService
    {
        public SalaService() { }

        //CONSULTA

        public static ArrayList getSalaDisponible() {
            try
            {
                ArrayList salasdisponibles = new ArrayList();

                MySqlConnection conex = new MySqlConnection(Settings.Default.ConnectionString);
                conex.Open();

                string SQLQuery = "";
                MySqlDataAdapter executer = new MySqlDataAdapter(SQLQuery, conex);
                DataTable bruteData = new DataTable();
                executer.Fill(bruteData);

                if (bruteData.Rows.Count > 0)
                {
                    foreach (DataRow thisRow in bruteData.Rows)
                    {
                        int disponibles;
                        if (disponibles > 0)
                        {
                            SalaMedica saladisponible = new SalaMedica(thisRow[0].ToString(),
                            int.Parse(thisRow[1].ToString()), int.Parse(thisRow[2].ToString()), thisRow[3].ToString(), disponibles);
                            salasdisponibles.add(saladisponible);
                        }
                    }
                }

                executer.Dispose();
                conex.Close();
                return salasdisponibles;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
                throw;
            }
        }
        
    }
}
