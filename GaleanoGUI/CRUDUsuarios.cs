using System;
using System.Windows.Forms;
using GaleanoDataAcess;
using System.Data.SqlClient;

namespace GaleanoGUI
{
    public partial class CRUDUsuarios : Form
    {

        ConectionX sql = new ConectionX();
        int CheckValueZonas = 0;
        
        public CRUDUsuarios()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void CRUDUser_Load(object sender, EventArgs e)
        {
       
        }

        private void btninactivo_Click(object sender, EventArgs e)
        {
            sql.marcarComoInactivo(CodigoCliente.Text);
            TABLAUSUARIOS.DataSource = sql.MostrarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void CodigoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnverInactivos_Click(object sender, EventArgs e)
        {
            Form formulario = new Inactivos();
            formulario.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CodigoCliente.Text = TABLAUSUARIOS.CurrentRow.Cells[0].Value.ToString();
                NombreCliente.Text = TABLAUSUARIOS.CurrentRow.Cells[1].Value.ToString();
                ApellidoCliente.Text = TABLAUSUARIOS.CurrentRow.Cells[2].Value.ToString();

                txtCuota.Text = TABLAUSUARIOS.CurrentRow.Cells[3].Value.ToString();
                txtMora.Text = TABLAUSUARIOS.CurrentRow.Cells[4].Value.ToString();
                txtDonaciones.Text = TABLAUSUARIOS.CurrentRow.Cells[5].Value.ToString();

                int MostrarNumero;
                MostrarNumero = Int32.Parse(TABLAUSUARIOS.CurrentRow.Cells[6].Value.ToString());
                txtMulta.Text = TABLAUSUARIOS.CurrentRow.Cells[7].Value.ToString();


                if (MostrarNumero == 1)
                {
                    GaleanoRadio.Checked = true;
                    SalinasRadio.Checked = false;
                    SantaMartaRadio.Checked = false;
                    CuatroMilpasRadio.Checked = false;
                }

                else if (MostrarNumero == 2)
                {
                    GaleanoRadio.Checked = false;
                    SalinasRadio.Checked = true;
                    SantaMartaRadio.Checked = false;
                    CuatroMilpasRadio.Checked = false;

                }
                else if (MostrarNumero == 3)
                {
                    GaleanoRadio.Checked = false;
                    SalinasRadio.Checked = false;
                    SantaMartaRadio.Checked = true;
                    CuatroMilpasRadio.Checked = false;
                }
                else if (MostrarNumero == 4)
                {
                    GaleanoRadio.Checked = false;
                    SalinasRadio.Checked = false;
                    SantaMartaRadio.Checked = false;
                    CuatroMilpasRadio.Checked = true;
                }
            }
            catch { }
        }

        private void CRUDUsuarios_Load(object sender, EventArgs e)
        {
            TABLAUSUARIOS.DataSource = sql.MostrarDatos();
        }

        private void AgregarCliente_Click(object sender, EventArgs e)
        {
            //// CODIGO!!!
            ///

            int zona = 0;
            if (GaleanoRadio.Checked) zona = 1;
            if (CuatroMilpasRadio.Checked) zona = 2;
            if (SantaMartaRadio.Checked) zona = 3;
            if (SalinasRadio.Checked) zona = 4;
            /// AGREGAR EXPCION
            ///
            try
            {
                sql.registroINSERT(CodigoCliente.Text, NombreCliente.Text, ApellidoCliente.Text, Convert.ToString(zona), Convert.ToDouble(txtCuota.Text), Convert.ToDouble(txtMora.Text), Convert.ToDouble(txtDonaciones.Text));
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void SalinasRadio_CheckedChanged(object sender, EventArgs e)
        {
            CheckValueZonas = 2;

        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            TABLAUSUARIOS.DataSource = sql.MostrarDatos();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EliminarCliente_Click(object sender, EventArgs e)
        {
            sql.eliminar(CodigoCliente.Text);
            TABLAUSUARIOS.DataSource = sql.MostrarDatos();
        }

        private void LimpiarCliente_Click(object sender, EventArgs e)
        {
            CodigoCliente.Clear();
            NombreCliente.Clear();
            ApellidoCliente.Clear();
            CodigoCliente.Focus();
            txtDonaciones.Clear();
            txtMora.Clear();
            txtCuota.Clear();
            txtMulta.Clear();
        }

        private void txtCuota_TextChanged(object sender, EventArgs e)
        {

        }

        private void ModCliente_Click(object sender, EventArgs e)
        {
            try
            {

                string actualizar = "UPDATE USUARIOS SET NOMBRES=@NOMBRES, APELLIDOS=@APELLIDOS, ZONA=@ZONA WHERE CODIGO_CLIENTE=@CODIGO_CLIENTE";
                string actualizar2 = "UPDATE PAGOS SET CUOTA=@CUOTA, MORA=@MORA, DONACION=@DONACION, MULTA=@MULTA WHERE CODIGO_CLIENTE=@CODIGO_CLIENTE";
                MessageBox.Show(actualizar);

                using (SqlConnection conn = new SqlConnection(sql.SQL))
                {
                    conn.Open();

                    using (SqlCommand cmd2 = new SqlCommand(actualizar, conn))
                    {
                        cmd2.Parameters.AddWithValue("@CODIGO_CLIENTE", CodigoCliente.Text);
                        cmd2.Parameters.AddWithValue("@NOMBRES", NombreCliente.Text);
                        cmd2.Parameters.AddWithValue("@APELLIDOS", ApellidoCliente.Text);
                        cmd2.Parameters.AddWithValue("@ZONA", CheckValueZonas);

                        cmd2.Parameters.AddWithValue("@CUOTA", txtCuota.Text);
                        cmd2.Parameters.AddWithValue("@MORA", txtMora.Text);
                        cmd2.Parameters.AddWithValue("@DONACION", txtDonaciones.Text);
                        cmd2.Parameters.AddWithValue("@MULTA", txtMulta.Text);


                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Los datos fueron actualizados con exito");
                    }

                    using (SqlCommand cmd = new SqlCommand(actualizar2, conn))
                    {
                        cmd.Parameters.AddWithValue("@CODIGO_CLIENTE", CodigoCliente.Text);
                        cmd.Parameters.AddWithValue("@CUOTA", txtCuota.Text);
                        cmd.Parameters.AddWithValue("@MORA", txtMora.Text);
                        cmd.Parameters.AddWithValue("@DONACION", txtDonaciones.Text);
                        cmd.Parameters.AddWithValue("@MULTA", txtMulta.Text);


                        cmd.ExecuteNonQuery();
                    }
                }
                TABLAUSUARIOS.DataSource = sql.MostrarDatos();
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message,"Hubo un error al actualizar");
            }

        }

        private void GaleanoRadio_CheckedChanged(object sender, EventArgs e)
        {
            CheckValueZonas = 1;
        }

        private void SantaMartaRadio_CheckedChanged(object sender, EventArgs e)
        {
            CheckValueZonas = 3;
        }

        private void CuatroMilpasRadio_CheckedChanged(object sender, EventArgs e)
        {
            CheckValueZonas = 4;
        }
    }
}
