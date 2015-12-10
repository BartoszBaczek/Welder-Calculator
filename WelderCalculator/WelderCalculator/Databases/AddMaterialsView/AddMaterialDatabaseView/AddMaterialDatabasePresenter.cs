using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.MaterialModificationView.Serialization;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model;

namespace WelderCalculator.Databases.AddMaterialDatabaseView
{
    public class AddMaterialDatabasePresenter
    {
        private readonly IAdditiveMaterialView _view;
        private readonly DataConnector _dataConnector;

        public AddMaterialDatabasePresenter(IAdditiveMaterialView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public void Init()
        {
            LoadNormComboBoxes();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        private void LoadNormComboBoxes()
        {
            _view.NormsList = _dataConnector.GetNamesOfAdditiveNorms();
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
            _view.CuCheckBox = true;

            _view.MinCheckBox = true;
            _view.MaxCheckBox = true;
            _view.RealCheckBox = true;
            _view.NominalContainmentNameCheckBox = true;
            _view.AlloyTypeNameCheckBox = true;
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

        private IEnumerable<AdditiveMaterial> GetCurrentListOfMaterialsFromNormComboBox()
        {
            List<string> listOfNormsNames = _dataConnector.GetNamesOfAdditiveNorms();
            string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
            List<AdditiveMaterial> listofMaterialsFromNorm = _dataConnector.GetAdditiveMaterials(desiredNameOfNorm);

            return listofMaterialsFromNorm;
        }

        private void CreateColumns(DataTable table)
        {
            var orderOfElements = _dataConnector.GetOrderOfElementsForAdditiveMaterial();
            table.Columns.Add("GUID", typeof(Guid));

            table.Columns.Add("NominalCompositeName", typeof(string));
            table.Columns.Add("AlloyTypeName", typeof(string));

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
                newRow["NominalCompositeName"] = material.NominalCompositionName;
                newRow["AlloyTypeName"] = material.AlloyTypeName;
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
                table.Rows.Add(newRow);
            }
        }

        private void FillElementColumns(DataRow row, string min, string max, string real, Category.OfElement element,
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

        private void SetDataGridViewColumnsWidthAndSetInitialVisibility()
        {
            foreach (DataGridViewColumn column in _view.DataGridView.Columns)
            {
                column.Width = 80;
            }
            _view.DataGridView.Columns["GUID"].Visible = false;
        }

        private void UpdateEquivalents()
        {
            var material = GetSelectedMaterial();
            if (material != null)
            {
                _view.CEquivalentTextBox = material.CEq;
                _view.NiEquivalentTextBox = material.NiEq;
                _view.CrEquivalentTextBox = material.CrEq;
            }
        }

        private AdditiveMaterial GetSelectedMaterial()
        {
            var materialRow = _view.SelectedRow;

            if (materialRow.Cells.Count <= 0)
                return null;

            var materialGuid = Guid.Parse(materialRow.Cells[0].Value.ToString());
            var currentNormName = _view.NormsList[_view.SelectedNorm];
            var selectedMaterial = _dataConnector.GetAdditiveMaterial(materialGuid, currentNormName);

            return selectedMaterial;
        }

        public void OnMaterialCheckBoxChanged(string elementName)
        {
            if (elementName == "C")
                SetColumnsVisibiliyForElements(elementName, _view.CcheckBox);

            if (elementName == "Si")
                SetColumnsVisibiliyForElements(elementName, _view.SiCheckBox);

            if (elementName == "Mn")
                SetColumnsVisibiliyForElements(elementName, _view.MnCheckBox);

            if (elementName == "P")
                SetColumnsVisibiliyForElements(elementName, _view.PcheckBox);

            if (elementName == "S")
                SetColumnsVisibiliyForElements(elementName, _view.ScheckBox);

            if (elementName == "N")
                SetColumnsVisibiliyForElements(elementName, _view.NcheckBox);

            if (elementName == "Cr")
                SetColumnsVisibiliyForElements(elementName, _view.CrCheckBox);

            if (elementName == "Mo")
                SetColumnsVisibiliyForElements(elementName, _view.MoCheckBox);

            if (elementName == "Nb")
                SetColumnsVisibiliyForElements(elementName, _view.NbCheckBox);

            if (elementName == "Ni")
                SetColumnsVisibiliyForElements(elementName, _view.NiCheckBox);

            if (elementName == "Ti")
                SetColumnsVisibiliyForElements(elementName, _view.TiCheckBox);

            if (elementName == "Cu")
                SetColumnsVisibiliyForElements(elementName, _view.CuCheckBox);
        }

        private void SetColumnsVisibiliyForElements(string elementName, bool visibility)
        {
            if (_view.MinCheckBox)
                _view.DataGridView.Columns[elementName + " min"].Visible = visibility;
            if (_view.MaxCheckBox)
                _view.DataGridView.Columns[elementName + " max"].Visible = visibility;
            if (_view.RealCheckBox)
                _view.DataGridView.Columns[elementName + " real"].Visible = visibility;

        }
    }
}
