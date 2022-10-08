using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías.Models.Nodos
{
    public class Persona
    {
        //ATRIBUTES
        private string DUI;
        private string Nombre;
        private int Edad;
        private char Sexo;

        public Persona(string dui, string nombre, int edad, char sexo)
        {
            this.DUI = dui;
            this.Nombre = nombre;
            this.Edad = edad;
            this.Sexo = sexo;
        }

        public Persona() { }

        //GETTERS
        public string getDUI() => this.DUI;
        public string getNombre() => this.Nombre;
        public int getEdad() => this.Edad;
        public char getCharSexo() => this.Sexo;
        public string getSexo() {
            if (this.Sexo.ToString().ToUpper().Equals("F"))
            {
                return "Femenino";
            }
            else if (this.Sexo.ToString().ToUpper().Equals("M"))
            {
                return "Masculino";
            }
            else { return null; }
        }

        //SETTERS
        public void setDUI(string dui) => this.DUI = dui;
        public void setNombre(string nombre) => this.Nombre = nombre;
        public void setEdad(int edad) => this.Edad = edad;
        public void setSexo(char sexo) => this.Sexo = sexo;
    }
}
