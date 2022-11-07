using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
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
    public partial class DOCTOR_PACIENTES : Form
    {
        private Usuario log;

        public DOCTOR_PACIENTES()
        {
            InitializeComponent();
        }

        public void setLog(Usuario Log) => this.log = Log;

        private void reloadTable()
        {
            dgvPacientes.Rows.Clear();
            foreach (DataRow ingreso in IngresoService.getIngresosActivos().Rows)
            {
                string[] row = { ingreso[0].ToString(), ingreso[1].ToString(), ingreso[2].ToString(), ingreso[3].ToString(), ingreso[4].ToString(), ingreso[5].ToString() };
                dgvPacientes.Rows.Add(row);
            }
            dgvPacientes.ClearSelection();
        }

        private void DOCTOR_PACIENTES_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = log.getNombre() + "\n" + log.getApellido();
            reloadTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 0)
                dgvPacientes.ClearSelection();
        }

        private void dgvPacientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nexp = int.Parse(dgvPacientes.SelectedRows[0].Cells[0].Value.ToString());
            ExpedienteCaso carpeta = new ExpedienteCaso();
            carpeta.setCarpeta(ExpedienteService.getExpedienteByKey(nexp));
            carpeta.ShowDialog();
            reloadTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAltas_Click(object sender, EventArgs e)
        {
            DOCTOR_ALTAS altas = new DOCTOR_ALTAS();
            this.Hide();
            altas.setLog(this.log);
            altas.ShowDialog();
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
    }
}
