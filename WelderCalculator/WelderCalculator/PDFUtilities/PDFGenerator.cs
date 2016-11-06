using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Linq;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.PDFUtilities
{
    public enum PdfFor
    {
        Schaeffler,
        DeLong,
        WRC1992
    }

    public class PDFGenerator
    {
        private Document _document;

        private BaseMaterial _baseMaterial1;
        private BaseMaterial _baseMaterial2;
        private AdditiveMaterial _addMaterial;

        private string _schaefflerFerriteQuantity;
        private string _schaefflerPhase;

        private string _deLongPhase;
        private string _deLongFerriteContent;
        private string _deLongFerriticeNumber;

        private string _wrcPhase;
        private string _wrcFerriticNumber;

        private PdfFor _pdfFor;

        public PDFGenerator(PdfFor pdfFor, 
            BaseMaterial baseMaterial, 
            BaseMaterial baseMaterial2, 
            AdditiveMaterial addMaterial, 
            double addMaterialQuantity, 
            string schaefferFerriteQuantity,
            string schaefflerPhase,
            string deLongPhase,
            string deLongFerriteContent,
            string deLongFerriticNumber,
            string wrcPhase,
            string wrcFerriticNumber)
        {
            _pdfFor = pdfFor;
            _baseMaterial1 = baseMaterial;
            _baseMaterial2 = baseMaterial2;
            _addMaterial = addMaterial;
            _schaefflerPhase = schaefflerPhase;
            _schaefflerFerriteQuantity = schaefferFerriteQuantity;
            _deLongPhase = deLongPhase;
            _deLongFerriteContent = deLongFerriteContent;
            _deLongFerriticeNumber = deLongFerriticNumber;
            _wrcPhase = wrcPhase;
            _wrcFerriticNumber = wrcFerriticNumber;

            _document = new Document();
            Section section = _document.AddSection();

            AddHeader(section);

            AddInputDataSection(section, "Dane wejsciowe");
            AddEmptySpace(section, 0.1);

            AddElementsTable(section);
            AddEmptySpace(section, 0.1);

            AddEquivalentsTable(section, addMaterialQuantity);
            AddEmptySpace(section, 0.5);

            AddInputDataSection(section, "Dane wyjściowe");
            AddEmptySpace(section, 0.5);

            AddMainChartImage(section);
            if (pdfFor == PdfFor.Schaeffler)
            {
                AddSchaefflerLegendImage(section);
                AddEmptySpace(section, 0.5);

                addSchaefflerOutputData(section);
            }
            else if (pdfFor == PdfFor.DeLong)
            {
                AddDeLongLegendImage(section);
                AddEmptySpace(section, 0.5);
                addDeLongOutputData(section);
                AddMinimapChartImage(section);
            }
            else if (pdfFor == PdfFor.WRC1992)
            {
                AddWrcLegendImage(section);
                AddEmptySpace(section, 0.5);
                AddWrcOutputData(section);
                AddMinimapChartImage(section);
            }
            
            // AddFinalMaterialData
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

            headerParagraph.AddText("WelderCalc - Raport\n");
            headerParagraph.Format.Font.Size = 10;
            headerParagraph.Format.Alignment = ParagraphAlignment.Right;

            headerParagraph.Format.Borders.Bottom.Visible = true;
            headerParagraph.Format.Borders.Bottom.Color = Colors.Aqua;
            headerParagraph.Format.Borders.Bottom.Width = 3;

        }

        private void AddInputDataSection(Section section, string text)
        {
            Table table = section.AddTable();
            table.Style = "Table";
            table.Format.Font.Size = 8;

            table.Borders.Color = Colors.Black;
            table.Borders.Width = 0;
            table.Borders.Top.Visible = false;
            table.Borders.Left.Visible = false;
            table.Borders.Right.Visible = false;

            table.Borders.Bottom.Color = Colors.Black;
            table.Borders.Bottom.Width = 0.25;
            table.Borders.Bottom.Visible = true;

            Column column = table.AddColumn("16cm");
            column.Format.Alignment = ParagraphAlignment.Left;

            Row row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].AddParagraph(text);

            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.DashSmallGap, 0.25, Color.Empty);
        }

        private void AddElementsTable(Section section)
        {
            Table table = section.AddTable();
            table.Style = "Table";
            table.Format.Font.Size = 8;

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

        private void AddEmptySpace(Section section, double height)
        {
            Table table = section.AddTable();
            table.Style = "Table";

            table.Borders.Color = Color.Empty;
            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;
            table.Borders.Color = Color.Empty;
            // Before you can add a row, you must define the columns
            Column column = table.AddColumn("16cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            // Create the header of the table
            Row row_1 = table.AddRow();
            row_1.Format.Alignment = ParagraphAlignment.Center;
            
            row_1.Cells[0].Format.Alignment = ParagraphAlignment.Center;
            row_1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            row_1.Height = new Unit(height, UnitType.Centimeter);
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.Single, 0, Color.Empty);
        }

        private void AddEquivalentsTable(Section section, double addMaterialQuantity)
        {
            Table table = section.AddTable();
            table.Style = "Table";
            table.Format.Font.Size = 8;

            table.Borders.Color = Colors.Black;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            Column column = table.AddColumn("5cm");
            for (int i = 0; i < 2; i++)
            {
                column = table.AddColumn("3cm");
                column.Format.Alignment = ParagraphAlignment.Center;
            }

            Row tableHeaderRow = table.AddRow();
            tableHeaderRow.HeadingFormat = true;
            tableHeaderRow.Format.Alignment = ParagraphAlignment.Center;
            tableHeaderRow.Format.Font.Bold = true;

            tableHeaderRow.Cells[0].AddParagraph("Material");

            tableHeaderRow.Cells[0].Format.Font.Bold = true;
            tableHeaderRow.Cells[1].AddParagraph("CrEq");
            tableHeaderRow.Cells[1].Format.Font.Bold = true;
            tableHeaderRow.Cells[2].AddParagraph("NiEq");
            tableHeaderRow.Cells[2].Format.Font.Bold = true;

            // TODO TYLKO DLA WRC1992
            Row baseMaterial1Row = table.AddRow();
            baseMaterial1Row.HeadingFormat = true;
            baseMaterial1Row.Format.Alignment = ParagraphAlignment.Center;
            baseMaterial1Row.Shading.Color = Colors.Aquamarine;
            baseMaterial1Row.Cells[0].AddParagraph(_baseMaterial1.Name);
            baseMaterial1Row.Cells[1].AddParagraph(_baseMaterial1.CrEqWRC1992.ToString());
            baseMaterial1Row.Cells[2].AddParagraph(_baseMaterial1.CrEqWRC1992.ToString());


            Row baseMaterial2Row = table.AddRow();
            baseMaterial2Row.HeadingFormat = true;
            baseMaterial2Row.Format.Alignment = ParagraphAlignment.Center;
            baseMaterial2Row.Shading.Color = Colors.YellowGreen;
            baseMaterial2Row.Cells[0].AddParagraph(_baseMaterial2.Name);
            baseMaterial2Row.Cells[1].AddParagraph(_baseMaterial2.CrEqWRC1992.ToString());
            baseMaterial2Row.Cells[2].AddParagraph(_baseMaterial2.CrEqWRC1992.ToString());

            Row addMaterialRow = table.AddRow();
            addMaterialRow.HeadingFormat = true;
            addMaterialRow.Format.Alignment = ParagraphAlignment.Center;
            addMaterialRow.Shading.Color = Colors.LightPink;
            addMaterialRow.Cells[0].AddParagraph(_addMaterial.Name);
            addMaterialRow.Cells[1].AddParagraph(_addMaterial.CrEqWRC1992.ToString());
            addMaterialRow.Cells[2].AddParagraph(_addMaterial.CrEqWRC1992.ToString());

            Row addMaterialQuantityRow = table.AddRow();
            addMaterialQuantityRow.HeadingFormat = true;
            addMaterialQuantityRow.Format.Alignment = ParagraphAlignment.Center;
            addMaterialQuantityRow.Cells[0].MergeRight = 1;
            addMaterialQuantityRow.Cells[0].AddParagraph("% materialu dodatkowego");
            addMaterialQuantityRow.Cells[0].Format.Font.Bold = true;
            addMaterialQuantityRow.Cells[2].AddParagraph(addMaterialQuantity.ToString());
            addMaterialQuantityRow.Cells[2].Format.Font.Bold = true;

            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.Single, 2, Color.Empty);
        }
            
        private void AddMainChartImage(Section section)
        {
            DataConnector dataConnector = new DataConnector("asd");
            section.AddImage(dataConnector.PathToMainChartImage());
        }

        private void AddMinimapChartImage(Section section)
        {
            DataConnector dataConnector = new DataConnector("asdad");
            section.AddImage(dataConnector.PathToMinimapChartImage());
        }

        private void AddSchaefflerLegendImage(Section section)
        {
            DataConnector dataConnector = new DataConnector("asd");
            section.AddImage(dataConnector.PathToSchaefflerDiagramLegendImage());
        }

        private void AddDeLongLegendImage(Section section)
        {
            DataConnector dataConnector = new DataConnector("asd");
            section.AddImage(dataConnector.PathToDeLongDiagramLegendImage());
        }

        private void AddWrcLegendImage(Section section)
        {
            DataConnector dataConnector = new DataConnector("asd");
            section.AddImage(dataConnector.PathToWrcDiagramLegendImage());
        }

        private void AddOutputData(Section section, float CrEq, float NiEq)
        {
            Table table = section.AddTable();
            table.Style = "Table";
        }

        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        private void addSchaefflerOutputData(Section section)
        {
            Table table = section.AddTable();
            table.Style = "Table";
            table.Format.Font.Size = 8;

            table.Borders.Color = Colors.Black;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = table.AddColumn("6cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            for (int i = 0; i < 1; i++)
            {
                column = table.AddColumn("6cm");
                column.Format.Alignment = ParagraphAlignment.Center;
            }

            // Create the header of the table
            Row row_1 = table.AddRow();
            row_1.HeadingFormat = true;
            row_1.Format.Alignment = ParagraphAlignment.Center;
            row_1.Format.Font.Bold = true;

            row_1.Cells[0].AddParagraph("Faza");
            row_1.Cells[1].AddParagraph(_schaefflerPhase);

            Row row_2 = table.AddRow();
            row_2.HeadingFormat = true;
            row_2.Format.Alignment = ParagraphAlignment.Center;
            row_2.Format.Font.Bold = true;

            row_2.Cells[0].AddParagraph("Zawartość ferrytu");
            row_2.Cells[1].AddParagraph(_schaefflerFerriteQuantity);

            for (int i = 0; i < 1; i++)
            {
                row_2.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row_2.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.Single, 2, Color.Empty);
        }

        private void addDeLongOutputData(Section section)
        {
            Table table = section.AddTable();
            table.Style = "Table";
            table.Format.Font.Size = 8;

            table.Borders.Color = Colors.Black;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = table.AddColumn("6cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            for (int i = 0; i < 1; i++)
            {
                column = table.AddColumn("6cm");
                column.Format.Alignment = ParagraphAlignment.Center;
            }

            // Create the header of the table
            Row row_1 = table.AddRow();
            row_1.HeadingFormat = true;
            row_1.Format.Alignment = ParagraphAlignment.Center;
            row_1.Format.Font.Bold = true;

            row_1.Cells[0].AddParagraph("Faza");
            row_1.Cells[0].Format.Font.Bold = true;
            row_1.Cells[1].AddParagraph(_deLongPhase);


            Row row_2 = table.AddRow();
            row_2.HeadingFormat = true;
            row_2.Format.Alignment = ParagraphAlignment.Center;
            row_2.Format.Font.Bold = true;

            row_2.Cells[0].AddParagraph("Zawartość ferrytu");
            row_2.Cells[0].Format.Font.Bold = true;
            row_2.Cells[1].AddParagraph(_deLongFerriteContent);


            Row row_3 = table.AddRow();
            row_3.HeadingFormat = true;
            row_3.Format.Alignment = ParagraphAlignment.Center;
            row_3.Format.Font.Bold = true;

            row_3.Cells[0].AddParagraph("Liczba ferrytyczna");
            row_3.Cells[0].Format.Font.Bold = true;
            row_3.Cells[1].AddParagraph(_deLongFerriticeNumber);

            for (int i = 0; i < 1; i++)
            {
                row_1.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row_1.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.Single, 2, Color.Empty);
        }

        private void AddWrcOutputData(Section section)
        {
            Table table = section.AddTable();
            table.Style = "Table";
            table.Format.Font.Size = 8;

            table.Borders.Color = Colors.Black;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = table.AddColumn("6cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            for (int i = 0; i < 1; i++)
            {
                column = table.AddColumn("6cm");
                column.Format.Alignment = ParagraphAlignment.Center;
            }

            // Create the header of the table
            Row row_1 = table.AddRow();
            row_1.HeadingFormat = true;
            row_1.Format.Alignment = ParagraphAlignment.Center;
            row_1.Format.Font.Bold = true;

            row_1.Cells[0].AddParagraph("Faza");
            row_1.Cells[0].Format.Font.Bold = true;
            row_1.Cells[1].AddParagraph(_wrcPhase);


            Row row_2 = table.AddRow();
            row_2.HeadingFormat = true;
            row_2.Format.Alignment = ParagraphAlignment.Center;
            row_2.Format.Font.Bold = true;

            row_2.Cells[0].AddParagraph("Liczba ferrytyczna");
            row_2.Cells[0].Format.Font.Bold = true;
            row_2.Cells[1].AddParagraph(_wrcFerriticNumber);

            for (int i = 0; i < 1; i++)
            {
                row_1.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row_1.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
            table.SetEdge(0, 0, table.Columns.Count, table.Rows.Count, Edge.Box, BorderStyle.Single, 2, Color.Empty);
        }
    }
}
