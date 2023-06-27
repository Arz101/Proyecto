using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using GaleanoDataAcess;

namespace GaleanoGUI
{
    public partial class fechacorte : Form
    {
        ConectionX sql = new ConectionX();
        public fechacorte()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {

            DateTime fechaSeleccionada = selectFecha.Value.Date;
            DateTime fechaActual = DateTime.Today;

            if (fechaSeleccionada < fechaActual)
            {
                MessageBox.Show("No se pueden registrar fechas anteriores al día de hoy", "Error de fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fechaComoCadena = fechaSeleccionada.ToString("MM/dd/yyyy");
            label2.Text = fechaComoCadena;

            sql.guardarFecha(fechaComoCadena);

        }

        private void fechacorte_Load(object sender, EventArgs e)
        {
            label1.Text = "Fecha de corte actual:";
            string ins = @"SELECT FECHACORTE FROM DATOSCORTE WHERE CODIGO_CLIENTE = 1";
            
            using (SqlConnection conn = new SqlConnection(sql.SQL))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@ins, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            leerFecha((IDataRecord)reader);
                        }
                        reader.Close();
                    }

                }
            }
        }
        
        public void leerFecha(IDataRecord data)
        {
            label2.Text = Convert.ToString(data[0]);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
