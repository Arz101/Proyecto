using System;
using System.IO;
using GaleanoDataAcess;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace GaleanoGUI
{
    class PdfHeaderFooter
    {
        private string ruta;
        private static object lockObject = new object();

        public PdfHeaderFooter(string ruta)
        {
            this.ruta = ruta;
        }

        public PdfHeaderFooter()
        {}

        /*
        // Override del método OnEndPage para agregar el encabezado y pie de página
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte cb = writer.DirectContent;

            // Encabezado
            PdfPTable header = new PdfPTable(1);
            //header.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            header.DefaultCell.Border = Rectangle.NO_BORDER;
            header.AddCell(new Phrase("", new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL)));

            float headerWidth = header.TotalWidth;
            float headerHeight = header.TotalHeight;
            float headerXPosition = (document.PageSize.Width - headerWidth) / 2;
            float headerYPosition = document.PageSize.Height - document.TopMargin - (headerHeight / 2);
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(baseFont, 11);
            cb.BeginText();
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ADCSMAPCG", headerXPosition, headerYPosition, 0);
            cb.EndText();

            // Nueva línea de texto dentro del encabezado
            string newLineText = @"COBRO POR SERVICIO DE AGUAPOTABLE";
            float newLineXPosition = headerXPosition - 100; // Ajustar la posición X según tus necesidades
            float newLineYPosition = headerYPosition - 20; // Descender 12 puntos
            cb.BeginText();
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, newLineText, newLineXPosition, newLineYPosition, 0);
            cb.EndText();

            // Posicionamiento del encabezado
            //header.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - document.TopMargin + header.TotalHeight, writer.DirectContent);

            // Pie de página
            
            
            PdfPTable footer = new PdfPTable(1);
            //footer.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            footer.DefaultCell.Border = Rectangle.NO_BORDER;
            // footer.AddCell(new Phrase("Cajero", new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL)));
            string tabs = "                                              ";
            float footerWidth = footer.TotalWidth;
            float footerHeight = footer.TotalHeight;
            float footerXPosition = (document.PageSize.Width - footerWidth) / 2 - 10;
            float footerYPosition = document.BottomMargin - (footerHeight / 2) + 400;
            baseFont = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(baseFont, 11);
            cb.BeginText();
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Cajero" + tabs + "      Sello de Banco", footerXPosition, footerYPosition, 0);
            cb.EndText();

            // Posicionamiento del pie de página
            //footer.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - footer.TotalHeight, writer.DirectContent);
        }
    */

        public void PDF(string ID, int x)
        {
            DatosC cl = new DatosC(ID);
            int seriaA = cl.CrearReportePorCodigoCliente();
            string NOMBREPDF = cl.nombre();
            string carpetaDestino;

            carpetaDestino = (x == 1) ? @"C:\Users\adria\OneDrive\Desktop\Reportes\" + ruta : $@"C:\Users\adria\OneDrive\Desktop\Reportes\Reportes Individuales\";

            string nombreArchivo = NOMBREPDF + ".docx";
            string rutaArchivo = Path.Combine(carpetaDestino, nombreArchivo);

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(rutaArchivo, WordprocessingDocumentType.Document))
            {
                
                // Crear la parte principal del documento
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Crear el contenido del documento
                mainPart.Document = new Document();

                // Crear las propiedades de sección
                SectionProperties sectionProperties = new SectionProperties();

                // Crear el tamaño de página personalizado
                PageSize pageSize = new PageSize()
                {
                    Width = 13970, // 21.59 cm en unidades de medio punto
                    Height = 21590 / 3
                };

                // Asignar el tamaño de página personalizado a las propiedades de sección
                sectionProperties.Append(pageSize);

                // Crear el encabezado de página
                HeaderReference headerReference = new HeaderReference()
                {
                    Type = HeaderFooterValues.Default,
                    Id = "header"
                };

                // Agregar la referencia al encabezado en las propiedades de la sección
                sectionProperties.Append(headerReference);

                // Crear la parte del encabezado
                HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>("header");

                // Crear el contenido del encabezado
                Header header = new Header(new Paragraph(new Run(new Text("@JUNTA ADMINISTRATIVA DE AGUA CANTON GALEANO, RECIBO POR SEVICIO DOTACION DE AGUA POTABLE POR" +
                    "BOMBEO ELECTRICO: ZONA EL BALLE, SALINAS, SANTA MARTA Y CUATRO MILPAS"))));

                // Asignar el contenido del encabezado a la parte del encabezado
                headerPart.Header = header;

                // Guardar los cambios en la parte del encabezado
                headerPart.Header.Save();


                // Asignar las propiedades de sección al documento
                mainPart.Document.Body = new Body(sectionProperties);

                // Crear un párrafo de ejemplo
                Paragraph paragraph = new Paragraph();

                string cadena = String.Format(@"
                                   ADCSMAPCG<br>
         {8}<br>

         Seria A No. {10}<br>

         Nombre: {0}<br>

         No.de Servicio {1}                                                Zona No. {2}<br>

         En concepto de Servicio de Agua Potable correspondiente al mes de {9} del Año 2023<br>

             
                                        DETALLE DE COBRO<br>
                     Cuota Normal de Agua potable                     $   {3}<br>
                     <br>
                     Cuota por Agregados                              $   {4}<br>

                     Cancelacion de Multas                            $   {5}<br>

                     Colaboraciones                                   $   {6}<br>

                     ________________________________________________________<br>

                     TOTAL A PAGAR                                    $   {7}<br>


                                  Fecha Limite de Pago: {11}", Convert.ToString(cl.nombre()), cl.CODIGO_CLIENTE, Convert.ToString(cl.getZona()), Convert.ToString(cl.getCUOTA()), Convert.ToString(cl.getMora()), Convert.ToString(cl.getMulta()), Convert.ToString(cl.getDonacion()), Convert.ToString(cl.getTOTAL()), cl.GetBanco(), cl.GetFechaRegistro(), seriaA, cl.limiteFecha());

                string[] cadenaNueva = cadena.Split(new string[] { "<br>" }, StringSplitOptions.None);

                foreach(var line in cadenaNueva)
                {
                    Run u = new Run(new Text(line) {Space = SpaceProcessingModeValues.Preserve });

                    // Agregar el elemento de texto al párrafo
                    paragraph.Append(u);

                    // Agregar un salto de línea
                    paragraph.Append(new Break());
                }
                // Agregar el párrafo al cuerpo del documento
                mainPart.Document.Body.Append(paragraph);

                // Guardar los cambios en el documento
                mainPart.Document.Save();
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
