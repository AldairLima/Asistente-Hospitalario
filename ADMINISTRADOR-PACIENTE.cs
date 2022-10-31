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
    public partial class ADMINISTRADOR_PACIENTE : Form
    {
        private Usuario log;

        public ADMINISTRADOR_PACIENTE()
        {
            InitializeComponent();
        }

        public void setLog(Usuario inlog) => this.log = inlog;

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
        }

        private void ADMINISTRADOR_PACIENTE_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void mainInstance(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnInCirujia_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR_CIRUJIA_PACIENTE admSurg = new ADMINISTRADOR_CIRUJIA_PACIENTE();
            admSurg.setLog(this.log);
            admSurg.FormClosed += mainInstance;
            this.Hide();
            admSurg.Show();
        }
    }
}
