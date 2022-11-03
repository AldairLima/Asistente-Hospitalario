using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías
{
    public partial class DOCTOR_ALTAS : Form
    {
        private Usuario log;

        public DOCTOR_ALTAS()
        {
            InitializeComponent();
        }

        public void setLog(Usuario log) => this.log = log;

        private void reloadTable()
        {
            dgvAltas.Rows.Clear();
            foreach (DataRow ingreso in IngresoService.getAltas().Rows)
            {
                string[] row = { ingreso[0].ToString(), ingreso[1].ToString(), ingreso[2].ToString(), ingreso[3].ToString(), ingreso[4].ToString(), ingreso[5].ToString() };
                dgvAltas.Rows.Add(row);
            }
            dgvAltas.ClearSelection();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void DOCTOR_ALTAS_Load(object sender, EventArgs e)
        {
            reloadTable();
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            DOCTOR_PACIENTES pacients = new DOCTOR_PACIENTES();
            this.Hide();
            pacients.setLog(this.log);
            pacients.ShowDialog();
            this.Close();
        }

        private void btnCirugias_Click(object sender, EventArgs e)
        {
            DOCTOR_CIRUGÍAS surgeon = new DOCTOR_CIRUGÍAS();
            this.Hide();
            surgeon.setLog(this.log);
            surgeon.ShowDialog();
            this.Close();
        }

        private void dgvAltas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAltas.SelectedRows.Count > 0)
                dgvAltas.ClearSelection();
        }

        private void dgvAltas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int nexp = int.Parse(dgvAltas.SelectedRows[0].Cells[0].Value.ToString());
            //ExpedienteCaso carpeta = new ExpedienteCaso();
            //carpeta.setCarpeta(ExpedienteService.getExpedienteByKey(nexp));
            //carpeta.ShowDialog();
            //reloadTable();
        }
    }
}
