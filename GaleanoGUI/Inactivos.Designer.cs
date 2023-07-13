
namespace GaleanoGUI
{
    partial class Inactivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inactivos));
            this.dataInactivos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.marcaActivo = new System.Windows.Forms.Button();
            this.codigotxt = new System.Windows.Forms.TextBox();
            this.btnOBC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataInactivos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataInactivos
            // 
            this.dataInactivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataInactivos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInactivos.Location = new System.Drawing.Point(16, 105);
            this.dataInactivos.Margin = new System.Windows.Forms.Padding(4);
            this.dataInactivos.MultiSelect = false;
            this.dataInactivos.Name = "dataInactivos";
            this.dataInactivos.ReadOnly = true;
            this.dataInactivos.RowHeadersWidth = 51;
            this.dataInactivos.Size = new System.Drawing.Size(739, 434);
            this.dataInactivos.TabIndex = 0;
            this.dataInactivos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataInactivos_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOBC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.marcaActivo);
            this.groupBox1.Controls.Add(this.codigotxt);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(739, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personas inactivas";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo de cliente";
            // 
            // marcaActivo
            // 
            this.marcaActivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.marcaActivo.Location = new System.Drawing.Point(513, 18);
            this.marcaActivo.Margin = new System.Windows.Forms.Padding(4);
            this.marcaActivo.Name = "marcaActivo";
            this.marcaActivo.Size = new System.Drawing.Size(201, 47);
            this.marcaActivo.TabIndex = 1;
            this.marcaActivo.Text = "Marcar como activo";
            this.marcaActivo.UseVisualStyleBackColor = false;
            this.marcaActivo.Click += new System.EventHandler(this.marcaActivo_Click);
            // 
            // codigotxt
            // 
            this.codigotxt.Location = new System.Drawing.Point(165, 35);
            this.codigotxt.Margin = new System.Windows.Forms.Padding(4);
            this.codigotxt.Name = "codigotxt";
            this.codigotxt.Size = new System.Drawing.Size(75, 22);
            this.codigotxt.TabIndex = 0;
            // 
            // btnOBC
            // 
            this.btnOBC.BackColor = System.Drawing.Color.Cyan;
            this.btnOBC.Location = new System.Drawing.Point(269, 18);
            this.btnOBC.Margin = new System.Windows.Forms.Padding(4);
            this.btnOBC.Name = "btnOBC";
            this.btnOBC.Size = new System.Drawing.Size(201, 47);
            this.btnOBC.TabIndex = 3;
            this.btnOBC.Text = "Agregar Observacion";
            this.btnOBC.UseVisualStyleBackColor = false;
            this.btnOBC.Click += new System.EventHandler(this.btnOBC_Click);
            // 
            // Inactivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(768, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataInactivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inactivos";
            this.Text = "Inactivos";
            this.Load += new System.EventHandler(this.Inactivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataInactivos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataInactivos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox codigotxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button marcaActivo;
        private System.Windows.Forms.Button btnOBC;
    }
}