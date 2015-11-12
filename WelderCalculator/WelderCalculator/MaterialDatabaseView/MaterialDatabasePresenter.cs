using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.MaterialDatabasePropertiesView;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabaseView
{
    public class MaterialDatabasePresenter
    {
        private readonly IMaterialDatabaseView _view;
        private readonly MaterialDataConnector _dataConnector;

        public MaterialDatabasePresenter(IMaterialDatabaseView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new MaterialDataConnector();
        }

        public void Init()
        {
            LoadNormsComboBox();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
            UpdateEquivalents();
        }

        private void LoadNormsComboBox()  
        {
            _view.NormsList = _dataConnector.GetSortedListOfMaterialsNormsNames();
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
            _view.VCheckBox = true;
            _view.CuCheckBox = true;

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

        private IEnumerable<Material> GetCurrentListOfMaterialsFromNormComboBox()
        {
            List<string> listOfNormsNames = _dataConnector.GetSortedListOfMaterialsNormsNames();
            string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
            List<Material> listofMaterialsFromNorm = _dataConnector.GetListOfMaterialsFromNorm(desiredNameOfNorm);

            return listofMaterialsFromNorm;
        }
        
        private void CreateColumns(DataTable table)
        {
            var orderOfElements = _dataConnector.GetLastSavedOrderOfElements();

            table.Columns.Add("Nazwa", typeof (string));

            if (_view.NumberCheckBox)
                table.Columns.Add("Numer", typeof (string));

            for (int i = 0; i < orderOfElements.Count; i++)
            {
                if ((orderOfElements[i]== Category.OfElement.C    &&    _view.CcheckBox)  ||
                    (orderOfElements[i]== Category.OfElement.Si   &&    _view.SiCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.Mn   &&    _view.MnCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.P    &&    _view.PcheckBox)  ||
                    (orderOfElements[i]== Category.OfElement.S    &&    _view.ScheckBox)  ||
                    (orderOfElements[i]== Category.OfElement.N    &&    _view.NcheckBox)  ||
                    (orderOfElements[i]== Category.OfElement.Cr   &&    _view.CrCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.Mo   &&    _view.MoCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.Nb   &&    _view.NbCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.Ni   &&    _view.NiCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.Ti   &&    _view.TiCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.Al   &&    _view.AlCheckBox) ||
                    (orderOfElements[i]== Category.OfElement.V    &&    _view.VCheckBox)  ||
                    (orderOfElements[i] == Category.OfElement.Cu   &&   _view.CuCheckBox))
                {
                    if (_view.MinCheckBox)
                        table.Columns.Add(Enum.GetName(typeof(Category.OfElement), orderOfElements[i]) + " min", typeof(double));
                    if (_view.MaxCheckBox)
                        table.Columns.Add(Enum.GetName(typeof(Category.OfElement), orderOfElements[i]) + " max", typeof(double));
                    if (_view.RealCheckBox)
                        table.Columns.Add(Enum.GetName(typeof(Category.OfElement), orderOfElements[i]) + " real", typeof(double));
                }
            }
        }

        private void CreateRows(DataTable table)
        {
            var columns = table.Columns;
            var materialsToBind = GetCurrentListOfMaterialsFromNormComboBox();

            foreach (var material in materialsToBind)
            {
                DataRow newRow = table.NewRow();

                if (columns.Contains("Nazwa"))
                    newRow["Nazwa"] = material.Name;
                if (columns.Contains("Numer"))
                    newRow["Numer"] = material.Number;

                if (_view.CcheckBox)
                {
                    FillElementColumns(newRow, "C min", "C max", "C real", Category.OfElement.C, material);
                }
                if (_view.SiCheckBox)
                {
                    FillElementColumns(newRow, "Si min", "Si max", "Si real", Category.OfElement.Si, material);
                }
                if (_view.MnCheckBox)
                {
                    FillElementColumns(newRow, "Mn min", "Mn max", "Mn real", Category.OfElement.Mn, material);
                }
                if (_view.PcheckBox)
                {
                    FillElementColumns(newRow, "P min", "P max", "P real", Category.OfElement.P, material);
                }
                if (_view.ScheckBox)
                {
                    FillElementColumns(newRow, "S min", "S max", "S real", Category.OfElement.S, material);
                }
                if (_view.NcheckBox)
                {
                    FillElementColumns(newRow, "N min", "N max", "N real", Category.OfElement.N, material);
                }
                if (_view.CrCheckBox)
                {
                    FillElementColumns(newRow, "Cr min", "Cr max", "Cr real", Category.OfElement.Cr, material);
                }
                if (_view.MoCheckBox)
                {
                    FillElementColumns(newRow, "Mo min", "Mo max", "Mo real", Category.OfElement.Mo, material);
                }
                if (_view.NbCheckBox)
                {
                    FillElementColumns(newRow, "Nb min", "Nb max", "Nb real", Category.OfElement.Nb, material);
                }
                if (_view.NiCheckBox)
                {
                    FillElementColumns(newRow, "Ni min", "Ni max", "Ni real", Category.OfElement.Ni, material);
                }
                if (_view.TiCheckBox)
                {
                    FillElementColumns(newRow, "Ti min", "Ti max", "Ti real", Category.OfElement.Ti, material);
                }
                if (_view.AlCheckBox)
                {
                    FillElementColumns(newRow, "Al min", "Al max", "Al real", Category.OfElement.Al, material);
                }
                if (_view.VCheckBox)
                {
                    FillElementColumns(newRow, "V min", "V max", "V real", Category.OfElement.V, material);
                }
                if (_view.CuCheckBox)
                {
                    FillElementColumns(newRow, "Cu min", "Cu max", "Cu real", Category.OfElement.Cu, material);
                }
                table.Rows.Add(newRow);
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
            _view.DataGridView.DataSource = null;
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
        }

        public void OnViewOptionsCheckBoxChanged()
        {
            _view.GridSource = null;
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidth();
        }

        public void OnElementsOrderPropertiesButtonClicked()
        {
            var orderPropertiesForm = new MaterialDatabasePropertiesForm();
            orderPropertiesForm.ShowDialog();
        }
    }
}
