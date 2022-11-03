
namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías
{
    partial class ADMINISTRADOR_PACIENTE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADMINISTRADOR_PACIENTE));
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.NumeroExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DUIExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EdadExpediente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnInCirujia = new System.Windows.Forms.Button();
            this.btnInPaciente = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.roundPicture1 = new Asistente_Hospitalario_de_Pacientes_y_Cirugías.RoundPicture();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(837, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(183, 26);
            this.textBox4.TabIndex = 105;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(1053, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(160, 26);
            this.textBox3.TabIndex = 104;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(237, 177);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(244, 26);
            this.textBox2.TabIndex = 103;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(502, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(309, 26);
            this.textBox1.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(278, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 24);
            this.label2.TabIndex = 97;
            this.label2.Text = "Fecha Cirugía";
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroExpediente,
            this.NombreExpediente,
            this.ApellidoPaciente,
            this.DUIExpediente,
            this.EdadExpediente,
            this.SexoPaciente});
            this.dgvPacientes.Location = new System.Drawing.Point(236, 240);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(1034, 453);
            this.dgvPacientes.TabIndex = 95;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            this.dgvPacientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentDoubleClick);
            // 
            // NumeroExpediente
            // 
            this.NumeroExpediente.HeaderText = "N° Expediente";
            this.NumeroExpediente.MinimumWidth = 20;
            this.NumeroExpediente.Name = "NumeroExpediente";
            this.NumeroExpediente.ReadOnly = true;
            this.NumeroExpediente.Width = 190;
            // 
            // NombreExpediente
            // 
            this.NombreExpediente.HeaderText = "Nombres";
            this.NombreExpediente.Name = "NombreExpediente";
            this.NombreExpediente.ReadOnly = true;
            this.NombreExpediente.Width = 190;
            // 
            // ApellidoPaciente
            // 
            this.ApellidoPaciente.HeaderText = "Apellidos";
            this.ApellidoPaciente.Name = "ApellidoPaciente";
            this.ApellidoPaciente.ReadOnly = true;
            this.ApellidoPaciente.Width = 190;
            // 
            // DUIExpediente
            // 
            this.DUIExpediente.HeaderText = "DUI";
            this.DUIExpediente.Name = "DUIExpediente";
            this.DUIExpediente.ReadOnly = true;
            this.DUIExpediente.Width = 120;
            // 
            // EdadExpediente
            // 
            this.EdadExpediente.HeaderText = "Edad";
            this.EdadExpediente.Name = "EdadExpediente";
            this.EdadExpediente.ReadOnly = true;
            this.EdadExpediente.Width = 50;
            // 
            // SexoPaciente
            // 
            this.SexoPaciente.HeaderText = "Sexo";
            this.SexoPaciente.Name = "SexoPaciente";
            this.SexoPaciente.ReadOnly = true;
            this.SexoPaciente.Width = 190;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(59, 399);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 37);
            this.btnExit.TabIndex = 93;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnInCirujia
            // 
            this.btnInCirujia.BackColor = System.Drawing.Color.Transparent;
            this.btnInCirujia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInCirujia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInCirujia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInCirujia.ForeColor = System.Drawing.Color.White;
            this.btnInCirujia.Location = new System.Drawing.Point(59, 275);
            this.btnInCirujia.Name = "btnInCirujia";
            this.btnInCirujia.Size = new System.Drawing.Size(123, 37);
            this.btnInCirujia.TabIndex = 91;
            this.btnInCirujia.Text = "Cirugías";
            this.btnInCirujia.UseVisualStyleBackColor = false;
            this.btnInCirujia.Click += new System.EventHandler(this.btnInCirujia_Click);
            // 
            // btnInPaciente
            // 
            this.btnInPaciente.BackColor = System.Drawing.Color.Transparent;
            this.btnInPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPaciente.ForeColor = System.Drawing.Color.White;
            this.btnInPaciente.Location = new System.Drawing.Point(59, 337);
            this.btnInPaciente.Name = "btnInPaciente";
            this.btnInPaciente.Size = new System.Drawing.Size(123, 37);
            this.btnInPaciente.TabIndex = 89;
            this.btnInPaciente.Text = "Pacientes";
            this.btnInPaciente.UseVisualStyleBackColor = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(53, 218);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(146, 31);
            this.lblUsuario.TabIndex = 88;
            this.lblUsuario.Text = "USUARIO";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(196)))), ((int)(((byte)(255)))));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Location = new System.Drawing.Point(237, 85);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 26);
            this.dateTimePicker1.TabIndex = 106;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(577, 46);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(160, 29);
            this.button6.TabIndex = 107;
            this.button6.Text = "Nombre y Apellido";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(892, 42);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 29);
            this.button7.TabIndex = 108;
            this.button7.Text = "Area";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.Transparent;
            this.button8.Location = new System.Drawing.Point(1072, 42);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(125, 29);
            this.button8.TabIndex = 109;
            this.button8.Text = "N° Expediente";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Transparent;
            this.button9.Location = new System.Drawing.Point(310, 130);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(90, 29);
            this.button9.TabIndex = 110;
            this.button9.Text = "DOCTOR";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Transparent;
            this.btnAgregar.Location = new System.Drawing.Point(1053, 158);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(160, 29);
            this.btnAgregar.TabIndex = 111;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundPicture1
            // 
            this.roundPicture1.Image = ((System.Drawing.Image)(resources.GetObject("roundPicture1.Image")));
            this.roundPicture1.Location = new System.Drawing.Point(30, 27);
            this.roundPicture1.Name = "roundPicture1";
            this.roundPicture1.Size = new System.Drawing.Size(184, 176);
            this.roundPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPicture1.TabIndex = 94;
            this.roundPicture1.TabStop = false;
            // 
            // ADMINISTRADOR_PACIENTE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1314, 725);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.roundPicture1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInCirujia);
            this.Controls.Add(this.btnInPaciente);
            this.Controls.Add(this.lblUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ADMINISTRADOR_PACIENTE";
            this.Text = "ADMINISTRADOR_PACIENTE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ADMINISTRADOR_PACIENTE_FormClosed);
            this.Load += new System.EventHandler(this.ADMINISTRADOR_PACIENTE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundPicture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private RoundPicture roundPicture1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnInCirujia;
        private System.Windows.Forms.Button btnInPaciente;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DUIExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn EdadExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexoPaciente;
    }
}