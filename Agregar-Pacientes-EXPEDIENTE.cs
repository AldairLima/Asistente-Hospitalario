using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías
{
    public partial class Agregar_Pacientes_EXPEDIENTE : Form
    {
        private Expediente thisExpediente = null;

        public Agregar_Pacientes_EXPEDIENTE()
        {
            InitializeComponent();
        }

        public void setExpediente(Expediente expediente) => this.thisExpediente = expediente;

        private void Agregar_Pacientes_EXPEDIENTE_Load(object sender, EventArgs e)
        {
            if (this.thisExpediente != null)
            {
                txtExpediente.Visible = true;
                lblExpediente.Visible = true;
                txtNombre.Text = this.thisExpediente.getNombre();
                txtApellido.Text = this.thisExpediente.getApellido();
                txtDUI.Text = this.thisExpediente.getDUI();
                txtEdad.Text = this.thisExpediente.getEdad().ToString("D2");
                txtExpediente.Text = this.thisExpediente.getNumeroExpediente().ToString("D8");
                if (this.thisExpediente.getCharSexo().Equals('F'))
                {
                    cbbSexo.SelectedIndex = 1;
                }
                else
                {
                    cbbSexo.SelectedIndex = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.thisExpediente = null;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int numExp, edad;
            string duiPattern = "[0-9]{8}-[0-9]";

            if (txtNombre.Text.Length > 0 && txtApellido.Text.Length > 0 && Regex.IsMatch(txtDUI.Text, duiPattern) && cbbSexo.SelectedIndex > -1 && int.TryParse(txtEdad.Text, out edad))
            {
                if (this.thisExpediente == null) this.thisExpediente = new Expediente(); 
                this.thisExpediente.setNombre(txtNombre.Text);
                this.thisExpediente.setApellido(txtApellido.Text);
                this.thisExpediente.setEdad(edad);
                this.thisExpediente.setDUI(txtDUI.Text);
                if (cbbSexo.SelectedIndex == 0)
                    this.thisExpediente.setSexo('M');
                else if (cbbSexo.SelectedIndex == 1)
                    this.thisExpediente.setSexo('F');
                

                if (this.thisExpediente.getNumeroExpediente() > 0)
                {
                    ExpedienteService.updateExpediente(this.thisExpediente);
                }
                else
                {
                    ExpedienteService.createExpediente(this.thisExpediente);
                }
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDUI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                if (txtDUI.Text.Length == 7 && !txtDUI.Text.Contains("-"))
                {
                    txtDUI.Text += "-";
                    txtDUI.Select(8,0);
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
