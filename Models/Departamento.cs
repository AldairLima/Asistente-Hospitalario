using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Departamento
    {
        //ATRIBUTES
        private string CodigoDepartamento;
        private string NombreDepartamento;

        public Departamento(string codigoDepartamento, string nombreDepartamento)
        {
            this.CodigoDepartamento = codigoDepartamento;
            this.NombreDepartamento = nombreDepartamento;
        }
        public Departamento() { }

        //GETTERS
        public string Codigo { get => CodigoDepartamento; set => CodigoDepartamento = value; }
        public string Nombre { get => NombreDepartamento; set => NombreDepartamento = value; }
    }
}
