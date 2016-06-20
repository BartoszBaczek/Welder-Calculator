using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Linq;
using WelderCalculator.Model;

namespace WelderCalculator.PDFUtilities
{
    public class PDFGenerator
    {
        private Document _document;

        private BaseMaterial _baseMaterial1;
        private BaseMaterial _baseMaterial2;
        private AdditiveMaterial _addMaterial;

        public PDFGenerator(BaseMaterial baseMaterial, BaseMaterial baseMaterial2, AdditiveMaterial addMaterial)
        {
            _baseMaterial1 = baseMaterial;
            _baseMaterial2 = baseMaterial2;
            _addMaterial = addMaterial;

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

            for (int i = 0; i < 14; i++)
            {
                column = table.AddColumn("1cm");
                column.Format.Alignment = ParagraphAlignment.Center;
            }
            
            // Create the header of the table
            Row row_1 = table.AddRow();
            row_1.HeadingFormat = true;
            row_1.Format.Alignment = ParagraphAlignment.Center;
            row_1.Format.Font.Bold = true;

            row_1.Cells[0].AddParagraph("Materialy");
            row_1.Cells[0].Format.Font.Bold = true;

           
            row_1.Cells[1].AddParagraph("C");
            row_1.Cells[2].AddParagraph("Si");
            row_1.Cells[3].AddParagraph("Mn");
            row_1.Cells[4].AddParagraph("P");
            row_1.Cells[5].AddParagraph("S");
            row_1.Cells[6].AddParagraph("Cr");
            row_1.Cells[7].AddParagraph("Ni");
            row_1.Cells[8].AddParagraph("Mo");
            row_1.Cells[9].AddParagraph("N");
            row_1.Cells[10].AddParagraph("Cu");
            row_1.Cells[11].AddParagraph("Nb");
            row_1.Cells[12].AddParagraph("Ti");
            row_1.Cells[13].AddParagraph("V");
            row_1.Cells[14].AddParagraph("Al");

            for (int i = 0; i < 15; i++)
            {
                row_1.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row_1.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }

            Row row_material1 = table.AddRow();
            row_material1.HeadingFormat = true;
            row_material1.Format.Alignment = ParagraphAlignment.Center;
            row_material1.Format.Font.Bold = false;

            row_material1.Cells[0].AddParagraph(_baseMaterial1.Name);
            row_material1.Cells[1].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.C).RealValue.ToString());
            row_material1.Cells[2].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Si).RealValue.ToString());
            row_material1.Cells[3].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Mn).RealValue.ToString());
            row_material1.Cells[4].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.P).RealValue.ToString());
            row_material1.Cells[5].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.S).RealValue.ToString());
            row_material1.Cells[6].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Cr).RealValue.ToString());
            row_material1.Cells[7].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Ni).RealValue.ToString());
            row_material1.Cells[8].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Mo).RealValue.ToString());
            row_material1.Cells[9].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.N).RealValue.ToString());
            row_material1.Cells[10].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Cu).RealValue.ToString());
            row_material1.Cells[11].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Nb).RealValue.ToString());
            row_material1.Cells[12].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Ti).RealValue.ToString());
            row_material1.Cells[13].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.V).RealValue.ToString());
            row_material1.Cells[14].AddParagraph(_baseMaterial1.GetElement(Category.OfElement.Al).RealValue.ToString());

            for (int i = 0; i < 15; i++)
                row_material1.Cells[i].Shading.Color = Colors.Aquamarine;

            Row row_material2 = table.AddRow();
            row_material2.HeadingFormat = true;
            row_material2.Format.Alignment = ParagraphAlignment.Center;
            row_material2.Format.Font.Bold = false;

            row_material2.Cells[0].AddParagraph(_baseMaterial2.Name);
            row_material2.Cells[1].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.C).RealValue.ToString());
            row_material2.Cells[2].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Si).RealValue.ToString());
            row_material2.Cells[3].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Mn).RealValue.ToString());
            row_material2.Cells[4].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.P).RealValue.ToString());
            row_material2.Cells[5].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.S).RealValue.ToString());
            row_material2.Cells[6].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Cr).RealValue.ToString());
            row_material2.Cells[7].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Ni).RealValue.ToString());
            row_material2.Cells[8].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Mo).RealValue.ToString());
            row_material2.Cells[9].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.N).RealValue.ToString());
            row_material2.Cells[10].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Cu).RealValue.ToString());
            row_material2.Cells[11].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Nb).RealValue.ToString());
            row_material2.Cells[12].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Ti).RealValue.ToString());
            row_material2.Cells[13].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.V).RealValue.ToString());
            row_material2.Cells[14].AddParagraph(_baseMaterial2.GetElement(Category.OfElement.Al).RealValue.ToString());

            for (int i = 0; i < 15; i++)
                row_material2.Cells[i].Shading.Color = Colors.YellowGreen;


            Row row_addMaterial = table.AddRow();
            row_addMaterial.HeadingFormat = true;
            row_addMaterial.Format.Alignment = ParagraphAlignment.Center;
            row_addMaterial.Format.Font.Bold = false;

            row_addMaterial.Cells[0].AddParagraph(_addMaterial.Name);
            row_addMaterial.Cells[1].AddParagraph(_addMaterial.GetElement(Category.OfElement.C).RealValue.ToString());
            row_addMaterial.Cells[2].AddParagraph(_addMaterial.GetElement(Category.OfElement.Si).RealValue.ToString());
            row_addMaterial.Cells[3].AddParagraph(_addMaterial.GetElement(Category.OfElement.Mn).RealValue.ToString());
            row_addMaterial.Cells[4].AddParagraph(_addMaterial.GetElement(Category.OfElement.P).RealValue.ToString());
            row_addMaterial.Cells[5].AddParagraph(_addMaterial.GetElement(Category.OfElement.S).RealValue.ToString());
            row_addMaterial.Cells[6].AddParagraph(_addMaterial.GetElement(Category.OfElement.Cr).RealValue.ToString());
            row_addMaterial.Cells[7].AddParagraph(_addMaterial.GetElement(Category.OfElement.Ni).RealValue.ToString());
            row_addMaterial.Cells[8].AddParagraph(_addMaterial.GetElement(Category.OfElement.Mo).RealValue.ToString());
            row_addMaterial.Cells[9].AddParagraph(_addMaterial.GetElement(Category.OfElement.N).RealValue.ToString());
            row_addMaterial.Cells[10].AddParagraph(_addMaterial.GetElement(Category.OfElement.Cu).RealValue.ToString());
            row_addMaterial.Cells[11].AddParagraph(_addMaterial.GetElement(Category.OfElement.Nb).RealValue.ToString());
            row_addMaterial.Cells[12].AddParagraph(_addMaterial.GetElement(Category.OfElement.Ti).RealValue.ToString());
            row_addMaterial.Cells[13].AddParagraph(_addMaterial.GetElement(Category.OfElement.V).RealValue.ToString());

            for (int i = 0; i < 15; i++)
                row_addMaterial.Cells[i].Shading.Color = Colors.LightPink;


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
