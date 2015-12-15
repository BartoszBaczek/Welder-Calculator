using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Databases.BaseMaterialsView;
using WelderCalculator.MaterialDatabasePropertiesView;
using WelderCalculator.MaterialModificationView;
using WelderCalculator.MaterialModificationView.Serialization;
using WelderCalculator.Model;
using WelderCalculator.Repositories.Model.temp;
using WelderCalculator.Repositories.Model.temp2;

namespace WelderCalculator.MaterialDatabaseView
{
    public class MaterialDatabasePresenter
    {
        private readonly IMaterialDatabaseView _view;
        private readonly DataConnector _dataConnector;

        public MaterialDatabasePresenter(IMaterialDatabaseView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public void Init()
        {
            LoadNormsComboBox();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        private void LoadNormsComboBox()  
        {
            _view.NormsList = _dataConnector.GetNamesOfBaseNorms();
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

        private IEnumerable<BaseMaterial> GetCurrentListOfMaterialsFromNormComboBox()
        {
            List<string> listOfNormsNames = _dataConnector.GetNamesOfBaseNorms();
            string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
            List<BaseMaterial> listofMaterialsFromNorm = _dataConnector.GetBaseMaterials(desiredNameOfNorm);

            return listofMaterialsFromNorm;
        }
        
        private void CreateColumns(DataTable table)
        {
            var orderOfElements = _dataConnector.GetOrderOfElementsForBaseMaterial();
            table.Columns.Add("GUID", typeof(Guid));

            table.Columns.Add("Nazwa", typeof (string));
            table.Columns.Add("Numer", typeof(string));

            foreach (Category.OfElement type in orderOfElements)
            {
                if ((type == Category.OfElement.C ) ||
                    (type == Category.OfElement.Si) ||
                    (type == Category.OfElement.Mn) ||
                    (type == Category.OfElement.P ) ||
                    (type == Category.OfElement.S ) ||
                    (type == Category.OfElement.N ) ||
                    (type == Category.OfElement.Cr) ||
                    (type == Category.OfElement.Mo) ||
                    (type == Category.OfElement.Nb) ||
                    (type == Category.OfElement.Ni) ||
                    (type == Category.OfElement.Ti) ||
                    (type == Category.OfElement.Al) ||
                    (type == Category.OfElement.V ) ||
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

        private void SetDataGridViewColumnsWidthAndSetInitialVisibility()
        {
            foreach ( DataGridViewColumn column in _view.DataGridView.Columns)
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

        private BaseMaterial GetSelectedMaterial()
        {
            var materialRow = _view.SelectedRow;

            if (materialRow.Cells.Count <= 0) 
                return null;

            var materialGuid = Guid.Parse(materialRow.Cells[0].Value.ToString());
            var currentNormName = _view.NormsList[_view.SelectedNorm];
            var selectedMaterial = _dataConnector.GetBaseMaterial(materialGuid, currentNormName);

            return selectedMaterial;
        }

        public void OnSelectedIndexChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
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
            
            if (elementName == "Al")
                    SetColumnsVisibiliyForElements(elementName, _view.AlCheckBox);

            if (elementName == "V")
                    SetColumnsVisibiliyForElements(elementName, _view.VCheckBox);
            
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

        public void OnViewOptionsCheckBoxChanged(string option)
        {
            switch (option)
            {
                case "min":
                    SetColumnsVisibilityForMinMaxRealNumber(option, _view.MinCheckBox);
                    break;
                case "max":
                    SetColumnsVisibilityForMinMaxRealNumber(option, _view.MaxCheckBox);
                    break;
                case "real":
                    SetColumnsVisibilityForMinMaxRealNumber(option, _view.RealCheckBox);
                    break;
                case "Numer":
                    SetColumnsVisibilityForMinMaxRealNumber(option, _view.NumberCheckBox);
                    break;
            }
        }

        private void SetColumnsVisibilityForMinMaxRealNumber(string option, bool visibility)
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
        
        public void OnElementsOrderPropertiesButtonClicked()
        {
            var orderPropertiesForm = new MaterialDatabasePropertiesForm(MaterialType.BaseMaterial);
            orderPropertiesForm.ShowDialog();
        }

        public void OnSelectedDataGridViewRowChanged()
        {
            UpdateEquivalents();
        }

        public void OnAddMaterialButtonClicked()
        {
            var currentNorm = GetCurrentNorm();
            var modifyMaterialForm = new MaterialModificationForm(currentNorm, MaterialType.BaseMaterial);
            modifyMaterialForm.ShowDialog();
            Init();
        }

        public void OnEditMaterialButtonClicked()
        {
            var currentNorm = GetCurrentNorm();
            var material = GetSelectedMaterial();
            if (material == null)
                return;

            var modifyMaterialForm = new MaterialModificationForm(currentNorm, material, MaterialType.BaseMaterial);
            modifyMaterialForm.ShowDialog();
            Init();
        }

        public void OnDeleteMaterialButtonClicked()
        {
            var currentNorm = GetCurrentNorm();
            var selectedMaterial = GetSelectedMaterial();

            if (selectedMaterial == null)
                return;

            var dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrany materiał?", "Usuń materiał",
                MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                var normToChange = _dataConnector.GetBaseNorm(currentNorm.Name);
                normToChange.Materials.RemoveAll(m => m.GuidNumber == selectedMaterial.GuidNumber);
                _dataConnector.RemoveBaseNorm(normToChange.Name);
                _dataConnector.SaveBaseNorm(normToChange);
                Init();
            }
        }

        private BaseNorm GetCurrentNorm()
        {
            string currentNormName = _view.NormsList[_view.SelectedNorm];
            BaseNorm norm = _dataConnector.GetBaseNorm(currentNormName);

            return norm;
        }

        public void OnAddNormButtonClicked()
        {
            var addNormView = new NormAdderView(MaterialType.BaseMaterial);
            addNormView.ShowDialog();
            Init();
        }

        public void OnDeleteNormButtonClicked()
        {
            string selectedNormName = _view.NormsList[_view.SelectedNorm];
            _dataConnector.RemoveBaseNorm(selectedNormName);
            Init();
        }

        public void Refresh()
        {
            LoadNormsComboBox();
            _view.GridSource = null;
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }
    }
}
