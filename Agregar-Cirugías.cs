﻿using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
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
    public partial class Agregar_Cirugías : Form
    {
        private Cirugia cirugia = null;

        public void setCirugia(Cirugia cirugia) => this.cirugia = cirugia;

        private void LOAD_EXPEDIENTE() {
            try
            {
                int nexp = int.Parse(txtExpediente.Text);
                Expediente expediente = ExpedienteService.getExpedienteByKey(nexp);
                txtPaciente.Text = expediente.getNombre() + " " + expediente.getApellido();
                txtEdad.Text = expediente.getEdad().ToString("D2");
                //GENERO
                if (expediente.getCharSexo().Equals('F')) cbbSexo.SelectedIndex = 1;
                else if (expediente.getCharSexo().Equals('M')) cbbSexo.SelectedIndex = 0;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            } 
        }

        private void LOAD_DOCTORES()
        {
            try
            {
                ArrayList docs = new ArrayList();
                docs = DoctorService.getDoctoresByEspecialidad(cbbArea.SelectedValue.ToString());
                foreach (Doctor doc in docs)
                {
                    string option = doc.getCodigoDoctor() + ": " + doc.getUsuario().getNombre() + " " + doc.getUsuario().getApellido();
                    cbbDoctor.Items.Add(option);
                }
                cbbDoctor.SelectedIndex = -1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public Agregar_Cirugías()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.cirugia = null;
            this.Close();
        }

        private void Agregar_Cirugías_Load(object sender, EventArgs e)
        {
            ArrayList Salas = new ArrayList();
            Salas = SalaService.getSalasDisponibles();
            foreach (SalaMedica sala in Salas) { 
                cbbSala.Items.Add(sala.getCodigoSala());
            }
            cbbSala.SelectedIndex = -1;
            
            ArrayList areasMeds = new ArrayList();
            areasMeds = EspecialidadService.getAll();
            foreach (Especialidad esp in areasMeds)
            {
                cbbArea.Items.Add(esp.Nombre);
            }
            cbbArea.SelectedIndex = -1;
            cbbDoctor.Items.Clear();
            if (this.cirugia != null)
            {
                lblCirugia.Visible = true;
                txtCodigo.Text = this.cirugia.getCodigoCirugia();
                txtCodigo.Visible = true;
                txtExpediente.Text = this.cirugia.getNumeroExpediente().ToString("D8");
                LOAD_EXPEDIENTE();
                txtCaso.Text = this.cirugia.getDiagnosticoInicial();
                cbbSala.SelectedItem = this.cirugia.getCodigoSala();
                cbbArea.SelectedIndex = 0;
                LOAD_DOCTORES();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.cirugia == null) this.cirugia = new Cirugia();
            this.cirugia.setFechaCaso(dtpFecha.Value);
            this.cirugia.setNumeroExpediente(int.Parse(txtExpediente.Text));
            this.cirugia.setCodigoSala(cbbSala.SelectedValue.ToString());
            this.cirugia.setDiagnosticoInicial(txtCaso.Text);
            string[] codigoDoctor = cbbDoctor.SelectedValue.ToString().Split(':');
            this.cirugia.addPersonal(codigoDoctor[0], "Cirujano Principal");
            if (this.cirugia.getCodigoCirugia().Length > 0)
            {
                CirugiaService.updateCirugia(this.cirugia);
            }
            else
            {
                CirugiaService.createCirugia(this.cirugia);
            }
        }

        private void cbbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_DOCTORES();
        }
    }
}
