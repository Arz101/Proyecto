using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using GaleanoDataAcess;

namespace GaleanoGUI
{
    public partial class ReportesRegistrados : Form
    {
        private string dato;
        private ConectionX sql = new ConectionX();
        public ReportesRegistrados(string v)
        {
            InitializeComponent();
            dato = v;
            MaximizeBox = false;
            dataGridView1.ReadOnly = true;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ReportesRegistrados_Load(object sender, EventArgs e)
        {
            string query = @"SELECT U.NOMBRES, U.APELLIDOS, U.CODIGO_CLIENTE, R.FECHA_CREACION, R.MULTA, R.CUOTA, R.DONACION, R.MORA, R.HAPAGADO ,R.ID_REPORTE
FROM REPORTES R
JOIN USUARIOS U
ON R.CODIGO_CLIENTE = U.CODIGO_CLIENTE WHERE R.CODIGO_CLIENTE ='" + dato +"'";
            using (SqlConnection conn = new SqlConnection(sql.SQL))
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@CodigoCliente", dato);
                    adapter.SelectCommand.CommandType = CommandType.Text;
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Modificar acciones", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
