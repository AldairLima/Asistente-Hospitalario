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
    public partial class ADMINISTRADOR_CIRUJIA_PACIENTE : Form
    {
        private Usuario log;

        public ADMINISTRADOR_CIRUJIA_PACIENTE()
        {
            InitializeComponent();
        }

        public void setLog(Usuario inlog) => this.log = inlog;

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ADMINISTRADOR_CIRUJIA_PACIENTE_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = log.getNombre() + "\n" + log.getApellido();
        }

        private void btnInPaciente_Click(object sender, EventArgs e)
        {
            ADMINISTRADOR_PACIENTE admPac = new ADMINISTRADOR_PACIENTE();
            admPac.setLog(this.log);
            admPac.FormClosed += mainInstance;
            this.Hide();
            admPac.Show();
        }

        private void ADMINISTRADOR_CIRUJIA_PACIENTE_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void mainInstance(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
