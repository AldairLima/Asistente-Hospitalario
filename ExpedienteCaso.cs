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
    public partial class ExpedienteCaso : Form
    {
        private Expediente expediente;

        public ExpedienteCaso()
        {
            InitializeComponent();
        }

        public void setCarpeta(Expediente expediente) => this.expediente = expediente;

        private void reloadTable()
        {
            dgvExpediente.Rows.Clear();
            foreach (Ingreso ingreso in IngresoService.getIngresosFor(this.expediente.getNumeroExpediente()))
            {
                Usuario doc = DoctorService.getDoctorByCodigo(ingreso.getCodigoDoctor()).getUsuario();
                string[] row = { ingreso.getFechaCaso().ToString("dd-MM-yyyyy"), ingreso.getCodigoSala(), ingreso.getDiagnosticoInicial(), doc.getNombre() + " " + doc.getApellido(), ingreso.getDiagnosticoFinal() };
                dgvExpediente.Rows.Add(row);
            }
            dgvExpediente.ClearSelection();
        }


        private void ExpedienteCaso_Load(object sender, EventArgs e)
        {
            lblNombre.Text = this.expediente.getNombre() + " " + this.expediente.getApellido();
            lblExp.Text = "N° EXPEDIENTE: " + this.expediente.getNumeroExpediente().ToString("D8");
            reloadTable();
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            Ingreso activo = IngresoService.getIngresoActivo(this.expediente.getNumeroExpediente());
            IngresoService.putAlta(activo.getCodigoIngreso(), DateTime.Now);
            this.Close();
        }
    }
}
