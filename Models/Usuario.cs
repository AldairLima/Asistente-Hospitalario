using Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Usuario : Persona
    {
        //ATRIBUTES
        private string CodigoUsuario;
        private string CarnetUsuario;
        private string Contrasena;
        private string CodigoDepartamento;
        private string CargoUsuario;
        private int RangoUsuario;

        public Usuario(string codigoUsuario, string carnetUsuario, string duiUsuario, string nombreUsuario, string apellidoUsuario, string contrasena, int edadUsuario, char sexoUsuario, string codigoDepartamento, string cargoUsuario, int rangoUsuario):base(duiUsuario, nombreUsuario, apellidoUsuario, edadUsuario, sexoUsuario)
        {
            this.CodigoUsuario = codigoUsuario;
            this.CarnetUsuario = carnetUsuario;
            this.Contrasena    = contrasena;
            this.CodigoDepartamento = codigoDepartamento;
            this.CargoUsuario       = cargoUsuario;
            this.RangoUsuario       = rangoUsuario;
        }
        public Usuario() { }

        //GETTERS
        public string getCodigoUsuario()   => this.CodigoUsuario;
        public string getCarnetUsuario()   => this.CarnetUsuario;
        public string getContrasena()      => this.Contrasena;
        public string getCodigoDepartamento() => this.CodigoDepartamento;
        public string getCargoUsuario()       => this.CargoUsuario;
        public int    getRangoUsuario()       => this.RangoUsuario;

        //SETTERS
        public void setCodigoUsuario(string codigoUsuario) => this.CodigoUsuario = codigoUsuario;
        public void setCarnetUsuario(string carnetUsuario) => this.CarnetUsuario = carnetUsuario;
        public void setContrasena(string contrasena) => this.Contrasena = contrasena;
        public void setCodigoDepartamento(string codigoDepartamento) => this.CodigoDepartamento = codigoDepartamento;
        public void setCargoUsuario(string cargoUsuario) => this.CargoUsuario = cargoUsuario;
        public void setRangoUsuario(int rangoUsuario) => this.RangoUsuario = rangoUsuario;


        //EXTENDED ATRIBUTE (PROVISIONAL)
        protected Departamento DepartamentoUsuario;
        public Departamento getDepartamento() => this.DepartamentoUsuario;
        public void setDepartamento(Departamento departamento) { 
            if (departamento.Codigo.Equals(this.CodigoDepartamento))    
                this.DepartamentoUsuario = departamento; 
        }

    }
}
