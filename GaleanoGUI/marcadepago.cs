using System;
using System.Windows.Forms;
using GaleanoDataAcess;


namespace GUIPrincipal
{
	public partial class marcadepago : Form
	{
		ConectionX sql = new ConectionX();

		public marcadepago()
		{
			InitializeComponent();
			dataClientespago.ReadOnly = true;
			MaximizeBox = false;
		}

		private void marcadepago_Load(object sender, EventArgs e)
		{
			dataClientespago.DataSource = sql.Pagados();
		}

		private void dataClientespago_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void txtCodigo_TextChanged(object sender, EventArgs e)
		{


		}


		private void btnmarcapago_Click(object sender, EventArgs e)
		{

		}

		private void dataClientespago_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
		
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{


		}

        private void dataClientespago_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnmarcapago_Click_1(object sender, EventArgs e)
        {
			sql.MarcarComoNoPagado(txtCodigo.Text);
			dataClientespago.DataSource = sql.Pagados();
		}
    }





}
