using System;
using System.Windows.Forms;
using GaleanoDataAcess;

namespace GaleanoGUI
{
    public partial class BusquedaReportes : Form
    {
        ConectionX sql = new ConectionX();
        public BusquedaReportes()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUDReportes reporte = new CRUDReportes();

            try
            {
                int DATO = Convert.ToInt32(dato.Text);
                if (DATO > 0)
                {
                    if (reporte.BusquedaBinaria(DATO, sql.CodigosLista()))
                    {
                        Form rpt = new ReportesRegistrados(dato.Text);
                        rpt.Show();
                    }
                    else MessageBox.Show("Elemento no encontrado.", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new Exception("El codigo deber ser un numero entero positivo");
                }
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BusquedaReportes_Load(object sender, EventArgs e)
        {

        }
    }
}
