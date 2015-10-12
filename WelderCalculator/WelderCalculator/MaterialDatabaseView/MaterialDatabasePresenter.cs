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

            _view.NumberCheckBox = true;
            _view.MinCheckBox = true;
            _view.MaxCheckBox = true;
            _view.RealCheckBox = true;
        }

        private void BindDataSourceToDataGridView()
        {
            DataTable table = CreateTable();

            _view.GridSource = table;
        }
        
        private DataTable CreateTable()
        {
            var table = new DataTable();
            
            CreateColumns(table);
            CreateRows(table);

            return table;
        }

        private List<Material> GetCurrentListOfMaterialsFromNormComboBox()
        {
            List<string> listOfNormsNames = _materialDataReader.GetSortedListOfMaterialsNormsNames();
            string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
            List<Material> listofMaterialsFromNorm = _materialDataReader.GetListOfMaterialsFromNorm(desiredNameOfNorm);

            return listofMaterialsFromNorm;
        }
        
        private void CreateColumns(DataTable table)
        {
            table.Columns.Add("Nazwa", typeof(string));

            if (_view.NumberCheckBox == true)
                table.Columns.Add("Numer", typeof(string));

            if (_view.CcheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("C min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("C max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("C real", typeof (double));
            }
            if (_view.SiCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Si min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Si max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Si real", typeof(double));
            }
            if (_view.MnCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Mn min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Mn max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Mn real", typeof(double));
            }
            if (_view.PcheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("P min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("P max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("P real", typeof(double));
            }
            if (_view.ScheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("S min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("S max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("S real", typeof(double));
            }
            if (_view.NcheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("N min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("N max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("N real", typeof(double));
            }
            if (_view.CrCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Cr min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Cr max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Cr real", typeof(double));
            }
            if (_view.MoCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Mo min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Mo max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Mo real", typeof(double));
            }
            if (_view.NbCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Nb min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Nb max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Nb real", typeof(double));
            } 
            if (_view.NiCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Ni min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Ni max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Ni real", typeof(double));
            }
            if (_view.TiCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Ti min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Ti max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Ti real", typeof(double));
            }
            if (_view.AlCheckBox)
            {
                if (_view.MinCheckBox)
                    table.Columns.Add("Al min", typeof(double));
                if (_view.MaxCheckBox)
                    table.Columns.Add("Al max", typeof(double));
                if (_view.RealCheckBox)
                    table.Columns.Add("Al real", typeof(double));
            }

            foreach (DataColumn column in table.Columns)
                column.AllowDBNull = true;
        }

        private void CreateRows(DataTable table)
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
                if (_view.CcheckBox == true)
                {
                    FillElementColumns(r, "C min", "C max", "C real", Category.OfElement.C, material);
                }
                if (_view.SiCheckBox)
                {
                    FillElementColumns(r, "Si min", "Si max", "Si real", Category.OfElement.Si, material);
                }
                if (_view.MnCheckBox)
                {
                    FillElementColumns(r, "Mn min", "Mn max", "Mn real", Category.OfElement.Mn, material);
                }
                if (_view.PcheckBox)
                {
                    FillElementColumns(r, "P min", "P max", "P real", Category.OfElement.P, material);
                }
                if (_view.ScheckBox)
                {
                    FillElementColumns(r, "S min", "S max", "S real", Category.OfElement.S, material);
                }
                if (_view.NcheckBox)
                {
                    FillElementColumns(r, "N min", "N max", "N real", Category.OfElement.N, material);
                }
                if (_view.CrCheckBox)
                {
                    FillElementColumns(r, "Cr min", "Cr max", "Cr real", Category.OfElement.Cr, material);
                }
                if (_view.MoCheckBox)
                {
                    FillElementColumns(r, "Mo min", "Mo max", "Mo real", Category.OfElement.Mo, material);
                }
                if (_view.NbCheckBox)
                {
                    FillElementColumns(r, "Nb min", "Nb max", "Nb real", Category.OfElement.Nb, material);
                }
                if (_view.NiCheckBox)
                {
                    FillElementColumns(r, "Ni min", "Ni max", "Ni real", Category.OfElement.Ni, material);
                }
                if (_view.TiCheckBox)
                {
                    FillElementColumns(r, "Ti min", "Ti max", "Ti real", Category.OfElement.Ti, material);
                }
                if (_view.AlCheckBox)
                {
                    FillElementColumns(r, "Al min", "Al max", "Al real", Category.OfElement.Al, material);
                }

                table.Rows.Add(r); 
            }
            
        }

        private void FillElementColumns(DataRow row, string min, string max, string real, Category.OfElement element, Material material)
        {
            Element materialElement = material.GetElement(element);
            if (_view.MinCheckBox)
            {
                if (material.GetElement(element).Min == null)
                    row[min] = DBNull.Value;
                else
                    row[min] = materialElement.Min;
            }

            if (_view.MaxCheckBox)
            {
                if (material.GetElement(element).Max == null)
                    row[max] = DBNull.Value;
                else
                    row[max] = materialElement.Max;
            }

            if (_view.RealCheckBox)
            {
                if (material.GetElement(element).RealValue == null)
                    row[real] = DBNull.Value;
                else
                    row[real] = materialElement.RealValue;
            }
            
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

        public void OnMaterialCheckBoxChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
        }

        public void OnViewOptionsCheckBoxChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
        }
    }
}
