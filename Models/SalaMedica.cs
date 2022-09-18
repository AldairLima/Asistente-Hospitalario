using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class SalaMedica
    {
        //ATRIBUTES
        private string CodigoSala;
        private int NumeroPiso;
        private int NumeroHabitacion;
        private string CodigoAreaMedica;
        private int NumeroCamillas;
        private int Disponibles;

        public SalaMedica(string codigoSala, int numeroPiso, int numeroHabitacion, string codigoAreaMedica, int numeroCamillas, int disponibles)
        {
            CodigoSala = codigoSala;
            NumeroPiso = numeroPiso;
            NumeroHabitacion = numeroHabitacion;
            CodigoAreaMedica = codigoAreaMedica;
            NumeroCamillas = numeroCamillas;
            Disponibles = disponibles;
        }
        public SalaMedica() { }

        //GETTERS
        public string getCodigoSala() => this.CodigoSala;
        public int getNumeroPiso() => this.NumeroPiso;
        public int getNumeroHabitacion() => this.NumeroHabitacion;
        public string getCodigoAreaMedica() => this.CodigoAreaMedica;
        public int getNumeroCamillas() => this.NumeroCamillas;
        public int getDisponibles() => this.Disponibles;

        //SETTERS
        public void setCodigoSala(string codigoSala) => this.CodigoSala = codigoSala;
        public void setNumeroPiso(int numeroPiso) => this.NumeroPiso = numeroPiso;
        public void setNumeroHabitacion(int numeroHabitacion) => this.NumeroHabitacion = numeroHabitacion;
        public void setCodigoAreaMedica(string codigoAreaMedica) => this.CodigoAreaMedica = codigoAreaMedica;
        public void setNumeroCamillas(int numeroCamillas) => this.NumeroCamillas = numeroCamillas;
        public void setDisponibles(int disponibles) => this.Disponibles = disponibles;

        //EXTENDED ATRIBUTE (PROVISIONAL)
        protected AreaMedica AreaMedicaSala;
        public AreaMedica getAreaMedica() => this.AreaMedicaSala;
        public void setAreaMedica(AreaMedica areaMedica) {
            if (areaMedica.Codigo.Equals(this.CodigoAreaMedica))
                this.AreaMedicaSala = areaMedica;
        }
    }
}
