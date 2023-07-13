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
        ConectionX sql = new ConectionX();

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
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = NOMBREPDF + ".docx";
            string rutaArchivo;
            Dictionary<int, string> rutas = new Dictionary<int, string>()
            {
                {1, desktop + @"\Reportes\" + ruta},
                {2, desktop + @"\Reportes\Reportes Individuales\"},
                {3, desktop + @"\Reportes\Reportes Inactivos\" },
            };

            bool r = sql.VerificarFueraDeSistema(ID);

            rutaArchivo = r ? rutas[3] : (x != 0 ? rutas[1] : rutas[2]);

            rutaArchivo += sql.VerificarSiElClienteAPagado(ID) ? @"NORMAL\" + nombreArchivo : @"MORA\" + nombreArchivo;

            string read = @"C:\Users\adria\OneDrive\Desktop\VS2019Trabajo\V1.5.2\GaleanoGUI\GaleanoGUI\diseño recibo.docx";


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

            //rutaArchivo =  sql.VerificarFueraDeSistema(ID) ? @"C:\Users\adria\OneDrive\Desktop\Reportes\Reportes Inactivos\" + NOMBREPDF : Path.Combine(carpetaDestino, nombreArchivo);

            // Guardar el documento como archivo RTF
            documentOriginal.SaveAs(rutaArchivo.Replace(".docx", ".rtf"), Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF);

            // Cerrar el documento sin guardar cambios
            documentOriginal.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges);

            // Cerrar la aplicación de Word
            wordApp.Quit();
            
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    File.Delete(rutaArchivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "A");
            }
        }

    
        public void CrearDirectorios()
        {
            string carpetaPrincipal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reportes");
            string[] subcarpetas = { "Reportes Zona 1", "Reportes Zona 2", "Reportes Zona 3", "Reportes Zona 4", "Reportes Individuales", "Reportes Inactivos"};

            Dictionary<string, List<string>> carpetas = new Dictionary<string, List<string>>()
            {
                { "Reportes Zona 1", new List<string>{ "NORMAL", "MORA" } },
                { "Reportes Zona 2", new List<string>{ "NORMAL", "MORA" } },
                { "Reportes Zona 3", new List<string>{ "NORMAL", "MORA" } },
                { "Reportes Zona 4", new List<string>{ "NORMAL", "MORA" } },
                { "Reportes Individuales", new List<string>{ "NORMAL", "MORA" } },
                { "Reportes Inactivos" , new List<string>{"NORMAL", "MORA"} }
            };

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

                foreach (var ptr in carpetas)
                {
                    string interFolder = Path.Combine(carpetaPrincipal, ptr.Key);
                    foreach (var value in ptr.Value)
                    {
                        if (!Directory.Exists(Path.Combine(interFolder, value)))
                        {
                            Directory.CreateDirectory(Path.Combine(interFolder, value));
                            MessageBox.Show(String.Format("carpeta interna '{0}' en {1} creada correctamente.", value, ptr.Key));
                        }
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
