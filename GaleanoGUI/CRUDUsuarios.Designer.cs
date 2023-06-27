
namespace GaleanoGUI
{
    partial class CRUDUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRUDUsuarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CodigoCliente = new System.Windows.Forms.TextBox();
            this.btninactivo = new System.Windows.Forms.Button();
            this.ApellidoCliente = new System.Windows.Forms.TextBox();
            this.NombreCliente = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SantaMartaRadio = new System.Windows.Forms.RadioButton();
            this.SalinasRadio = new System.Windows.Forms.RadioButton();
            this.CuatroMilpasRadio = new System.Windows.Forms.RadioButton();
            this.GaleanoRadio = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDonaciones = new System.Windows.Forms.TextBox();
            this.txtMora = new System.Windows.Forms.TextBox();
            this.txtMulta = new System.Windows.Forms.TextBox();
            this.txtCuota = new System.Windows.Forms.TextBox();
            this.TABLAUSUARIOS = new System.Windows.Forms.DataGridView();
            this.AgregarCliente = new System.Windows.Forms.Button();
            this.ModCliente = new System.Windows.Forms.Button();
            this.EliminarCliente = new System.Windows.Forms.Button();
            this.LimpiarCliente = new System.Windows.Forms.Button();
            this.btnverInactivos = new System.Windows.Forms.Button();
            this.Actualizar = new System.Windows.Forms.Button();
            this.Salir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TABLAUSUARIOS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CodigoCliente);
            this.groupBox1.Controls.Add(this.btninactivo);
            this.groupBox1.Controls.Add(this.ApellidoCliente);
            this.groupBox1.Controls.Add(this.NombreCliente);
            this.groupBox1.Location = new System.Drawing.Point(17, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(416, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CodigoCliente
            // 
            this.CodigoCliente.Location = new System.Drawing.Point(288, 39);
            this.CodigoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.CodigoCliente.Name = "CodigoCliente";
            this.CodigoCliente.Size = new System.Drawing.Size(52, 22);
            this.CodigoCliente.TabIndex = 2;
            this.CodigoCliente.TextChanged += new System.EventHandler(this.CodigoCliente_TextChanged);
            // 
            // btninactivo
            // 
            this.btninactivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btninactivo.Location = new System.Drawing.Point(221, 74);
            this.btninactivo.Margin = new System.Windows.Forms.Padding(4);
            this.btninactivo.Name = "btninactivo";
            this.btninactivo.Size = new System.Drawing.Size(180, 31);
            this.btninactivo.TabIndex = 0;
            this.btninactivo.Text = "Marcar como inactivo";
            this.btninactivo.UseVisualStyleBackColor = false;
            this.btninactivo.Click += new System.EventHandler(this.btninactivo_Click);
            // 
            // ApellidoCliente
            // 
            this.ApellidoCliente.Location = new System.Drawing.Point(72, 81);
            this.ApellidoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.ApellidoCliente.Name = "ApellidoCliente";
            this.ApellidoCliente.Size = new System.Drawing.Size(132, 22);
            this.ApellidoCliente.TabIndex = 1;
            // 
            // NombreCliente
            // 
            this.NombreCliente.Location = new System.Drawing.Point(72, 38);
            this.NombreCliente.Margin = new System.Windows.Forms.Padding(4);
            this.NombreCliente.Name = "NombreCliente";
            this.NombreCliente.Size = new System.Drawing.Size(132, 22);
            this.NombreCliente.TabIndex = 0;
            this.NombreCliente.TextChanged += new System.EventHandler(this.NombreCliente_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SantaMartaRadio);
            this.groupBox2.Controls.Add(this.SalinasRadio);
            this.groupBox2.Controls.Add(this.CuatroMilpasRadio);
            this.groupBox2.Controls.Add(this.GaleanoRadio);
            this.groupBox2.Location = new System.Drawing.Point(588, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(292, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zonas";
            // 
            // SantaMartaRadio
            // 
            this.SantaMartaRadio.AutoSize = true;
            this.SantaMartaRadio.Location = new System.Drawing.Point(27, 73);
            this.SantaMartaRadio.Margin = new System.Windows.Forms.Padding(4);
            this.SantaMartaRadio.Name = "SantaMartaRadio";
            this.SantaMartaRadio.Size = new System.Drawing.Size(106, 21);
            this.SantaMartaRadio.TabIndex = 4;
            this.SantaMartaRadio.TabStop = true;
            this.SantaMartaRadio.Text = "Santa Marta";
            this.SantaMartaRadio.UseVisualStyleBackColor = true;
            this.SantaMartaRadio.CheckedChanged += new System.EventHandler(this.SantaMartaRadio_CheckedChanged);
            // 
            // SalinasRadio
            // 
            this.SalinasRadio.AutoSize = true;
            this.SalinasRadio.Location = new System.Drawing.Point(143, 38);
            this.SalinasRadio.Margin = new System.Windows.Forms.Padding(4);
            this.SalinasRadio.Name = "SalinasRadio";
            this.SalinasRadio.Size = new System.Drawing.Size(75, 21);
            this.SalinasRadio.TabIndex = 3;
            this.SalinasRadio.TabStop = true;
            this.SalinasRadio.Text = "Salinas";
            this.SalinasRadio.UseVisualStyleBackColor = true;
            this.SalinasRadio.CheckedChanged += new System.EventHandler(this.SalinasRadio_CheckedChanged);
            // 
            // CuatroMilpasRadio
            // 
            this.CuatroMilpasRadio.AutoSize = true;
            this.CuatroMilpasRadio.Location = new System.Drawing.Point(143, 74);
            this.CuatroMilpasRadio.Margin = new System.Windows.Forms.Padding(4);
            this.CuatroMilpasRadio.Name = "CuatroMilpasRadio";
            this.CuatroMilpasRadio.Size = new System.Drawing.Size(115, 21);
            this.CuatroMilpasRadio.TabIndex = 2;
            this.CuatroMilpasRadio.TabStop = true;
            this.CuatroMilpasRadio.Text = "Cuatro Milpas";
            this.CuatroMilpasRadio.UseVisualStyleBackColor = true;
            this.CuatroMilpasRadio.CheckedChanged += new System.EventHandler(this.CuatroMilpasRadio_CheckedChanged);
            // 
            // GaleanoRadio
            // 
            this.GaleanoRadio.AutoSize = true;
            this.GaleanoRadio.Location = new System.Drawing.Point(27, 38);
            this.GaleanoRadio.Margin = new System.Windows.Forms.Padding(4);
            this.GaleanoRadio.Name = "GaleanoRadio";
            this.GaleanoRadio.Size = new System.Drawing.Size(83, 21);
            this.GaleanoRadio.TabIndex = 1;
            this.GaleanoRadio.TabStop = true;
            this.GaleanoRadio.Text = "Galeano";
            this.GaleanoRadio.UseVisualStyleBackColor = true;
            this.GaleanoRadio.CheckedChanged += new System.EventHandler(this.GaleanoRadio_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtDonaciones);
            this.groupBox3.Controls.Add(this.txtMora);
            this.groupBox3.Controls.Add(this.txtMulta);
            this.groupBox3.Controls.Add(this.txtCuota);
            this.groupBox3.Location = new System.Drawing.Point(1035, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(292, 113);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pagos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Donación";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Multa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Mora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cuota";
            // 
            // txtDonaciones
            // 
            this.txtDonaciones.Location = new System.Drawing.Point(204, 68);
            this.txtDonaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonaciones.Name = "txtDonaciones";
            this.txtDonaciones.Size = new System.Drawing.Size(64, 22);
            this.txtDonaciones.TabIndex = 3;
            // 
            // txtMora
            // 
            this.txtMora.Location = new System.Drawing.Point(204, 34);
            this.txtMora.Margin = new System.Windows.Forms.Padding(4);
            this.txtMora.Name = "txtMora";
            this.txtMora.Size = new System.Drawing.Size(64, 22);
            this.txtMora.TabIndex = 2;
            // 
            // txtMulta
            // 
            this.txtMulta.Location = new System.Drawing.Point(64, 68);
            this.txtMulta.Margin = new System.Windows.Forms.Padding(4);
            this.txtMulta.Name = "txtMulta";
            this.txtMulta.Size = new System.Drawing.Size(64, 22);
            this.txtMulta.TabIndex = 1;
            // 
            // txtCuota
            // 
            this.txtCuota.Location = new System.Drawing.Point(64, 36);
            this.txtCuota.Margin = new System.Windows.Forms.Padding(4);
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.Size = new System.Drawing.Size(64, 22);
            this.txtCuota.TabIndex = 0;
            this.txtCuota.TextChanged += new System.EventHandler(this.txtCuota_TextChanged);
            // 
            // TABLAUSUARIOS
            // 
            this.TABLAUSUARIOS.AccessibleName = "";
            this.TABLAUSUARIOS.AllowUserToAddRows = false;
            this.TABLAUSUARIOS.AllowUserToDeleteRows = false;
            this.TABLAUSUARIOS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TABLAUSUARIOS.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TABLAUSUARIOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TABLAUSUARIOS.GridColor = System.Drawing.SystemColors.ControlText;
            this.TABLAUSUARIOS.Location = new System.Drawing.Point(16, 137);
            this.TABLAUSUARIOS.Margin = new System.Windows.Forms.Padding(4);
            this.TABLAUSUARIOS.MultiSelect = false;
            this.TABLAUSUARIOS.Name = "TABLAUSUARIOS";
            this.TABLAUSUARIOS.ReadOnly = true;
            this.TABLAUSUARIOS.RowHeadersWidth = 51;
            this.TABLAUSUARIOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TABLAUSUARIOS.Size = new System.Drawing.Size(1315, 491);
            this.TABLAUSUARIOS.TabIndex = 3;
            this.TABLAUSUARIOS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AgregarCliente
            // 
            this.AgregarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AgregarCliente.Location = new System.Drawing.Point(17, 635);
            this.AgregarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.AgregarCliente.Name = "AgregarCliente";
            this.AgregarCliente.Size = new System.Drawing.Size(136, 53);
            this.AgregarCliente.TabIndex = 4;
            this.AgregarCliente.Text = "AGREGAR";
            this.AgregarCliente.UseVisualStyleBackColor = false;
            this.AgregarCliente.Click += new System.EventHandler(this.AgregarCliente_Click);
            // 
            // ModCliente
            // 
            this.ModCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ModCliente.Location = new System.Drawing.Point(161, 635);
            this.ModCliente.Margin = new System.Windows.Forms.Padding(4);
            this.ModCliente.Name = "ModCliente";
            this.ModCliente.Size = new System.Drawing.Size(136, 53);
            this.ModCliente.TabIndex = 5;
            this.ModCliente.Text = "MODIFICAR";
            this.ModCliente.UseVisualStyleBackColor = false;
            this.ModCliente.Click += new System.EventHandler(this.ModCliente_Click);
            // 
            // EliminarCliente
            // 
            this.EliminarCliente.BackColor = System.Drawing.Color.Tomato;
            this.EliminarCliente.Location = new System.Drawing.Point(305, 635);
            this.EliminarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.EliminarCliente.Name = "EliminarCliente";
            this.EliminarCliente.Size = new System.Drawing.Size(136, 53);
            this.EliminarCliente.TabIndex = 6;
            this.EliminarCliente.Text = "ELIMINAR";
            this.EliminarCliente.UseVisualStyleBackColor = false;
            this.EliminarCliente.Click += new System.EventHandler(this.EliminarCliente_Click);
            // 
            // LimpiarCliente
            // 
            this.LimpiarCliente.Location = new System.Drawing.Point(449, 635);
            this.LimpiarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.LimpiarCliente.Name = "LimpiarCliente";
            this.LimpiarCliente.Size = new System.Drawing.Size(136, 53);
            this.LimpiarCliente.TabIndex = 7;
            this.LimpiarCliente.Text = "LIMPIAR";
            this.LimpiarCliente.UseVisualStyleBackColor = true;
            this.LimpiarCliente.Click += new System.EventHandler(this.LimpiarCliente_Click);
            // 
            // btnverInactivos
            // 
            this.btnverInactivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnverInactivos.Location = new System.Drawing.Point(744, 635);
            this.btnverInactivos.Margin = new System.Windows.Forms.Padding(4);
            this.btnverInactivos.Name = "btnverInactivos";
            this.btnverInactivos.Size = new System.Drawing.Size(136, 53);
            this.btnverInactivos.TabIndex = 8;
            this.btnverInactivos.Text = "VER INACTIVOS";
            this.btnverInactivos.UseVisualStyleBackColor = false;
            this.btnverInactivos.Click += new System.EventHandler(this.btnverInactivos_Click);
            // 
            // Actualizar
            // 
            this.Actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Actualizar.Location = new System.Drawing.Point(1048, 635);
            this.Actualizar.Margin = new System.Windows.Forms.Padding(4);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(136, 53);
            this.Actualizar.TabIndex = 9;
            this.Actualizar.Text = "ACTUALIZAR";
            this.Actualizar.UseVisualStyleBackColor = false;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.Red;
            this.Salir.Location = new System.Drawing.Point(1195, 635);
            this.Salir.Margin = new System.Windows.Forms.Padding(4);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(136, 53);
            this.Salir.TabIndex = 10;
            this.Salir.Text = "SALIR";
            this.Salir.UseVisualStyleBackColor = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // CRUDUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1343, 690);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.btnverInactivos);
            this.Controls.Add(this.LimpiarCliente);
            this.Controls.Add(this.EliminarCliente);
            this.Controls.Add(this.ModCliente);
            this.Controls.Add(this.AgregarCliente);
            this.Controls.Add(this.TABLAUSUARIOS);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CRUDUsuarios";
            this.Text = "Interfaz de clientes";
            this.Load += new System.EventHandler(this.CRUDUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TABLAUSUARIOS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CodigoCliente;
        private System.Windows.Forms.TextBox ApellidoCliente;
        private System.Windows.Forms.TextBox NombreCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btninactivo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDonaciones;
        private System.Windows.Forms.TextBox txtMora;
        private System.Windows.Forms.TextBox txtMulta;
        private System.Windows.Forms.TextBox txtCuota;
        private System.Windows.Forms.RadioButton SantaMartaRadio;
        private System.Windows.Forms.RadioButton SalinasRadio;
        private System.Windows.Forms.RadioButton CuatroMilpasRadio;
        private System.Windows.Forms.RadioButton GaleanoRadio;
        private System.Windows.Forms.DataGridView TABLAUSUARIOS;
        private System.Windows.Forms.Button AgregarCliente;
        private System.Windows.Forms.Button ModCliente;
        private System.Windows.Forms.Button EliminarCliente;
        private System.Windows.Forms.Button LimpiarCliente;
        private System.Windows.Forms.Button btnverInactivos;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}