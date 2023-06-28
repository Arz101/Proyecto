using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using GaleanoDataAcess;

namespace GaleanoGUI
{
    public partial class BarraDeProgreso : Form
    {
        ConectionX sql = new ConectionX();
        private Timer timer;
        private PdfHeaderFooter pdf;
        private List<string> codigos;
        private int currentIndex;
        private int stepSize = 1; // Tamaño del paso para actualizar la barra de progreso

        public BarraDeProgreso(string zona, string ruta)
        {
            InitializeComponent();
            sql.numeroDeZona = zona;
            pdf = new PdfHeaderFooter(ruta);
        }

        private void BarraDeProgreso_Load(object sender, EventArgs e)
        {
            CargarReportesPorZona(); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (currentIndex < codigos.Count)
            {
                for (int i = 0; i < stepSize && currentIndex < codigos.Count; i++)
                {
                    string codigo = codigos[currentIndex];
                    try
                    {
                        // Código que intenta acceder al archivo
                        // ...
                        pdf.PDF(codigo, 1);
                        currentIndex++;
                    }
                    catch (System.IO.IOException ex)
                    {
                        MessageBox.Show(ex.Message, "!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Manejo de la excepción
                        // Otras acciones para manejar la excepción
                    }
                }

                // Actualizar la barra de progreso después de cada paso
                progressBar.Value = Math.Min(progressBar.Value + stepSize, progressBar.Maximum);
            }
            else
            {
                // Detener el Timer una vez que se haya completado el proceso
                timer.Enabled = false;

                // Cerrar el formulario
                Close();
                MessageBox.Show("Proceso completado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        public void CargarReportesPorZona()
        {
            string query = "SELECT * FROM USUARIOS WHERE ZONA = '" + sql.numeroDeZona + "' ORDER BY CAST(CODIGO_CLIENTE AS INT) ASC;";
            using (SqlConnection conn = new SqlConnection(sql.SQL))
            {
                conn.Open();

                //MessageBox.Show(query, "!!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        codigos = new List<string>();

                        while (reader.Read())
                        {
                            codigos.Add(reader["CODIGO_CLIENTE"].ToString());
                        }
                    }
                } 
            }
            string mensaje = string.Join(", ", codigos);

            MessageBox.Show(mensaje, "Elementos de la lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Configurar ProgressBar
            progressBar.Minimum = 0;
            progressBar.Maximum = codigos.Count;
            progressBar.Value = 0;

            currentIndex = 0;

            // Configurar Timer
            timer = new Timer();
            timer.Interval = 100; // Actualizar cada 100 milisegundos
            timer.Tick += Timer_Tick;
            timer.Enabled = true;

        }
    }
}
