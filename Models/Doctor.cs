using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models
{
    public class Doctor
    {
        //ATRIBUTES
        private string CodigoDoctor;
        private string CodigoUsuario;
        private string CodigoEspecialidad;

        public Doctor(string codigoDoctor, string codigoUsuario, string codigoEspecialidad)
        {
            CodigoDoctor = codigoDoctor;
            CodigoUsuario = codigoUsuario;
            CodigoEspecialidad = codigoEspecialidad;
        }
        public Doctor() { }

        //GETTERS
        public string getCodigoDoctor() => this.CodigoDoctor;
        public string getCodigoUsuario() => this.CodigoUsuario;
        public string getCodigoEspecialidad() => this.CodigoEspecialidad;

        //SETTERS
        public void setCodigoDoctor(string codigoDoctor) => this.CodigoDoctor= codigoDoctor;
        public void setCodigoUsuario(string codigoUsuario) => this.CodigoUsuario = codigoUsuario;
        public void setCodigoEspecialidad(string codigoEspecialidad) => this.CodigoEspecialidad = codigoEspecialidad;

        //EXTENDED ATRIBUTES
        protected Usuario UsuarioDoctor;
        protected Especialidad EspecialidadDoctor;

        public Usuario getUsuario() => this.UsuarioDoctor;
        public Especialidad getEspecialidad() => this.EspecialidadDoctor;

        public void setUsuario(Usuario usuario) {
            if (usuario.getCodigoUsuario().Equals(this.CodigoUsuario))
                this.UsuarioDoctor = usuario;
        }
        public void setEspecialidad(Especialidad especialidad) {
            if (especialidad.Codigo.Equals(this.CodigoEspecialidad))
                this.EspecialidadDoctor = especialidad;
        }
    }
}
