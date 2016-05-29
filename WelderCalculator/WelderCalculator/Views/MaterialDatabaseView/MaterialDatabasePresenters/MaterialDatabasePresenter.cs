using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.Views.MaterialDatabaseView.MaterialDatabasePresenters
{
    public abstract class MaterialDatabasePresenter
    {
        protected IMaterialDatabaseView _view;
        protected DataConnector _dataConnector;

        public abstract void Init();
        public abstract void OnSelectedIndexChanged();
        public abstract void OnMaterialCheckBoxChanged(string elementName);
        public abstract void OnViewOptionsCheckBoxChanged(string option);
        public abstract void OnElementsOrderPropertiesButtonClicked();
        public abstract void Refresh();
        public abstract void OnSelectedDataGridViewRowChanged();
        public abstract void OnAddMaterialButtonClicked();
        public abstract void OnEditMaterialButtonClicked();
        public abstract void OnDeleteMaterialButtonClicked();
        public abstract void OnAddNormButtonClicked();
        public abstract void OnDeleteNormButtonClicked();
        public abstract void OnChooseMaterialButtonClicked();
        
        protected void LoadNormsComboBox()  
        {
            _view.NormsList = _dataConnector.GetNamesOfBaseNorms();
        }

        protected void MakeAllCheckBoxesChecked()
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
    
        protected void BindDataSourceToDataGridView()
        {
            DataTable table = CreateTable();
            _view.GridSource = table;
        }

        protected void SetDataGridViewColumnsWidthAndSetInitialVisibility()
        {
            foreach (DataGridViewColumn column in _view.DataGridView.Columns)
            {
                column.Width = 80;
            }
            _view.DataGridView.Columns["GUID"].Visible = false;
        }

        protected void UpdateEquivalents()
        {
            var material = GetSelectedMaterial();
            if (material != null)
            {
                _view.CEquivalentTextBox = material.CEq;
                _view.NiEquivalentTextBox = material.NiEqSchaeffler;
                _view.CrEquivalentTextBox = material.CrEqSchaefflerAndDeLong;
            }
        }

        protected BaseMaterial GetSelectedMaterial()
        {
            var materialRow = _view.SelectedRow;

            if (materialRow.Cells.Count <= 0)
                return null;

            var materialGuid = Guid.Parse(materialRow.Cells[0].Value.ToString());
            var currentNormName = _view.NormsList[_view.SelectedNorm];
            var selectedMaterial = _dataConnector.GetBaseMaterial(materialGuid, currentNormName);

            return selectedMaterial;
        }

        protected void SetColumnsVisibiliyForElements(string elementName, bool visibility)
        {
            if (_view.MinCheckBox)
                _view.DataGridView.Columns[elementName + " min"].Visible = visibility;
            if (_view.MaxCheckBox)
                _view.DataGridView.Columns[elementName + " max"].Visible = visibility;
            if (_view.RealCheckBox)
                _view.DataGridView.Columns[elementName + " real"].Visible = visibility;

        }

        protected void SetColumnsVisibilityForMinMaxRealNumber(string option, bool visibility)
        {
            foreach (DataGridViewColumn column in _view.DataGridView.Columns)
            {
                if (column.Name.Contains(option))
                {
                    column.Visible = visibility;
                    SetElementVisibilityForAllColumns();
                }
            }
        }

        protected BaseNorm GetCurrentNorm()
        {
            string currentNormName = _view.NormsList[_view.SelectedNorm];
            BaseNorm norm = _dataConnector.GetBaseNorm(currentNormName);

            return norm;
        }

        protected void SetFullAccesibilityControls()
        {
            _view.ChooseMaterialVisibityButton = false;
        }

        protected void SetPartialAccesibilityControls()
        {
            _view.ModifyMaterialVisibilityLayoutPanel = false;
            _view.AddNormVisibilityButton = false;
            _view.DeleteNormVisibilityButton = false;
        }


        private DataTable CreateTable()
        {
            var table = new DataTable();
            CreateColumns(table);
            CreateRows(table);
            return table;
        }

        private void CreateColumns(DataTable table)
        {
            var orderOfElements = _dataConnector.GetOrderOfElementsForBaseMaterial();
            table.Columns.Add("GUID", typeof(Guid));

            table.Columns.Add("Nazwa", typeof(string));
            table.Columns.Add("Numer", typeof(string));

            foreach (Category.OfElement type in orderOfElements)
            {
                if ((type == Category.OfElement.C) ||
                    (type == Category.OfElement.Si) ||
                    (type == Category.OfElement.Mn) ||
                    (type == Category.OfElement.P) ||
                    (type == Category.OfElement.S) ||
                    (type == Category.OfElement.N) ||
                    (type == Category.OfElement.Cr) ||
                    (type == Category.OfElement.Mo) ||
                    (type == Category.OfElement.Nb) ||
                    (type == Category.OfElement.Ni) ||
                    (type == Category.OfElement.Ti) ||
                    (type == Category.OfElement.Al) ||
                    (type == Category.OfElement.V) ||
                    (type == Category.OfElement.Cu))
                {
                    table.Columns.Add(Enum.GetName(typeof(Category.OfElement), type) + " min", typeof(double));
                    table.Columns.Add(Enum.GetName(typeof(Category.OfElement), type) + " max", typeof(double));
                    table.Columns.Add(Enum.GetName(typeof(Category.OfElement), type) + " real", typeof(double));
                }
            }
        }

        private void CreateRows(DataTable table)
        {
            var materialsToBind = GetCurrentListOfMaterialsFromNormComboBox();

            foreach (var material in materialsToBind)
            {
                DataRow newRow = table.NewRow();

                newRow["GUID"] = material.GuidNumber;
                newRow["Nazwa"] = material.Name;
                newRow["Numer"] = material.Number;
                FillElementColumns(newRow, "C min", "C max", "C real", Category.OfElement.C, material);
                FillElementColumns(newRow, "Si min", "Si max", "Si real", Category.OfElement.Si, material);
                FillElementColumns(newRow, "Mn min", "Mn max", "Mn real", Category.OfElement.Mn, material);
                FillElementColumns(newRow, "P min", "P max", "P real", Category.OfElement.P, material);
                FillElementColumns(newRow, "S min", "S max", "S real", Category.OfElement.S, material);
                FillElementColumns(newRow, "N min", "N max", "N real", Category.OfElement.N, material);
                FillElementColumns(newRow, "Cr min", "Cr max", "Cr real", Category.OfElement.Cr, material);
                FillElementColumns(newRow, "Mo min", "Mo max", "Mo real", Category.OfElement.Mo, material);
                FillElementColumns(newRow, "Nb min", "Nb max", "Nb real", Category.OfElement.Nb, material);
                FillElementColumns(newRow, "Ni min", "Ni max", "Ni real", Category.OfElement.Ni, material);
                FillElementColumns(newRow, "Ti min", "Ti max", "Ti real", Category.OfElement.Ti, material);
                FillElementColumns(newRow, "Al min", "Al max", "Al real", Category.OfElement.Al, material);
                FillElementColumns(newRow, "V min", "V max", "V real", Category.OfElement.V, material);
                FillElementColumns(newRow, "Cu min", "Cu max", "Cu real", Category.OfElement.Cu, material);
                FillElementColumns(newRow, "V min", "V max", "V real", Category.OfElement.V, material);
                FillElementColumns(newRow, "Cu min", "Cu max", "Cu real", Category.OfElement.Cu, material);
                table.Rows.Add(newRow);
            }
        }

        private IEnumerable<BaseMaterial> GetCurrentListOfMaterialsFromNormComboBox()
        {
            List<string> listOfNormsNames = _dataConnector.GetNamesOfBaseNorms();
            if (_view.SelectedNorm != -1)
            {
                string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
                List<BaseMaterial> listofMaterialsFromNorm = _dataConnector.GetBaseMaterials(desiredNameOfNorm);
                return listofMaterialsFromNorm;
            }
            return new List<BaseMaterial>();
        }

        private void FillElementColumns(DataRow row, string min, string max, string real, Category.OfElement element, BaseMaterial material)
        {
            var materialElement = material.GetElement(element);

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

        private void SetElementVisibilityForAllColumns()
        {
            SetColumnsVisibiliyForElements("C", _view.CcheckBox);
            SetColumnsVisibiliyForElements("Si", _view.SiCheckBox);
            SetColumnsVisibiliyForElements("Mn", _view.MnCheckBox);
            SetColumnsVisibiliyForElements("P", _view.PcheckBox);
            SetColumnsVisibiliyForElements("S", _view.ScheckBox);
            SetColumnsVisibiliyForElements("N", _view.NcheckBox);
            SetColumnsVisibiliyForElements("Cr", _view.CrCheckBox);
            SetColumnsVisibiliyForElements("Mo", _view.MoCheckBox);
            SetColumnsVisibiliyForElements("Nb", _view.NbCheckBox);
            SetColumnsVisibiliyForElements("Ni", _view.NiCheckBox);
            SetColumnsVisibiliyForElements("Ti", _view.TiCheckBox);
            SetColumnsVisibiliyForElements("Al", _view.AlCheckBox);
            SetColumnsVisibiliyForElements("V", _view.VCheckBox);
            SetColumnsVisibiliyForElements("Cu", _view.CuCheckBox);
        }
    }
}
