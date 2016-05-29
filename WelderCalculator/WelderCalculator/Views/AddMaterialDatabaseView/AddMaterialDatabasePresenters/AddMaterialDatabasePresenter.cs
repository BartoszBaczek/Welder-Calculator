using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.Views.AddMaterialDatabaseView.AddMaterialDatabasePresenters
{
    public abstract class AddMaterialDatabasePresenter
    {
        protected IAdditiveMaterialView _view;
        protected DataConnector _dataConnector;

        public abstract void Init();
        public abstract void OnMaterialCheckBoxChanged(string elementName);
        public abstract void OnViewOptionsCheckBoxChanged(string option);
        public abstract void OnElementsOrderPropertiesButtonClicked();
        public abstract void Refresh();
        public abstract void OnAddMaterialButtonClicked();
        public abstract void OnEditMaterialButtonClicked();
        public abstract void OnDeleteMaterialButtonClicked();
        public abstract void OnSelectedIndexChanged();
        public abstract void OnSelectedDataGridViewRowChanged();
        public abstract void OnAddNormButtonClicked();
        public abstract void OnDeleteNormButtonClicked();
        public abstract void OnChooseMaterialButtonClicked();

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

        protected void LoadNormComboBoxes()
        {
            _view.NormsList = _dataConnector.GetNamesOfAdditiveNorms();
        }

        protected void LoadEquivalantsComboBox()
        {
            _view.EquivalentsList = new List<string>()
            {
                "Schaeffler",
                "DeLong",
                "WRC1992"
            };
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
            _view.CuCheckBox = true;
            _view.VCheckBox = true;

            _view.MinCheckBox = true;
            _view.MaxCheckBox = true;
            _view.RealCheckBox = true;
        }

        protected void BindDataSourceToDataGridView()
        {
            DataTable table = CreateTable();
            _view.GridSource = table;
        }

        protected DataTable CreateTable()
        {
            var table = new DataTable();
            CreateColumns(table);
            CreateRows(table);
            return table;
        }

        protected IEnumerable<AdditiveMaterial> GetCurrentListOfMaterialsFromNormComboBox()
        {
            List<string> listOfNormsNames = _dataConnector.GetNamesOfAdditiveNorms();

            if (_view.SelectedNorm != -1)
            {
                string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
                List<AdditiveMaterial> listofMaterialsFromNorm = _dataConnector.GetAdditiveMaterials(desiredNameOfNorm);
                return listofMaterialsFromNorm;
            }
            return new List<AdditiveMaterial>();
        }

        protected void CreateColumns(DataTable table)
        {
            var orderOfElements = _dataConnector.GetOrderOfElementsForAdditiveMaterial();
            table.Columns.Add("GUID", typeof(Guid));

            table.Columns.Add("Nazwa", typeof(string));

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
                    (type == Category.OfElement.Cu) ||
                    (type == Category.OfElement.V))
                {
                    table.Columns.Add(Enum.GetName(typeof(Category.OfElement), type) + " min", typeof(double));
                    table.Columns.Add(Enum.GetName(typeof(Category.OfElement), type) + " max", typeof(double));
                    table.Columns.Add(Enum.GetName(typeof(Category.OfElement), type) + " real", typeof(double));
                }
            }
        }

        protected void CreateRows(DataTable table)
        {
            var materialsToBind = GetCurrentListOfMaterialsFromNormComboBox();

            foreach (var material in materialsToBind)
            {
                DataRow newRow = table.NewRow();

                newRow["GUID"] = material.GuidNumber;
                newRow["Nazwa"] = material.Name;
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
                FillElementColumns(newRow, "Cu min", "Cu max", "Cu real", Category.OfElement.Cu, material);
                FillElementColumns(newRow, "V min", "V max", "V real", Category.OfElement.V, material);
                table.Rows.Add(newRow);
            }
        }

        protected void FillElementColumns(DataRow row, string min, string max, string real, Category.OfElement element,
            AdditiveMaterial material)
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
                _view.NiEquivalentTextBox = material.NiEqSchaeffler;
                _view.CrEquivalentTextBox = material.CrEqSchaefflerAndDeLong;
            }
        }

        protected AdditiveMaterial GetSelectedMaterial()
        {
            var materialRow = _view.SelectedRow;

            if (materialRow.Cells.Count <= 0)
                return null;

            var materialGuid = Guid.Parse(materialRow.Cells[0].Value.ToString());
            var currentNormName = _view.NormsList[_view.SelectedNorm];
            var selectedMaterial = _dataConnector.GetAdditiveMaterial(materialGuid, currentNormName);

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

        protected void SetElementVisibilityForAllColumns()
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
            SetColumnsVisibiliyForElements("Cu", _view.CuCheckBox);
            SetColumnsVisibiliyForElements("V", _view.VCheckBox);
        }

        protected AdditiveNorm GetCurrentNorm()
        {
            string currentNormName = _view.NormsList[_view.SelectedNorm];
            AdditiveNorm norm = _dataConnector.GetAdditiveNorm(currentNormName);
            return norm;
        }
    }
}
