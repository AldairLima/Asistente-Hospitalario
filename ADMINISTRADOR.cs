using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
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
    public partial class ADMINISTRADOR : Form
    {
        private Usuario log;

        public void setLog(Usuario log) => this.log = log;

        public ADMINISTRADOR()
        {
            InitializeComponent();
        }

        private void ADMINISTRADOR_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = log.getNombre() + "\n" + log.getApellido();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInDoctor_Click(object sender, EventArgs e)
        {

        }

        private void btnInCirugias_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR_CIRUJIA_PACIENTE admSurg = new ADMINISTRADOR_CIRUJIA_PACIENTE();
            this.Hide();
            admSurg.setLog(this.log);
            admSurg.ShowDialog();
            this.Show();
        }

        private void btnInPaciente_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR_PACIENTE admPac = new ADMINISTRADOR_PACIENTE();
            this.Hide();
            admPac.setLog(this.log);
            admPac.ShowDialog();
            this.Show();
        }

        private void ADMINISTRADOR_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void mainInstance(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
