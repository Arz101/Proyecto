using System;
using System.Windows.Forms;
using GUIPrincipal;
using GaleanoDataAcess;

namespace GaleanoGUI
{
    public partial class GUIPrincipal : Form
    {
        ConectionX sql = new ConectionX();
        public GUIPrincipal()
        {
            InitializeComponent();
            
        }

        private void GUIPrincipal_Load(object sender, EventArgs e)
        {
            sql.GetFecha();
            string date = DateTime.UtcNow.ToString("dd/MM/yyyy") + " 0:00:00";
            string sistema = "Fecha Sistema:" + date;
            string corte = "Fecha Corte:" + sql.fecha;

            MessageBox.Show(sistema + "\n" + corte , "!!!!!!!!!!!");

            if (sql.fecha == date)
            {
                var x = MessageBox.Show("Modificar los valores de Usuarios, pagados y no pagados.", "Fecha de corte!!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if(x == DialogResult.OK)
                {
                    sql.ModificacionesPorFechaDeCorte();
                }     
            }
        }

        private void CRUDReportbtn_Click(object sender, EventArgs e)
        {
            Form formulario = new CRUDReportes();
            formulario.Show();
        }

        private void CRUDUserbtn_Click(object sender, EventArgs e)
        {
            Form formulario = new CRUDUsuarios();
            formulario.Show();
        }

        private void btnreportepagonopago_Click(object sender, EventArgs e)
        {
            Form formulario = new pagaron();
            formulario.Show();
        }

        private void marcaPagos_Click(object sender, EventArgs e)
        {
            Form formulario = new marcadepago();
            formulario.Show();
        }

        private void fechacorte_Click(object sender, EventArgs e)
        {
            Form formulario = new fechacorte();
            formulario.Show();
        }

        private void bottonBanco_Click(object sender, EventArgs e)
        {
            Form form = new Banco();
            form.Show();
        }
    }
}
