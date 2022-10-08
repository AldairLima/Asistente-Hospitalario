using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models.Nodos
{
    public class CasoMedico
    {
        //ATRIBUTES
        private int NumeroExpediente;
        private DateTime FechaCaso;
        private string DiagnosticoInicial;
        private string DiagnosticoFinal;
        private string CodigoSala;

        public CasoMedico(int numeroExpediente, DateTime fechaCaso, string diagnosticoInicial, string diagnosticoFinal, string codigoSala)
        {
            this.NumeroExpediente = numeroExpediente;
            this.FechaCaso = fechaCaso;
            this.DiagnosticoInicial = diagnosticoInicial;
            this.DiagnosticoFinal = diagnosticoFinal;
            this.CodigoSala = codigoSala;
        }

        public CasoMedico() { }

        //GETTERS
        public int getNumeroExpediente() => this.NumeroExpediente;
        public DateTime getFechaCaso() => this.FechaCaso;
        public string getDiagnosticoInicial() => this.DiagnosticoInicial;
        public string getDiagnosticoFinal() => this.DiagnosticoFinal;
        public string getCodigoSala() => this.CodigoSala;

        //SETTERS
        public void setNumeroExpediente(int numeroExpediente) => this.NumeroExpediente = numeroExpediente;
        public void setFechaCaso(DateTime fechaCaso) => this.FechaCaso = fechaCaso;
        public void setDiagnosticoInicial(string diagnosticoInicial) => this.DiagnosticoInicial = diagnosticoInicial;
        public void setDiagnosticoFinal(string diagnosticoFinal) => this.DiagnosticoFinal = diagnosticoFinal;
        public void setCodigoSala(string codigoSala) => this.CodigoSala = codigoSala;
    }
}
