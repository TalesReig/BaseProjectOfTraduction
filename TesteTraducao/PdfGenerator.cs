using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using System.Collections.Generic;
using System.IO;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using System;

namespace TesteTraducao
{
    internal class PdfGenerator
    {
        public void GeneratePdf(List<GenericClass> items, string filename)
        {
            // Get the path to "MeusDocumentos"
            string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "C:\\MeusDocumentos\\");

            // Check if the folder exists; create it if it doesn't
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Create a new PDF document
            PdfDocument pdf = new PdfDocument(new PdfWriter(new FileStream(@"C:\MeusDocumentos\"+filename+".pdf", FileMode.Create)));

            // Set up the document
            Document document = new Document(pdf, PageSize.A4, true);

            // Define styles for header and table
            Style headerStyle = new Style()
                .SetBackgroundColor(new DeviceGray(0.5f))
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                .SetFontSize(16f)
                .SetTextAlignment(TextAlignment.CENTER);

            Style tableHeaderStyle = new Style()
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
                .SetFontSize(12f);

            Style tableCellStyle = new Style()
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                .SetFontSize(12f);

            // Create header
            Paragraph header = new Paragraph("Lista de Itens")
                .AddStyle(headerStyle);

            // Create table
            Table table = new Table(new float[] { 1, 3 })
                .UseAllAvailableWidth();

            // Add table headers
            table.AddHeaderCell(new Cell().Add(new Paragraph("ID")).AddStyle(tableHeaderStyle));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Nome")).AddStyle(tableHeaderStyle));

            // Add table cells
            foreach (GenericClass item in items)
            {
                table.AddCell(new Cell().Add(new Paragraph(item.id.ToString())).AddStyle(tableCellStyle));
                table.AddCell(new Cell().Add(new Paragraph(item.name)).AddStyle(tableCellStyle));
            }

            // Add header and table to the document
            document.Add(header);
            document.Add(table);

            // Close the document
            document.Close();
        }
    }
}
