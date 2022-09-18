using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Especialidad
    {
        //ATRIBUTES
        private string CodigoEspecialidad;
        private string NombreEspecialidad;

        public Especialidad(string codigoEspecialidad, string nombreEspecialidad)
        {
            CodigoEspecialidad = codigoEspecialidad;
            NombreEspecialidad = nombreEspecialidad;
        }
        public Especialidad() { }

        public string Codigo { get => this.CodigoEspecialidad; set => this.CodigoEspecialidad = value;  }
        public string Nombre { get => this.NombreEspecialidad; set => this.NombreEspecialidad = value;  }
    }
}
