using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Serialization;

namespace WelderCalculator.MaterialDatabaseView
{
    public class MaterialDatabasePresenter
    {
        private readonly IMaterialDatabaseView _view;

        private readonly IRepository _repository;
        private readonly MaterialDataReader _materialDataReader;

        public MaterialDatabasePresenter(IMaterialDatabaseView view,  IRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _materialDataReader = new MaterialDataReader();
        }

        public void Init()
        {
            LoadNormsComboBox();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
        }

        private void LoadNormsComboBox()  
        {
            _view.NormsList = _materialDataReader.GetSortedListOfMaterialsNormsNames();
        }

        private void MakeAllCheckBoxesChecked()
        {
            _view.CcheckBox = true;
            _view.SiCheckBox = true;
            _view.MnCheckBox = true;
            _view.PcheckBox = true;
            _view.ScheckBox = true;
            _view.NcheckBox = true;
            _view.CrCheckBox = true;
            _view.MoCheckBox = true;
            _view.NbCheckBox = true;
            _view.NiCheckBox = true;
            _view.TiCheckBox = true;
            _view.AlCheckBox = true;
        }

        private void BindDataSourceToDataGridView()
        {
            //_view.GridSource = listofMaterialsFromNorm;

            DataTable table = CreateTable();

            _view.GridSource = table;
        }
        
        private DataTable CreateTable()
        {
            var table = new DataTable();

            /* Create columns */
            table.Columns.Add("Nazwa", typeof(string));
            table.Columns.Add("Numer", typeof(string));
            
            AddColumnsForEachElements(table);


            /* Create rows */
            PutMaterialsInRows(table);

            return table;
        }

        private List<Material> GetCurrentListOfMaterialsFromNormComboBox()
        {
            List<string> listOfNormsNames = _materialDataReader.GetSortedListOfMaterialsNormsNames();
            string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
            List<Material> listofMaterialsFromNorm = _materialDataReader.GetListOfMaterialsFromNorm(desiredNameOfNorm);

            return listofMaterialsFromNorm;
        }
        
        private void AddColumnsForEachElements(DataTable table)
        {
            if (_view.CcheckBox == true)
            {
                table.Columns.Add("C min", typeof(double));
                table.Columns.Add("C max", typeof(double));
                table.Columns.Add("C real", typeof (double));
            }
            if (_view.SiCheckBox == true)
            {
                table.Columns.Add("Si min", typeof(double));
                table.Columns.Add("Si max", typeof(double));
                table.Columns.Add("Si real", typeof(double));
            }
            if (_view.MnCheckBox == true)
            {
                table.Columns.Add("Mn min", typeof(double));
                table.Columns.Add("Mn max", typeof(double));
                table.Columns.Add("Mn real", typeof(double));
            }
            if (_view.PcheckBox == true)
            {
                table.Columns.Add("P min", typeof(double));
                table.Columns.Add("P max", typeof(double));
                table.Columns.Add("P real", typeof(double));
            }
            if (_view.ScheckBox == true)
            {
                table.Columns.Add("S min", typeof(double));
                table.Columns.Add("S max", typeof(double));
                table.Columns.Add("S real", typeof(double));
            }
            if (_view.NcheckBox == true)
            {
                table.Columns.Add("N min", typeof(double));
                table.Columns.Add("N max", typeof(double));
                table.Columns.Add("N real", typeof(double));
            }
            if (_view.CrCheckBox == true)
            {
                table.Columns.Add("Cr min", typeof(double));
                table.Columns.Add("Cr max", typeof(double));
                table.Columns.Add("Cr real", typeof(double));
            }
            if (_view.MoCheckBox == true)
            {
                table.Columns.Add("Mo min", typeof(double));
                table.Columns.Add("Mo max", typeof(double));
                table.Columns.Add("Mo real", typeof(double));
            }
            if (_view.NbCheckBox == true)
            {
                table.Columns.Add("Nb min", typeof(double));
                table.Columns.Add("Nb max", typeof(double));
                table.Columns.Add("Nb real", typeof(double));
            } 
            if (_view.NiCheckBox == true)
            {
                table.Columns.Add("Ni min", typeof(double));
                table.Columns.Add("Ni max", typeof(double));
                table.Columns.Add("Ni real", typeof(double));
            }
            if (_view.TiCheckBox == true)
            {
                table.Columns.Add("Ti min", typeof(double));
                table.Columns.Add("Ti max", typeof(double));
                table.Columns.Add("Ti real", typeof(double));
            }
            if (_view.AlCheckBox == true)
            {
                table.Columns.Add("Al min", typeof(double));
                table.Columns.Add("Al max", typeof(double));
                table.Columns.Add("Al real", typeof(double));
            }

            foreach (DataColumn column in table.Columns)
                column.AllowDBNull = true;
        }

