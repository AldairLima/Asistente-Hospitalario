using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services;
using System;
using System.Collections;
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
    public partial class ADMINISTRADOR_PACIENTE : Form
    {
        private Usuario log;
        private ArrayList expedientes;

        public ADMINISTRADOR_PACIENTE()
        {
            InitializeComponent();
        }

        public void setLog(Usuario inlog) => this.log = inlog;

        private void reloadTable() {
            dgvPacientes.Rows.Clear();
            foreach (Expediente exp in ExpedienteService.getAllExpedientes())
            {
                string[] row = { exp.getNumeroExpediente().ToString("D8"), exp.getNombre(), exp.getApellido(), exp.getDUI(), exp.getEdad().ToString("D2"), exp.getSexo() };
                dgvPacientes.Rows.Add(row);
            }
            dgvPacientes.ClearSelection();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ADMINISTRADOR_PACIENTE_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = log.getNombre() + "\n" + log.getApellido();
            reloadTable();
        }

        private void ADMINISTRADOR_PACIENTE_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnInCirujia_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR_CIRUJIA_PACIENTE admSurg = new ADMINISTRADOR_CIRUJIA_PACIENTE();
            admSurg.setLog(this.log);
            this.Hide();
            admSurg.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Pacientes_EXPEDIENTE NUEVO = new Agregar_Pacientes_EXPEDIENTE();
            NUEVO.ShowDialog();
            reloadTable();
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count > 1)
                dgvPacientes.ClearSelection();
            
        }

        private void dgvPacientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nexp = int.Parse(dgvPacientes.SelectedRows[0].Cells[0].Value.ToString());
            Agregar_Pacientes_EXPEDIENTE UPD = new Agregar_Pacientes_EXPEDIENTE();
            UPD.setExpediente(ExpedienteService.getExpedienteByKey(nexp));
            UPD.Show();
            reloadTable();
            dgvPacientes.ClearSelection();   
        }
    }
}
