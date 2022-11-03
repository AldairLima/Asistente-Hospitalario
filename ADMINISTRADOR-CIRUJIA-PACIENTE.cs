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
    public partial class ADMINISTRADOR_CIRUJIA_PACIENTE : Form
    {
        private Usuario log;

        public ADMINISTRADOR_CIRUJIA_PACIENTE()
        {
            InitializeComponent();
        }

        public void setLog(Usuario inlog) => this.log = inlog;

        private void reloadTable() {
            dgvCirugia.Rows.Clear();
            foreach (DataRow surg in CirugiaService.getAllCirugias().Rows)
            {
                string[] row = { surg[0].ToString(), surg[1].ToString(), surg[2].ToString(), surg[3].ToString(), surg[4].ToString(), surg[5].ToString(), surg[6].ToString(), surg[7].ToString() };
                dgvCirugia.Rows.Add(row);
            }
            dgvCirugia.ClearSelection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ADMINISTRADOR_CIRUJIA_PACIENTE_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = log.getNombre() + "\n" + log.getApellido();
            reloadTable();
        }

        private void btnInPaciente_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR_PACIENTE admPac = new ADMINISTRADOR_PACIENTE();
            admPac.setLog(this.log);
            this.Hide();
            admPac.ShowDialog();
            this.Close();
        }

        private void ADMINISTRADOR_CIRUJIA_PACIENTE_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnThis_Click(object sender, EventArgs e)
        {
            reloadTable();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Agregar_Cirugías NUEVO = new Agregar_Cirugías();
            NUEVO.ShowDialog();
            reloadTable();
        }
    }
}
