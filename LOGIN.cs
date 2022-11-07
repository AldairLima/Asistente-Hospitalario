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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void alphaBlendTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        
        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LOGIN_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            cbbRango.SelectedIndex = -1;
            cbbRango.Text = "Rango";
            this.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length > 0 && txtContrasena.Text.Length > 0 && cbbRango.SelectedIndex >= 0)
            {
                Usuario logUsuario = UsuarioService.ValidateLogin(txtUsuario.Text, txtContrasena.Text, cbbRango.SelectedIndex + 1);
                if (logUsuario != null)
                {
                    switch (logUsuario.getRangoUsuario())
                    {
                        case 1:
                            ADMINISTRADOR sudoAdmin = new ADMINISTRADOR();
                            sudoAdmin.setLog(logUsuario);
                            sudoAdmin.FormClosed += Logout;
                            sudoAdmin.Show();
                            break;
                        case 2:
                            DOCTOR_PACIENTES docPac = new DOCTOR_PACIENTES();
                            docPac.setLog(logUsuario);
                            docPac.FormClosed += Logout;
                            docPac.Show();
                            break;
                        case 3:
                            ENFERMERA_SECRETARIA secretaria = new ENFERMERA_SECRETARIA();
                            secretaria.FormClosed += Logout;
                            secretaria.Show();
                            break;
                        default:
                            break;
                    }
                    this.Hide();
                }
            }

        }
    }
}
