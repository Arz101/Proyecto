using System;
using System.Windows.Forms;
using GaleanoDataAcess;

namespace GaleanoGUI
{
    public partial class Inactivos : Form
    {
        ConectionX sql = new ConectionX();
        public Inactivos()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void dataInactivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            codigotxt.Text = dataInactivos.CurrentRow.Cells[0].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Inactivos_Load(object sender, EventArgs e)
        {
            dataInactivos.DataSource = sql.llenarGridInactivos();
        }

        private void marcaActivo_Click(object sender, EventArgs e)
        {
            try
            {
                sql.marcarActivo(codigotxt.Text);
                dataInactivos.DataSource = sql.llenarGridInactivos();
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message, "Hubo un problema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
