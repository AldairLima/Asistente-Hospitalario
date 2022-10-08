using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Ingreso : CasoMedico
    {
        //ATRIBUTES
        private string CodigoIngreso;
        private DateTime? FechaAlta;
        private string CodigoDoctor;
        private int NumeroCamilla;

        public Ingreso(string codigoIngreso, int numeroExpediente, DateTime fechaIngreso, string diagnostico, DateTime? fechaAlta, string codigoDoctor, string codigoSala, int numeroCamilla, string diagnosticoFinal) : base(numeroExpediente, fechaIngreso, diagnostico, diagnosticoFinal, codigoSala)
        {
            this.CodigoIngreso = codigoIngreso;
            this.FechaAlta = fechaAlta;
            this.CodigoDoctor = codigoDoctor;
            this.NumeroCamilla = numeroCamilla;
        }
        public Ingreso() { }

        //GETTERS
        public string getCodigoIngreso() => this.CodigoIngreso;
        public DateTime? getFechaAlta() => this.FechaAlta;
        public string getCodigoDoctor() => this.CodigoDoctor;
        public int getNumeroCamilla() => this.NumeroCamilla;

        //SETTERS
        public void setCodigoIngreso(string codigoIngreso) => this.CodigoIngreso = codigoIngreso;
        public void setFechaAlta(DateTime fechaAlta) => this.FechaAlta = fechaAlta;
        public void setCodigoDoctor(string codigoDoctor) => this.CodigoDoctor = codigoDoctor;
        public void setNumeroCamilla(int numeroCamilla) => this.NumeroCamilla = numeroCamilla;

        //EXTENDED ATRIBUTES
        protected Expediente ExpedienteIngreso;
        protected Doctor DoctorIngreso;
        protected SalaMedica SalaIngreso;

        public Expediente getExpediente() => this.ExpedienteIngreso;
        public Doctor getDoctor() => this.DoctorIngreso;
        public SalaMedica getSalaMedica() => this.SalaIngreso;

        public void setExpediente(Expediente expediente) { 
            if (expediente.getNumeroExpediente() == this.getNumeroExpediente())
                this.ExpedienteIngreso = expediente;
        }
        public void setDoctor(Doctor doctor)
        {
            if (doctor.getCodigoDoctor().Equals(this.CodigoDoctor))
                this.DoctorIngreso = doctor;
        }
        public void setSalaMedica(SalaMedica salaMedica) {
            if (salaMedica.getCodigoSala().Equals(this.getCodigoSala()))
                this.SalaIngreso = salaMedica;
        }

    }
}
