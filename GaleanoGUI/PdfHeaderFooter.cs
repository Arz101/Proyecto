using System;
using System.IO;
using GaleanoDataAcess;
using System.Windows.Forms;
using System.Collections.Generic;
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
                { "[NUMERO_DE_SRA]", Convert.ToString(seriaA) }
                // Agrega más pares de marcadores y valores según tus necesidades
            };

            // Abrir el archivo original

            using (DocX documentOriginal = DocX.Load(read))
            {
                // Realizar modificaciones en el documento original
                // ...

                // Guardar el documento original en un flujo de memoria
                MemoryStream memoryStream = new MemoryStream();
                documentOriginal.SaveAs(memoryStream);

                // Crear una nueva instancia de DocX a partir del flujo de memoria
                memoryStream.Position = 0;
                using (DocX documentCopia = DocX.Load(memoryStream))
                {
                    // Guardar el documento clonado en una ubicación diferente

                    foreach (var marcador in valoresMarcadores)
                    {
                        // Buscar y reemplazar en todos los párrafos del documento
                        foreach (var element in documentCopia.Paragraphs)
                        {
                            element.ReplaceText(marcador.Key, marcador.Value);
                        }
                    }

                    documentCopia.SaveAs(rutaArchivo);
                }
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
