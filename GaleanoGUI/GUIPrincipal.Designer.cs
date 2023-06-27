
namespace GaleanoGUI
{
    partial class GUIPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUIPrincipal));
            this.CRUDUserbtn = new System.Windows.Forms.Button();
            this.CRUDReportbtn = new System.Windows.Forms.Button();
            this.btnreportepagonopago = new System.Windows.Forms.Button();
            this.marcaPagos = new System.Windows.Forms.Button();
            this.fechacorte = new System.Windows.Forms.Button();
            this.bottonBanco = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CRUDUserbtn
            // 
            this.CRUDUserbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.CRUDUserbtn.Location = new System.Drawing.Point(12, 124);
            this.CRUDUserbtn.Name = "CRUDUserbtn";
            this.CRUDUserbtn.Size = new System.Drawing.Size(166, 46);
            this.CRUDUserbtn.TabIndex = 0;
            this.CRUDUserbtn.Text = "CRUD DE USUARIO";
            this.CRUDUserbtn.UseVisualStyleBackColor = false;
            this.CRUDUserbtn.Click += new System.EventHandler(this.CRUDUserbtn_Click);
            // 
            // CRUDReportbtn
            // 
            this.CRUDReportbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.CRUDReportbtn.Location = new System.Drawing.Point(356, 123);
            this.CRUDReportbtn.Name = "CRUDReportbtn";
            this.CRUDReportbtn.Size = new System.Drawing.Size(166, 47);
            this.CRUDReportbtn.TabIndex = 1;
            this.CRUDReportbtn.Text = "REPORTES POR PERSONA/ZONA";
            this.CRUDReportbtn.UseVisualStyleBackColor = false;
            this.CRUDReportbtn.Click += new System.EventHandler(this.CRUDReportbtn_Click);
            // 
            // btnreportepagonopago
            // 
            this.btnreportepagonopago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnreportepagonopago.Location = new System.Drawing.Point(184, 123);
            this.btnreportepagonopago.Name = "btnreportepagonopago";
            this.btnreportepagonopago.Size = new System.Drawing.Size(166, 47);
            this.btnreportepagonopago.TabIndex = 2;
            this.btnreportepagonopago.Text = "PERSONAS QUE NO HAN PAGADO";
            this.btnreportepagonopago.UseVisualStyleBackColor = false;
            this.btnreportepagonopago.Click += new System.EventHandler(this.btnreportepagonopago_Click);
            // 
            // marcaPagos
            // 
            this.marcaPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.marcaPagos.Location = new System.Drawing.Point(12, 176);
            this.marcaPagos.Name = "marcaPagos";
            this.marcaPagos.Size = new System.Drawing.Size(166, 46);
            this.marcaPagos.TabIndex = 4;
            this.marcaPagos.Text = "MARCAJE DE PAGOS";
            this.marcaPagos.UseVisualStyleBackColor = false;
            this.marcaPagos.Click += new System.EventHandler(this.marcaPagos_Click);
            // 
            // fechacorte
            // 
            this.fechacorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fechacorte.Location = new System.Drawing.Point(184, 176);
            this.fechacorte.Name = "fechacorte";
            this.fechacorte.Size = new System.Drawing.Size(166, 47);
            this.fechacorte.TabIndex = 3;
            this.fechacorte.Text = "CAMBIO DE FECHA DE CORTE";
            this.fechacorte.UseVisualStyleBackColor = false;
            this.fechacorte.Click += new System.EventHandler(this.fechacorte_Click);
            // 
            // bottonBanco
            // 
            this.bottonBanco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bottonBanco.Location = new System.Drawing.Point(356, 176);
            this.bottonBanco.Margin = new System.Windows.Forms.Padding(2);
            this.bottonBanco.Name = "bottonBanco";
            this.bottonBanco.Size = new System.Drawing.Size(166, 47);
            this.bottonBanco.TabIndex = 6;
            this.bottonBanco.Text = "CAMBIO O ASIGNACION DE BANCO";
            this.bottonBanco.UseVisualStyleBackColor = false;
            this.bottonBanco.Click += new System.EventHandler(this.bottonBanco_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // GUIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(535, 236);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bottonBanco);
            this.Controls.Add(this.marcaPagos);
            this.Controls.Add(this.fechacorte);
            this.Controls.Add(this.btnreportepagonopago);
            this.Controls.Add(this.CRUDReportbtn);
            this.Controls.Add(this.CRUDUserbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GUIPrincipal";
            this.Text = "MENU PRINCIPAL";
            this.Load += new System.EventHandler(this.GUIPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CRUDUserbtn; 
        private System.Windows.Forms.Button CRUDReportbtn;
        private System.Windows.Forms.Button btnreportepagonopago;
        private System.Windows.Forms.Button marcaPagos;
        private System.Windows.Forms.Button fechacorte;
        private System.Windows.Forms.Button bottonBanco;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

