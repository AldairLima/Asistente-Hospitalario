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
    public partial class DOCTOR_CIRUGÍAS : Form
    {
        private Usuario log;

        public DOCTOR_CIRUGÍAS()
        {
            InitializeComponent();
        }

        public void setLog(Usuario log) => this.log = log;

        private void reloadTable()
        {
            dgvCirugias.Rows.Clear();
            foreach (DataRow cirugia in CirugiaService.getAllCirugias().Rows)
            {
                string[] row = { cirugia[0].ToString(), cirugia[1].ToString(), cirugia[2].ToString(), cirugia[3].ToString(), cirugia[4].ToString(), cirugia[5].ToString() };
                dgvCirugias.Rows.Add(row);
            }
            dgvCirugias.ClearSelection();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DOCTOR_CIRUGÍAS_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = log.getNombre() + "\n" + log.getApellido();
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

        private void btnAltas_Click(object sender, EventArgs e)
        {
            DOCTOR_ALTAS altas = new DOCTOR_ALTAS();
            this.Hide();
            altas.setLog(this.log);
            altas.ShowDialog();
            this.Close();
        }
    }
}
