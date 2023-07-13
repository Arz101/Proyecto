using System;
using System.Windows.Forms;
using GaleanoDataAcess;
using System.Collections.Generic;

namespace GaleanoGUI
{
    public partial class CRUDReportes : Form
    {
        private BusquedaReportes Busqueda;
        private ConectionX sql = new ConectionX();
        private PdfHeaderFooter pdf = new PdfHeaderFooter();
        public CRUDReportes()
        {
            MaximizeBox = false;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CRUDReportes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.TablaUsuariosDeReportes();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Form Progress;
            try
            {
                if (FiltroCombo.SelectedItem != null)
                {
                    if (FiltroCombo.SelectedItem.ToString() == "ZONA")
                    {
                        switch (BarraFiltro.Text)
                        {
                            case "1":
                                sql.numeroDeZona = "1";
                                Progress = new BarraDeProgreso(sql.numeroDeZona, @"Reportes Zona 1\");
                                Progress.Show();
                                break;

                            case "2":
                                sql.numeroDeZona = "2";
                                Progress = new BarraDeProgreso(sql.numeroDeZona, @"Reportes Zona 2\");
                                Progress.Show();
                                break;
                            case "3":
                                sql.numeroDeZona = "3";
                                Progress = new BarraDeProgreso(sql.numeroDeZona, @"Reportes Zona 3\");
                                Progress.Show();
                                break;
                            case "4":
                                sql.numeroDeZona = "4";
                                Progress = new BarraDeProgreso(sql.numeroDeZona, @"Reportes Zona 4\");
                                Progress.Show();
                                break;
                            default:
                                throw new Exception("Selección de zona inválida.");
                        }
                    }
                    else if (FiltroCombo.SelectedItem.ToString() == "CODIGO_CLIENTE")
                    {
                        try
                        {
                            if (BusquedaBinaria(Convert.ToInt32(BarraFiltro.Text), sql.CodigosLista()))
                            {
                                pdf.PDF(BarraFiltro.Text, 0);
                                MessageBox.Show("Reporte creado con Éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else MessageBox.Show("Dato no encontrado", "!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al crear el reporte: " + ex.Message, "¡Advertencia!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        throw new Exception("Selección de filtro inválida.");
                    }
                }
                else
                {
                    throw new Exception("No se ha seleccionado ningún elemento en el filtro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool BusquedaBinaria(int dato, List<int> list)
        {
            int inf=0, sup=list.Count, mitad;

            string mensaje = string.Join(", ", list);

            //MessageBox.Show(mensaje, "Elementos de la lista", MessageBoxButtons.OK, MessageBoxIcon.Information);

            while (inf <= sup)
            {
                mitad = (inf + sup) / 2;

                if (list[mitad] == dato) return true;

                else if (list[mitad] > dato) sup = mitad - 1;

                else inf = mitad + 1;
            }

            return false;
        }


        private void FiltroCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BarraFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Busqueda == null || Busqueda.IsDisposed)
            {
                // El formulario aún no ha sido creado o ha sido cerrado
                Busqueda = new BusquedaReportes();
                Busqueda.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PdfPrint pdf;



            try
            {
                if (FiltroCombo.SelectedItem != null)
                {
                    if (FiltroCombo.SelectedItem.ToString() == "ZONA")
                    {
                        var x = MessageBox.Show("Asegurse de tener los reportes generados de la Zona: " + BarraFiltro.Text, "!!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (x == DialogResult.OK)
                        {
                            try
                            {
                                switch (BarraFiltro.Text)
                                {
                                    case "1":
                                        pdf = new PdfPrint("Reportes Zona 1");
                                        break;

                                    case "2":
                                        pdf = new PdfPrint("Reportes Zona 2");
                                        break;
                                    case "3":
                                        pdf = new PdfPrint("Reportes Zona 3");
                                        break;
                                    case "4":
                                        pdf = new PdfPrint("Reportes Zona 4");
                                        break;
                                    default:
                                        throw new Exception("Selección de zona inválida.");
                                }
                            }
                            catch (Exception a)
                            {
                                MessageBox.Show(a.Message, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else throw new Exception("No se ha seleccionado ningún elemento en el filtro.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }



}
