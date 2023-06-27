
namespace GUIPrincipal
{
    partial class marcadepago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(marcadepago));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnmarcapago = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataClientespago = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientespago)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnmarcapago);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda de personas";
            // 
            // btnmarcapago
            // 
            this.btnmarcapago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnmarcapago.Location = new System.Drawing.Point(463, 28);
            this.btnmarcapago.Name = "btnmarcapago";
            this.btnmarcapago.Size = new System.Drawing.Size(156, 36);
            this.btnmarcapago.TabIndex = 2;
            this.btnmarcapago.Text = "Marcar que no ha pagado";
            this.btnmarcapago.UseVisualStyleBackColor = false;
            this.btnmarcapago.Click += new System.EventHandler(this.btnmarcapago_Click_1);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(209, 37);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(59, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de usuario";
            // 
            // dataClientespago
            // 
            this.dataClientespago.AllowUserToAddRows = false;
            this.dataClientespago.AllowUserToDeleteRows = false;
            this.dataClientespago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataClientespago.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataClientespago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataClientespago.Location = new System.Drawing.Point(13, 98);
            this.dataClientespago.MultiSelect = false;
            this.dataClientespago.Name = "dataClientespago";
            this.dataClientespago.ReadOnly = true;
            this.dataClientespago.RowHeadersWidth = 51;
            this.dataClientespago.Size = new System.Drawing.Size(759, 423);
            this.dataClientespago.TabIndex = 1;
            this.dataClientespago.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataClientespago_CellContentClick_1);
            // 
            // marcadepago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(779, 532);
            this.Controls.Add(this.dataClientespago);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "marcadepago";
            this.Text = "marcadepago";
            this.Load += new System.EventHandler(this.marcadepago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientespago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnmarcapago;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataClientespago;
    }
}