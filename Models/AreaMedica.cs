using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class AreaMedica
    {
        //ATRIBUTES
        private string CodigoAreaMedica;
        private string NombreAreaMedica;

        public AreaMedica(string codigoAreaMedica, string nombreAreaMedica)
        {
            this.CodigoAreaMedica = codigoAreaMedica;
            this.NombreAreaMedica = nombreAreaMedica;
        }
        public AreaMedica() { }

        public string Codigo { get => this.CodigoAreaMedica; set => this.CodigoAreaMedica = value; }
        public string Nombre { get => this.NombreAreaMedica; set => this.NombreAreaMedica = value; }

    }
}
