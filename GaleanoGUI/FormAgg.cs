using System;
using System.Windows.Forms;
using GaleanoDataAcess;
using System.Data.SqlClient;
using System.Data;

namespace GaleanoGUI
{
    public partial class FormAgg : Form
    {
        ConectionX sql = new ConectionX();
        private string CODIGO_CLIENTE;
        public FormAgg(string codigo)
        {
            InitializeComponent();
            label2.Text = codigo;
            CODIGO_CLIENTE = codigo;
            dateTimePicker1.Visible = false;
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO OBC(CODIGO_CLIENTE, OBSERVACION, FECHA) VALUES(@CODIGO_CLIENTE, @OBSERVACION, @FECHA)";
            try
            {
                using (SqlConnection conn = new SqlConnection(sql.SQL))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CODIGO_CLIENTE", CODIGO_CLIENTE);
                        cmd.Parameters.AddWithValue("@OBSERVACION", comboBox1.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@FECHA", dateTimePicker1.Value.ToString("d"));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Elemento agregado con Exito!!", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void FormAgg_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value.Date;
            DateTime fechaActual = DateTime.Today;

            if (fechaSeleccionada < fechaActual)
            {
                MessageBox.Show("No se pueden registrar fechas anteriores al día de hoy", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "PAGO POR ADELANTO")
            {
                dateTimePicker1.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
            }
        }
    }
}
