using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Ingreso
    {
        //ATRIBUTES
        private string CodigoIngreso;
        private int NumeroExpediente;
        private DateTime FechaIngreso;
        private string Diagnostico;
        private DateTime? FechaAlta;
        private string CodigoDoctor;
        private string CodigoSala;
        private int NumeroCamilla;
        private string DiagnosticoFinal;

        public Ingreso(string codigoIngreso, int numeroExpediente, DateTime fechaIngreso, string diagnostico, DateTime? fechaAlta, string codigoDoctor, string codigoSala, int numeroCamilla, string diagnosticoFinal)
        {
            CodigoIngreso = codigoIngreso;
            NumeroExpediente = numeroExpediente;
            FechaIngreso = fechaIngreso;
            Diagnostico = diagnostico;
            FechaAlta = fechaAlta;
            CodigoDoctor = codigoDoctor;
            CodigoSala = codigoSala;
            NumeroCamilla = numeroCamilla;
            DiagnosticoFinal = diagnosticoFinal;
        }
        public Ingreso() { }

        //GETTERS
        public string getCodigoIngreso() => this.CodigoIngreso;
        public int getNumeroExpediente() => this.NumeroExpediente;
        public DateTime getFechaIngreso() => this.FechaIngreso;
        public string getDiagnostico() => this.Diagnostico;
        public DateTime? getFechaAlta() => this.FechaAlta;
        public string getCodigoDoctor() => this.CodigoDoctor;
        public string getCodigoSala() => this.CodigoSala;
        public int getNumeroCamilla() => this.NumeroCamilla;
        public string getDiagnosticoFinal() => this.DiagnosticoFinal;

        //SETTERS
        public void setCodigoIngreso(string codigoIngreso) => this.CodigoIngreso = codigoIngreso;
        public void setNumeroExpediente(int numeroExpediente) => this.NumeroExpediente = numeroExpediente;
        public void setFechaIngreso(DateTime fechaIngreso) => this.FechaIngreso = fechaIngreso;
        public void setDiagnostico(string diagnostico) => this.Diagnostico = diagnostico;
        public void setFechaAlta(DateTime fechaAlta) => this.FechaAlta = fechaAlta;
        public void setCodigoDoctor(string codigoDoctor) => this.CodigoDoctor = codigoDoctor;
        public void setCodigoSala(string codigoSala) => this.CodigoSala = codigoSala;
        public void setNumeroCamilla(int numeroCamilla) => this.NumeroCamilla = numeroCamilla;
        public void setDiagnosticoFinal(string diagnosticoFinal) => this.DiagnosticoFinal = diagnosticoFinal;

        //EXTENDED ATRIBUTES
        protected Expediente ExpedienteIngreso;
        protected Doctor DoctorIngreso;
        protected SalaMedica SalaIngreso;

        public Expediente getExpediente() => this.ExpedienteIngreso;
        public Doctor getDoctor() => this.DoctorIngreso;
        public SalaMedica getSalaMedica() => this.SalaIngreso;

        public void setExpediente(Expediente expediente) { 
            if (expediente.getNumeroExpediente() == this.NumeroExpediente)
                this.ExpedienteIngreso = expediente;
        }
        public void setDoctor(Doctor doctor)
        {
            if (doctor.getCodigoDoctor().Equals(this.CodigoDoctor))
                this.DoctorIngreso = doctor;
        }
        public void setSalaMedica(SalaMedica salaMedica) {
            if (salaMedica.getCodigoSala().Equals(this.CodigoSala))
                this.SalaIngreso = salaMedica;
        }

    }
}
