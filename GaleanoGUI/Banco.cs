using System;
using System.Windows.Forms;
using GaleanoDataAcess;
using System.Data.SqlClient;


namespace GaleanoGUI
{
    public partial class Banco : Form
    {
        ConectionX sql = new ConectionX();
        public Banco()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cuentaBanco = NombreBanco.Text.ToUpper() + " No de Cuenta: " + NumeroCuenta.Text;

            using (SqlConnection conn = new SqlConnection(sql.SQL))
            {
                conn.Open();

                string query = "DELETE FROM BANCO \nINSERT INTO BANCO VALUES('" + cuentaBanco + "')";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se a guardado correctamente!", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception a) 
                {
                    MessageBox.Show(a.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            NombreBanco.Text = "";
            NumeroCuenta.Text = "";
        }

        private void Banco_Load(object sender, EventArgs e)
        {

        }
    }
}
