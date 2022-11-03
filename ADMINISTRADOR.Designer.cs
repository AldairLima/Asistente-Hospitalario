
namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías
{
    partial class ADMINISTRADOR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMINISTRADOR));
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.roundPicture1 = new Asistente_Hospitalario_de_Pacientes_y_Cirugías.RoundPicture();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnInCirugias = new System.Windows.Forms.Button();
            this.btnInPaciente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.roundPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(285, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(538, 42);
            this.label2.TabIndex = 50;
            this.label2.Text = "Selecciona lo que quieres ver";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(44, 225);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(146, 31);
            this.lblUsuario.TabIndex = 44;
            this.lblUsuario.Text = "USUARIO";
            // 
            // roundPicture1
            // 
            this.roundPicture1.Image = ((System.Drawing.Image)(resources.GetObject("roundPicture1.Image")));
            this.roundPicture1.Location = new System.Drawing.Point(23, 30);
            this.roundPicture1.Name = "roundPicture1";
            this.roundPicture1.Size = new System.Drawing.Size(178, 183);
            this.roundPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPicture1.TabIndex = 43;
            this.roundPicture1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(50, 420);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(123, 37);
            this.btnSalir.TabIndex = 90;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnInCirugias
            // 
            this.btnInCirugias.BackColor = System.Drawing.Color.Transparent;
            this.btnInCirugias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInCirugias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInCirugias.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInCirugias.ForeColor = System.Drawing.Color.White;
            this.btnInCirugias.Location = new System.Drawing.Point(50, 296);
            this.btnInCirugias.Name = "btnInCirugias";
            this.btnInCirugias.Size = new System.Drawing.Size(123, 37);
            this.btnInCirugias.TabIndex = 88;
            this.btnInCirugias.Text = "Cirugías";
            this.btnInCirugias.UseVisualStyleBackColor = false;
            this.btnInCirugias.Click += new System.EventHandler(this.btnInCirugias_Click);
            // 
            // btnInPaciente
            // 
            this.btnInPaciente.BackColor = System.Drawing.Color.Transparent;
            this.btnInPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPaciente.ForeColor = System.Drawing.Color.White;
            this.btnInPaciente.Location = new System.Drawing.Point(50, 358);
            this.btnInPaciente.Name = "btnInPaciente";
            this.btnInPaciente.Size = new System.Drawing.Size(123, 37);
            this.btnInPaciente.TabIndex = 86;
            this.btnInPaciente.Text = "Pacientes";
            this.btnInPaciente.UseVisualStyleBackColor = false;
            this.btnInPaciente.Click += new System.EventHandler(this.btnInPaciente_Click);
            // 
            // ADMINISTRADOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(919, 588);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnInCirugias);
            this.Controls.Add(this.btnInPaciente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.roundPicture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ADMINISTRADOR";
            this.Text = "ADMINISTRADOR";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ADMINISTRADOR_FormClosed);
            this.Load += new System.EventHandler(this.ADMINISTRADOR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roundPicture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUsuario;
        private RoundPicture roundPicture1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnInCirugias;
        private System.Windows.Forms.Button btnInPaciente;
    }
}