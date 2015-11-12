using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WelderCalculator.MaterialDatabasePropertiesView;
using WelderCalculator.Model;
using WelderCalculator.Serialization;

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
            #region MyRegion
            //var table = new DataTable();

            //CreateColumns(table);
            //CreateRows(table);

            //return table; 
            #endregion
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
            #region OldCode
            var listOfElements = _dataConnector.GetLastSavedOrderOfElements();

            table.Columns.Add("Nazwa", typeof(string));

            if (_view.NumberCheckBox)
                table.Columns.Add("Numer", typeof(string));

            int i = 0;
            foreach (var element in listOfElements)
            {
                if ((element == Category.OfElement.C && _view.CcheckBox) || (element == Category.OfElement.Si && _view.SiCheckBox) ||
                    (element == Category.OfElement.Mn && _view.MnCheckBox) || (element == Category.OfElement.P && _view.PcheckBox) ||
                    (element == Category.OfElement.S && _view.ScheckBox) || (element == Category.OfElement.N && _view.NcheckBox) ||
                    (element == Category.OfElement.Cr && _view.CrCheckBox) || (element == Category.OfElement.Mo && _view.MoCheckBox) ||
                    (element == Category.OfElement.Nb && _view.NbCheckBox) || (element == Category.OfElement.Ni && _view.NiCheckBox) ||
                    (element == Category.OfElement.Ti && _view.TiCheckBox == true) || (element == Category.OfElement.Al && _view.AlCheckBox) ||
                    (element == Category.OfElement.V && _view.VCheckBox) || (element == Category.OfElement.Cu && _view.CuCheckBox))
                {
                    if (_view.MinCheckBox)
                        table.Columns.Add(Enum.GetName(typeof(Category.OfElement), i) + " min", typeof(double));
                    if (_view.MaxCheckBox)
                        table.Columns.Add(Enum.GetName(typeof(Category.OfElement), i) + " max", typeof(double));
                    if (_view.RealCheckBox)
                        table.Columns.Add(Enum.GetName(typeof(Category.OfElement), i) + " real", typeof(double));
                }
                i++;
            }

            foreach (DataColumn column in table.Columns)
                column.AllowDBNull = true; 
            #endregion
        }

        private void CreateRows(DataTable table)
        {
            #region OldCode
            DataColumnCollection columns = table.Columns;
            IEnumerable<Material> materials = GetCurrentListOfMaterialsFromNormComboBox();
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
                if (_view.VCheckBox)
                {
                    FillElementColumns(r, "V min", "V max", "V real", Category.OfElement.V, material);
                }
                if (_view.CuCheckBox)
                {
                    FillElementColumns(r, "Cu min", "Cu max", "Cu real", Category.OfElement.Cu, material);
                }

                table.Rows.Add(r);
            } 
            #endregion
        }

        private void FillElementColumns(DataRow row, string min, string max, string real, Category.OfElement element, Material material)
        {
            #region oldCode
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
            #endregion
            
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
