using System.IO;
using System.Diagnostics;

namespace GaleanoGUI
{
    class PdfPrint
    {
        string folderPath = @"C:\Users\adria\OneDrive\Desktop\Reportes\"; // Ruta de la carpeta que contiene los archivos PDF
        string[] pdfFiles;

        public PdfPrint(string ruta)
        {
            folderPath += ruta;
            pdfFiles = Directory.GetFiles(folderPath, "*.pdf");
        }

        public void print()
        {
            foreach (string pdfFile in pdfFiles)
            {
                PrintPdf(pdfFile);
            }
        }

        public void PrintPdf(string filePath)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = filePath,
                Verb = "PrintTo",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(psi)?.WaitForExit();
        }
    }
}