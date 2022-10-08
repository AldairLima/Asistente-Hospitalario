using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Modelos
{
    public class Expediente : Persona
    {
        //ATRIBUTES
        private int NumeroExpediente;


        public Expediente(int numeroExpediente, string nombrePaciente, string DUIpaciente, int edadPaciente, char sexoPaciente) : base(DUIpaciente, nombrePaciente, edadPaciente, sexoPaciente)
        {
            this.NumeroExpediente = numeroExpediente;
        }

        public Expediente() { }

        //GETTERS
        public int getNumeroExpediente()  =>  this.NumeroExpediente;

        //SETTERS
        public void setNumeroExpediente(int numeroExpediente) => this.NumeroExpediente = numeroExpediente;


    }
        
}
