using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Cirugia
    {
        //ATRIBUTES
        private string CodigoCirugia;
        private DateTime FechaCirugia;
        private string DiagnosticoCirugia;
        private string DiagnosticoFinal;
        private int NumeroExpediente;
        private string CodigoSala;
        //LISTED ATRIBUTES
        private ArrayList Personal;

        public Cirugia(string codigoCirugia, DateTime fechaCirugia, string diagnosticoCirugia, string diagnosticoFinal, int numeroExpediente, string codigoSala)
        {
            CodigoCirugia = codigoCirugia;
            FechaCirugia = fechaCirugia;
            DiagnosticoCirugia = diagnosticoCirugia;
            DiagnosticoFinal = diagnosticoFinal;
            NumeroExpediente = numeroExpediente;
            CodigoSala = codigoSala;
        }
        public Cirugia() { }

        //GETTERS
        public string getCodigoCirugia() => this.CodigoCirugia;
        public DateTime getFechaCirugia() => this.FechaCirugia;
        public string getDiagnosticoCirugia() => this.DiagnosticoCirugia;
        public string getDiagnosticoFinal() => this.DiagnosticoFinal;
        public int getNumeroExpediente() => this.NumeroExpediente;
        public string getCodigoSala() => this.CodigoSala;

        //SETTERS
        public void setCodigoCirugia(string codigoCirugia) => this.CodigoCirugia = codigoCirugia;
        public void setFechaCirugia(DateTime fechaCirugia) => this.FechaCirugia = fechaCirugia;
        public void setDiagnostico(string diagnosticoCirugia) => this.DiagnosticoCirugia = diagnosticoCirugia;
        public void setDiagnosticoFinal(string diagnosticoFinal) => this.DiagnosticoFinal = diagnosticoFinal;
        public void setNumeroExpediente(int numeroExpediente) => this.NumeroExpediente = numeroExpediente;
        public void setCodigoSala(string codigoSala) => this.CodigoSala = codigoSala;

        //LISTED GETTERS
        public ArrayList getPersonal() => this.Personal;
        public object getPositionFromPersonal(int pos) => this.Personal[pos];
        public string[] getPersonaFromPersonal(string codigoDoctor) {
            foreach (string[] doctor in this.Personal)
            {
                if (codigoDoctor.Equals(doctor[0])) return doctor;
            }
            return null;
        }

        //LISTED SETTERS
        public void addPersonal(string codigoDoctor, string rolDoctor) {
            string[] persona = { codigoDoctor, rolDoctor };
            this.Personal.Add(persona);
        }
        public void setPersonal(int pos, string codigoDoctor, string rolDoctor) {
            string[] persona = { codigoDoctor, rolDoctor };
            this.Personal[pos] = persona;
        }
        public void updatePersonal(string codigoDoctor, string rolDoctor) {
            string[] persona = { codigoDoctor, rolDoctor };
            int pos = 0;
            foreach (string[] doctor in this.Personal)
            {
                if (codigoDoctor.Equals(doctor[0])) this.Personal[pos] = persona;
                else pos++;
            }
        }
        public void removePersonal(int pos) => this.Personal.RemoveAt(pos);
        public void removePersonal(string codigoDoctor) { 
            int pos = 0;
            foreach (string[] doctor in this.Personal)
            {
                if (codigoDoctor.Equals(doctor[0])) this.Personal.RemoveAt(pos);
                else pos++;
            }
        }

        //EXTENDED ATRIBUTES
        protected Expediente expedienteCirugia;
        protected SalaMedica salaCirugia;
        protected Dictionary<string,Doctor> personalCirugia;

        public Expediente getExpediente() => this.expedienteCirugia;
        public SalaMedica getSalaMedica() => this.salaCirugia;
        public Doctor getDoctor(string codigoDoctor) => personalCirugia[codigoDoctor];

        public void setExpediente(Expediente expediente)
        {
            if (expediente.getNumeroExpediente() == this.NumeroExpediente)
                this.expedienteCirugia = expediente;
        }
        public void setSalaMedica(SalaMedica salaMedica) { 
            if (salaMedica.getCodigoSala().Equals(this.CodigoSala))
                this.salaCirugia = salaMedica;
        }
        public void addDoctor(Doctor doctor) {
            bool OkDoctor = false;
            foreach (string[] doc in this.Personal)
            {
                if (doctor.getCodigoDoctor().Equals(doc[0]))
                    OkDoctor = true;
                    break;
            }
            if (doctor != null && OkDoctor)
                personalCirugia.Add(doctor.getCodigoDoctor(), doctor);
        }
        public void updateDoctor(Doctor doctor) {
            if (doctor != null && personalCirugia.ContainsKey(doctor.getCodigoDoctor()))
                personalCirugia[doctor.getCodigoDoctor()] = doctor;
        }
        public void removeDoctor(string codigoDoctor) {
            if (personalCirugia.ContainsKey(codigoDoctor))
                personalCirugia.Remove(codigoDoctor);
        }
    }
}
