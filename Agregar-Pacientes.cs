using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Services.Miscellaneous;
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
    public partial class Agregar_Pacientes : Form
    {
        private Ingreso paciente;

        public Agregar_Pacientes()
        {
            InitializeComponent();
        }

        public void setPaciente(Ingreso paciente) => this.paciente = paciente;

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

        private void LOAD_EXPEDIENTE(int nexp)
        {
            try
            {
                Expediente expediente = ExpedienteService.getExpedienteByKey(nexp);

                if (expediente == null)
                {
                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtEdad.Text = "";
                    cbbSexo.SelectedIndex = -1;
                }
                else
                {
                    txtNombre.Text = expediente.getNombre();
                    txtApellidos.Text = expediente.getApellido();
                    txtEdad.Text = expediente.getEdad().ToString("D2");
                    //GENERO
                    if (expediente.getCharSexo().Equals('F')) cbbSexo.SelectedIndex = 1;
                    else if (expediente.getCharSexo().Equals('M')) cbbSexo.SelectedIndex = 0;
                }
            }
            catch (Exception) { }
        }

        private void LOAD_CAMILLAS()
        {
            try
            {
                SalaMedica ss = SalaService.getSalaByKey(cbbSala.SelectedValue.ToString());
                ArrayList ingresosSala = IngresoService.getIngresosByRoom(cbbSala.SelectedValue.ToString());
                int[] NoDisponibles = new int[ss.getNumeroCamillas()];
                for (int i = 0; i < ss.getNumeroCamillas(); i++)
                {
                    NoDisponibles[i] = i+1;
                }
                foreach (Ingreso exp in ingresosSala)
                {
                    for (int i = 0; i < ss.getNumeroCamillas(); i++)
                    {
                        if (exp.getNumeroCamilla() == NoDisponibles[i])
                        {
                            NoDisponibles[i] = -1;
                            break;
                        }
                    }
                }
                ingresosSala = null;
                int pos = 0; cbbCamilla.Items.Clear();
                for (int i = 0; i < ss.getNumeroCamillas(); i++)
                {
                    if (NoDisponibles[i] != -1)
                    {
                        cbbCamilla.Items.Add(i.ToString("D3"));
                        pos++;
                    }

                    if (pos == ss.getDisponibles())
                    {
                        break;
                    }
                }
                NoDisponibles = null;
                ss = null;
            }
            catch (Exception) { }
        }

        private void LOAD_DOCTORES() 
        {
            try
            {
                cbbDoctor.Items.Clear();
                ArrayList docs = new ArrayList();
                docs = DoctorService.getDoctoresByEspecialidad(cbbEspecialidad.SelectedItem.ToString());
                foreach (Doctor doc in docs)
                {
                    string option = doc.getCodigoDoctor() + ": " + doc.getUsuario().getNombre() + " " + doc.getUsuario().getApellido();
                    cbbDoctor.Items.Add(option);
                }
                cbbDoctor.SelectedIndex = -1;
            }
            catch (Exception) { }
        }

        private void Agregar_Pacientes_Load(object sender, EventArgs e)
        {
            try
            {
                ArrayList salas = SalaService.getSalasDisponibles();
                foreach (SalaMedica ss in salas)
                {   cbbSala.Items.Add(ss.getCodigoSala()); }
                cbbSala.SelectedIndex = -1; salas = null;
                ArrayList especialidades = EspecialidadService.getAll();
                foreach (Especialidad sp in especialidades)
                {   cbbEspecialidad.Items.Add(sp.Nombre); }
                cbbEspecialidad.SelectedIndex = -1; especialidades = null;
                ArrayList expedientes = ExpedienteService.getAllExpedientes();
                foreach (Expediente exp in expedientes)
                {   cbbExpediente.Items.Add(exp.getNumeroExpediente().ToString("D8")); }
                cbbExpediente.SelectedIndex = -1; expedientes = null;
                dtpFecha.Value = DateTime.Now;
                if (this.paciente.getCodigoIngreso() != null)
                {
                    cbbExpediente.SelectedValue = this.paciente.getNumeroExpediente().ToString("D8");
                    LOAD_EXPEDIENTE(this.paciente.getNumeroExpediente());
                    cbbSala.SelectedValue = this.paciente.getCodigoSala();
                    LOAD_CAMILLAS();
                    cbbCamilla.Items.Add(this.paciente.getNumeroCamilla().ToString("D3"));
                    cbbCamilla.SelectedValue = this.paciente.getNumeroCamilla().ToString("D3");
                    Doctor thisDoc = DoctorService.getDoctorByCodigo(this.paciente.getCodigoDoctor());
                    cbbEspecialidad.SelectedValue = thisDoc.getEspecialidad().Nombre;
                    LOAD_DOCTORES();
                    cbbDoctor.SelectedValue = thisDoc.getCodigoDoctor() + ": " + thisDoc.getUsuario().getNombre() + " " + thisDoc.getUsuario().getApellido();
                    txtCaso.Text = this.paciente.getDiagnosticoInicial();
                    dtpFecha.Value = this.paciente.getFechaCaso();
                }
            }
            catch (Exception) { }
        }

        private void cbbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_DOCTORES();
        }

        private void cbbSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_CAMILLAS();
        }

        private void cbbExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(cbbExpediente.SelectedValue.ToString());
                LOAD_EXPEDIENTE(num);
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.paciente = null;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar_Pacientes_EXPEDIENTE NUEVO = new Agregar_Pacientes_EXPEDIENTE();
            this.Hide();
            NUEVO.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.paciente.getCodigoIngreso() == null) this.paciente = new Ingreso();

            try
            {
                this.paciente.setCodigoSala(cbbSala.SelectedValue.ToString());
                this.paciente.setDiagnosticoInicial(txtCaso.Text);
                this.paciente.setFechaCaso(dtpFecha.Value);
                int camilla = int.Parse(cbbCamilla.SelectedValue.ToString()), exp = int.Parse(cbbExpediente.SelectedValue.ToString());
                this.paciente.setNumeroCamilla(camilla);
                this.paciente.setNumeroExpediente(exp);
                string[] docName = cbbDoctor.SelectedValue.ToString().Split(':');
                this.paciente.setCodigoDoctor(docName[0]);

                if (this.paciente.getCodigoIngreso() == null)
                {
                    IngresoService.updateIngreso(this.paciente);
                }
                else
                {
                    IngresoService.createIngreso(this.paciente);
                }
            }
            catch (Exception) { }            
        }
    }
}
