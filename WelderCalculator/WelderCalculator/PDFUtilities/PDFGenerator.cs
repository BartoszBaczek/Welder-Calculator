using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Linq;

namespace WelderCalculator.PDFUtilities
{
    public class PDFGenerator
    {
        private Document _document;

        public PDFGenerator()
        {
            _document = new Document();
            Section section = _document.AddSection();

            AddHeader(section);
            AddTable(section);

            _document.UseCmykColor = true;
            const bool unicode = false;
            const PdfFontEmbedding embedding = PdfFontEmbedding.Always;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);
            pdfRenderer.Document = _document;
            pdfRenderer.RenderDocument();
            string filename = RandomString() + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

        private void AddHeader(Section section)
        {
            Paragraph headerParagraph = section.Headers.Primary.AddParagraph();

            headerParagraph.AddText("WelderCalc\n");
            headerParagraph.Format.Font.Size = 14;
            headerParagraph.Format.Alignment = ParagraphAlignment.Right;

            headerParagraph.Format.Borders.Bottom.Visible = true;
            headerParagraph.Format.Borders.Bottom.Color = Colors.Aqua;
            headerParagraph.Format.Borders.Bottom.Width = 3;
        }

        private void AddTable(Section section)
        {
            Table table = section.AddTable();
            table.Style = "Table";

            table.Borders.Color = Colors.Black;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = table.AddColumn("2cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;

            row.Cells[0].AddParagraph("Materialy");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[1].AddParagraph("C");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[1].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[2].AddParagraph("Si");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[3].AddParagraph("Mn");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[4].AddParagraph("P");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[5].AddParagraph("S");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[5].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[6].AddParagraph("Cr");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[6].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[7].AddParagraph("Ni");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[7].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[8].AddParagraph("Mo");
            row.Cells[8].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[9].AddParagraph("N");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[9].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[10].AddParagraph("Cu");
            row.Cells[10].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[10].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[11].AddParagraph("Nb");
            row.Cells[11].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[11].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[12].AddParagraph("Ti");
            row.Cells[12].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[12].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[13].AddParagraph("V");
            row.Cells[13].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[13].VerticalAlignment = VerticalAlignment.Center;

            row.Cells[14].AddParagraph("Al");
            row.Cells[14].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[14].VerticalAlignment = VerticalAlignment.Center;

            // Create first row of the table
            //row = table.AddRow();
            //row.HeadingFormat = true;
            //row.Format.Alignment = ParagraphAlignment.Center;
            //row.Format.Font.Bold = true;
            //row.Shading.Color = Colors.Aquamarine;
            //row.Cells[1].AddParagraph("Quantity");
            //row.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[2].AddParagraph("Unit Price");
            //row.Cells[2].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[3].AddParagraph("Discount (%)");
            //row.Cells[3].Format.Alignment = ParagraphAlignment.Left;
            //row.Cells[4].AddParagraph("Taxable");
            //row.Cells[4].Format.Alignment = ParagraphAlignment.Left;


            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.Single, 2, Color.Empty);
        }

        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
