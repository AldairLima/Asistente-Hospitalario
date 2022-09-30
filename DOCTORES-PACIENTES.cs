using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //private void btnRestaurar_Click(object sender, EventArgs e)
        //{
           // this.WindowState = FormWindowState.Normal;
            //btnRestaurar.Visible = false;
            //btnMaximizar.Visible = true;
        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void btnMaximizar_Click(object sender, EventArgs e)
        //{
            //this.WindowState = FormWindowState.Maximized;
            //btnMaximizar.Visible = false;
            //btnRestaurar.Visible = true;
       // }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string server = "localhost";
                string database = "ahcp";
                string user = "root";
                string pwd = "root123";
                string cadenaConexion = "server=" + server + ";database=" + database + ";user=" + user + ";password=" + pwd + ";";

                MySqlConnection myCon = new MySqlConnection(cadenaConexion);
                myCon.Open();
                MessageBox.Show("Conectado!");
            }
            catch (Exception ERROR)
            {
                MessageBox.Show("Error men" + ERROR);
            }


        }
    }
}
