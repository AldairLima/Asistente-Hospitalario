using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Usuario
    {
        //ATRIBUTES
        private string CodigoUsuario;
        private string CarnetUsuario;
        private string DUI;
        private string NombreUsuario;
        private string Contrasena;
        private int EdadUsuario;
        private char SexoUsuario;
        private string CodigoDepartamento;
        private string CargoUsuario;
        private int RangoUsuario;

        public Usuario(string codigoUsuario, string carnetUsuario, string dui, string nombreUsuario, string contrasena, int edadUsuario, char sexoUsuario, string codigoDepartamento, string cargoUsuario, int rangoUsuario)
        {
            this.CodigoUsuario = codigoUsuario;
            this.CarnetUsuario = carnetUsuario;
            this.DUI           = dui;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena    = contrasena;
            this.EdadUsuario   = edadUsuario;
            this.SexoUsuario   = sexoUsuario;
            this.CodigoDepartamento = codigoDepartamento;
            this.CargoUsuario       = cargoUsuario;
            this.RangoUsuario       = rangoUsuario;
        }
        public Usuario() { }

        //GETTERS
        public string getCodigoUsuario()   => this.CodigoUsuario;
        public string getCarnetUsuario()   => this.CarnetUsuario;
        public string getDUI()             => this.DUI;
        public string getNombreUsuario()   => this.NombreUsuario;
        public string getContrasena()      => this.Contrasena;
        public int    getEdadUsuario()     => this.EdadUsuario;
        public char   getCharSexoUsuario() => this.SexoUsuario;
        public string getSexoUsuario() {
            if      (this.SexoUsuario.Equals('F')) return "Femenino";
            else if (this.SexoUsuario.Equals('M')) return "Masculino";
            else                                   return null;
        }
        public string getCodigoDepartamento() => this.CodigoDepartamento;
        public string getCargoUsuario()       => this.CargoUsuario;
        public int    getRangoUsuario()       => this.RangoUsuario;

        //SETTERS
        public void setCodigoUsuario(string codigoUsuario) => this.CodigoUsuario = codigoUsuario;
        public void setCarnetUsuario(string carnetUsuario) => this.CarnetUsuario = carnetUsuario;
        public void setDUI(string dui) => this.DUI = dui;
        public void setNombreUsuario(string nombreUsuario) => this.NombreUsuario = nombreUsuario;
        public void setContrasena(string contrasena) => this.Contrasena = contrasena;
        public void setEdadUsuario(int edadUsuario) => this.EdadUsuario = edadUsuario;
        public void setSexoUsuario(char sexoUsuario) => this.SexoUsuario = sexoUsuario;
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
