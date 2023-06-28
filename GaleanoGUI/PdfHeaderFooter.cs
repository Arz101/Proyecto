using System;
using System.IO;
using GaleanoDataAcess;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace GaleanoGUI
{
    class PdfHeaderFooter
    {
        private string ruta;

        public PdfHeaderFooter(string ruta)
        {
            this.ruta = ruta;
        }

        public PdfHeaderFooter() {}
        public void PDF(string ID, int x)
        {
            DatosC CLIENTE = new DatosC(ID);
            int seriaA = CLIENTE.CrearReportePorCodigoCliente();
            string NOMBREPDF = CLIENTE.nombre();
            string carpetaDestino;

            carpetaDestino = (x == 1) ? @"C:\Users\adria\OneDrive\Desktop\Reportes\" + ruta : @"C:\Users\adria\OneDrive\Desktop\Reportes\Reportes Individuales\";

            string nombreArchivo = NOMBREPDF + ".docx";
            string rutaArchivo = Path.Combine(carpetaDestino, nombreArchivo);
            string read = @"C:\Users\adria\OneDrive\Desktop\VS2019Trabajo\V1.5.2\GaleanoGUI\GaleanoGUI\diseño recibo.docx";

            // Abrir el documento Word original en modo de solo lectura

            Dictionary<string, string> valoresMarcadores = new Dictionary<string, string>
            {
                { "[NOMBRE_CLIENTE]", CLIENTE.nombre() },
                { "[NUMERO_DE_SR]", CLIENTE.CODIGO_CLIENTE },
                { "[NUMERO_DE_SRA]", Convert.ToString(seriaA) },
                { "[ACC]", CLIENTE.GetBanco() },
                { "[MES]", CLIENTE.GetFechaRegistro() },
                { "[FECHA]", CLIENTE.limiteFecha() },
                { "[CUOTA]", CLIENTE.getCUOTA().ToString("0.00") },
                { "[MORA]", CLIENTE.getMora().ToString("0.00") },
                { "[MULTA]", CLIENTE.getMulta().ToString("0.00") },
                { "[DONACION]", CLIENTE.getDonacion().ToString("0.00") },
                { "[TOTAL]", CLIENTE.getTOTAL().ToString("0.00") },
                { "[NUMERO_ZONA]", CLIENTE.getZona() }
            };
            

            using (DocX Document = DocX.Load(read))
            {
                foreach (var element in Document.Paragraphs)
                {
                    // Reemplazar los marcadores con los valores correspondientes
                    foreach (var marcador in valoresMarcadores)
                    {
                        if (element.Text.Contains(marcador.Key))
                        {
                            element.ReplaceText(marcador.Key, marcador.Value);
                        }
                    }
                }
                Document.SaveAs(rutaArchivo);
            }

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = false;

            // Crear una copia del documento original
            Microsoft.Office.Interop.Word.Document documentOriginal = wordApp.Documents.Open(rutaArchivo);

            nombreArchivo = NOMBREPDF + ".rtf";
            rutaArchivo = Path.Combine(carpetaDestino, nombreArchivo);

            // Guardar el documento como archivo RTF
            documentOriginal.SaveAs(rutaArchivo, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF);

            // Cerrar el documento sin guardar cambios
            documentOriginal.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);

            // Cerrar la aplicación de Word
            wordApp.Quit();
            try
            {
                string[] archivos = Directory.GetFiles(carpetaDestino, "*.docx");

                foreach (string archivo in archivos)
                {
                    File.Delete(archivo);
                }

                //MessageBox.Show("Archivos .docx eliminados correctamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al eliminar los archivos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        public void CrearDirectorios()
        {
            string carpetaPrincipal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reportes");
            string[] subcarpetas = { "Reportes Zona 1", "Reportes Zona 2", "Reportes Zona 3", "Reportes Zona 4", "Reportes Individuales"};
    
            try
            {
                // Verificar la existencia de la carpeta principal
                if (!Directory.Exists(carpetaPrincipal))
                {
                    // Crear la carpeta principal si no existe
                    Directory.CreateDirectory(carpetaPrincipal);
                    // Establecer atributos de solo lectura y oculto en la carpeta principal
                    
                    MessageBox.Show("Carpeta principal creada correctamente.");
                }
                
                // Crear las subcarpetas dentro de la carpeta principal
                foreach (string subcarpeta in subcarpetas)
                {
                    string rutaSubcarpeta = Path.Combine(carpetaPrincipal, subcarpeta);

                    // Verificar la existencia de cada subcarpeta
                    if (!Directory.Exists(rutaSubcarpeta))
                    {
                        // Crear la subcarpeta si no existe
                        Directory.CreateDirectory(rutaSubcarpeta);

                        // Establecer los atributos de solo lectura a la subcarpeta
                        DirectoryInfo subfolderInfo = new DirectoryInfo(rutaSubcarpeta);
                        subfolderInfo.Attributes |= FileAttributes.ReadOnly;
                        
                        MessageBox.Show(String.Format("Subcarpeta '{0}' creada correctamente.", subcarpeta));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo crear la carpeta: " + e.Message);
            }
        }
    }
}
