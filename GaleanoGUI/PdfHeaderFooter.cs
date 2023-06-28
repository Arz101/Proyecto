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

        public PdfHeaderFooter(string ruta)
        {
            this.ruta = ruta;
        }

        public PdfHeaderFooter() {}
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
        /*
        public void FontStyleHeader(string rutaArchivo)
        {
            //HeaderPart headerPart = wordDocument.MainDocumentPart.GetPartsOfType<HeaderPart>().FirstOrDefault();

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(rutaArchivo, true))
            {
                // Obtén la referencia al encabezado
                HeaderPart headerPart = wordDocument.MainDocumentPart.HeaderParts.FirstOrDefault();
                if (headerPart != null)
                {
                    // Accede al elemento Run dentro del encabezado
                    Run run = headerPart.Header.Descendants<Run>().FirstOrDefault();
                    if (run != null)
                    {
                        // Modifica las propiedades de fuente del Run
                        RunProperties runProperties = run.GetOrCreateChild<RunProperties>();
                        runProperties.RunFonts = new RunFonts() { Ascii = "Arial", HighAnsi = "Arial" };
                        runProperties.FontSize = new FontSize() { Val = "24" };
                        runProperties.Color = new Color() { Val = "0000FF" }; // Color azul

                        // Guarda los cambios en el encabezado
                        headerPart.Header.Save();
                    }
                }
            }

        }
        */
    }
}
