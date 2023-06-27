using System;
using System.Windows.Forms;
using GaleanoDataAcess;

namespace GaleanoGUI
{
    public partial class pagaron : Form
    {
        ConectionX sql = new ConectionX();

        public pagaron()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            MaximizeBox = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigocliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void pagaron_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.NoPagados();
        }

        private void txtZona_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodigocliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.MarcarComoPagado(txtcodigocliente.Text);
            dataGridView1.DataSource = sql.NoPagados();
        }
    }
}
