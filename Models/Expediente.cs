using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos
{
    public class Expediente
    {
        //ATRIBUTES
        private int NumeroExpediente;
        private string NombrePaciente;
        private string DUIPaciente;
        private int EdadPaciente;
        private char SexoPaciente;

        public Expediente(int numeroExpediente, string nombrePaciente, string DUIpaciente, int edadPaciente, char sexoPaciente)
        {
            this.NumeroExpediente = numeroExpediente;
            this.NombrePaciente = nombrePaciente;
            this.DUIPaciente = DUIpaciente;
            this.EdadPaciente = edadPaciente;
            this.SexoPaciente = sexoPaciente;
        }

        public Expediente() { }

        //GETTERS
        public int getNumeroExpediente()  { return this.NumeroExpediente; }
        public string getNombrePaciente() { return this.NombrePaciente;   }
        public string getDUIPaciente()    { return this.DUIPaciente;      }
        public int getEdadPaciente()      { return this.EdadPaciente;     }
        public string getSexoPaciente() {
            if (this.SexoPaciente.Equals('F'))
                return "Femenino";
            else if (this.SexoPaciente.Equals('M'))
                return "Masculino";
            else
                return null;
        }
        public char getCharSexoPaciente() { return this.SexoPaciente; } 

        //SETTERS
        public void setNumeroExpediente(int numeroExpediente) => this.NumeroExpediente = numeroExpediente;
        public void setNombrePaciente(string nombrePaciente)  => this.NombrePaciente = nombrePaciente;
        public void setDUIPaciente(string DUIpaciente)        => this.DUIPaciente = DUIpaciente;
        public void setEdadPaciente(int edadPaciente)         => this.EdadPaciente = edadPaciente;
        public void setSexoPaciente(char sexoPaciente)        => this.SexoPaciente = sexoPaciente;

    }
        
}
