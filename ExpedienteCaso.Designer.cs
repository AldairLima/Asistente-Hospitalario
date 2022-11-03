namespace Asistente_Hospitalario_de_Pacientes_y_Cirugías
{
    partial class ExpedienteCaso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblExp = new System.Windows.Forms.Label();
            this.dgvExpediente = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDarAlta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpediente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 45;
            this.label1.Text = "Paciente:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(166, 66);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(204, 24);
            this.lblNombre.TabIndex = 46;
            this.lblNombre.Text = "Nombres y Apellidos";
            // 
            // lblExp
            // 
            this.lblExp.AutoSize = true;
            this.lblExp.BackColor = System.Drawing.Color.Transparent;
            this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExp.ForeColor = System.Drawing.Color.White;
            this.lblExp.Location = new System.Drawing.Point(1069, 66);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(247, 24);
            this.lblExp.TabIndex = 47;
            this.lblExp.Text = "N° EXPEDIENTE: 000000";
            // 
            // dgvExpediente
            // 
            this.dgvExpediente.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.dgvExpediente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpediente.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvExpediente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpediente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Nombres,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dgvExpediente.Location = new System.Drawing.Point(202, 110);
            this.dgvExpediente.Name = "dgvExpediente";
            this.dgvExpediente.ReadOnly = true;
            this.dgvExpediente.Size = new System.Drawing.Size(1063, 441);
            this.dgvExpediente.TabIndex = 48;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha de Ingreso";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // Nombres
            // 
            this.Nombres.HeaderText = "Área";
            this.Nombres.MinimumWidth = 20;
            this.Nombres.Name = "Nombres";
            this.Nombres.ReadOnly = true;
            this.Nombres.Width = 190;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Causa de Ingreso";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 190;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha Alta";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 190;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Doctor";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 190;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Diagnostico Final";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // btnDarAlta
            // 
            this.btnDarAlta.BackColor = System.Drawing.Color.Transparent;
            this.btnDarAlta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDarAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDarAlta.ForeColor = System.Drawing.Color.White;
            this.btnDarAlta.Location = new System.Drawing.Point(202, 578);
            this.btnDarAlta.Name = "btnDarAlta";
            this.btnDarAlta.Size = new System.Drawing.Size(142, 37);
            this.btnDarAlta.TabIndex = 49;
            this.btnDarAlta.Text = "Dar de Alta";
            this.btnDarAlta.UseVisualStyleBackColor = false;
            this.btnDarAlta.Click += new System.EventHandler(this.btnDarAlta_Click);
            // 
            // ExpedienteCaso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1370, 627);
            this.Controls.Add(this.btnDarAlta);
            this.Controls.Add(this.dgvExpediente);
            this.Controls.Add(this.lblExp);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label1);
            this.Name = "ExpedienteCaso";
            this.Text = "ExpedienteCaso";
            this.Load += new System.EventHandler(this.ExpedienteCaso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpediente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblExp;
        private System.Windows.Forms.DataGridView dgvExpediente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnDarAlta;
    }
}