using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías
{
    public partial class Tester : Form
    {
        public Tester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable dt = IngresoService.getIngresosActivos();
            dataGridView1.Rows.Clear();
            foreach (var dtRow in dt.Rows) 
            {
                dataGridView1.Rows.Add(dtRow);
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Tester_Load(object sender, EventArgs e)
        {

        }
    }
}