        private void PutMaterialsInRows(DataTable table)
        {
            DataColumnCollection columns = table.Columns;
            List<Material> materials = GetCurrentListOfMaterialsFromNormComboBox();
            foreach (var material in materials)
            {
                DataRow r = table.NewRow();
                if (columns.Contains("Nazwa"))
                    r["Nazwa"] = material.Name;
                if (columns.Contains("Numer"))
                    r["Numer"] = material.Number;
                if (columns.Contains("C min"))
                {
                    FillElementColumns(r, "C min", "C max", "C real", Category.OfElement.C, material);
                }
                if (columns.Contains("Si min"))
                {
                    FillElementColumns(r, "Si min", "Si max", "Si real", Category.OfElement.Si, material);
                }
                if (columns.Contains("Mn min"))
                {
                    FillElementColumns(r, "Mn min", "Mn max", "Mn real", Category.OfElement.Mn, material);
                }
                if (columns.Contains("P min"))
                {
                    FillElementColumns(r, "P min", "P max", "P real", Category.OfElement.P, material);
                }
                if (columns.Contains("S min"))
                {
                    FillElementColumns(r, "S min", "S max", "S real", Category.OfElement.S, material);
                }
                if (columns.Contains("N min"))
                {
                    FillElementColumns(r, "N min", "N max", "N real", Category.OfElement.N, material);
                }
                if (columns.Contains("Cr min"))
                {
                    FillElementColumns(r, "Cr min", "Cr max", "Cr real", Category.OfElement.Cr, material);
                }
                if (columns.Contains("Mo min"))
                {
                    FillElementColumns(r, "Mo min", "Mo max", "Mo real", Category.OfElement.Mo, material);
                }
                if (columns.Contains("Nb min"))
                {
                    FillElementColumns(r, "Nb min", "Nb max", "Nb real", Category.OfElement.Nb, material);
                }
                if (columns.Contains("Ni min"))
                {
                    FillElementColumns(r, "Ni min", "Ni max", "Ni real", Category.OfElement.Ni, material);
                }
                if (columns.Contains("Ti min"))
                {
                    FillElementColumns(r, "Ti min", "Ti max", "Ti real", Category.OfElement.Ti, material);
                }
                if (columns.Contains("Al min"))
                {
                    FillElementColumns(r, "Al min", "Al max", "Al real", Category.OfElement.Al, material);
                }

                table.Rows.Add(r); 
            }
            
        }

        private void FillElementColumns(DataRow row, string min, string max, string real, Category.OfElement element, Material material)
        {
            Element materialElement = material.GetElement(element);
            if (material.GetElement(element).Min == null)
                row[min] = DBNull.Value;
            else
                row[min] = materialElement.Min;

            if (material.GetElement(element).Max == null)
                row[max] = DBNull.Value;
            else
                row[max] = materialElement.Max;

            if (material.GetElement(element).RealValue == null)
                row[real] = DBNull.Value;
            else
                row[real] = materialElement.RealValue;
        }

        private void SetDataGridViewColumnsWidth()
        {
            foreach ( DataGridViewColumn column in _view.DataGridView.Columns)
            {
                column.Width = column.HeaderText.Length*12;
            }
        }
    
        /*Event handling*/

        public void OnSelectedIndexChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
        }

        public void OnCheckBoxChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
        }
    }
}
