using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Xml.Serialization;
using WelderCalculator.MaterialDatabasePropertiesView;
using WelderCalculator.MaterialModificationView;
using WelderCalculator.MaterialModificationView.Serialization;
using WelderCalculator.Model;

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
            _view.NormsList = _dataConnector.GetNamesOfAllNorms();
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
            List<string> listOfNormsNames = _dataConnector.GetNamesOfAllNorms();
            string desiredNameOfNorm = listOfNormsNames[_view.SelectedNorm];
            List<Material> listofMaterialsFromNorm = _dataConnector.GetMaterialsFromNorm(desiredNameOfNorm);

            return listofMaterialsFromNorm;
        }
        
        private void CreateColumns(DataTable table)
        {
            var orderOfElements = _dataConnector.GetOrderOfElements();
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

        private void FillElementColumns(DataRow row, string min, string max, string real, Category.OfElement element, Material material)
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
            #region oldCode

            //Element materialElement = material.GetElement(element);

            //if (_view.MinCheckBox)
            //{
            //    if (material.GetElement(element).Min == null)
            //        row[min] = DBNull.Value;
            //    else
            //        row[min] = materialElement.Min;
            //}

            //if (_view.MaxCheckBox)
            //{
            //    if (material.GetElement(element).Max == null)
            //        row[max] = DBNull.Value;
            //    else
            //        row[max] = materialElement.Max;
            //}

            //if (_view.RealCheckBox)
            //{
            //    if (material.GetElement(element).RealValue == null)
            //        row[real] = DBNull.Value;
            //    else
            //        row[real] = materialElement.RealValue;
            //}  

            #endregion
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

        private Material GetSelectedMaterial()
        {
            var materialRow = _view.SelectedRow;

            if (materialRow.Cells.Count <= 0) 
                return null;

            var materialGuid = Guid.Parse(materialRow.Cells[0].Value.ToString());
            var currentNormName = _view.NormsList[_view.SelectedNorm];
            var selectedMaterial = _dataConnector.GetMaterial(materialGuid, currentNormName);

            return selectedMaterial;
        }

        public void OnSelectedIndexChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        public void OnMaterialCheckBoxChanged(string materialName)
        {
            if (materialName == "C")
                    SetColumnsVisibiliyForElements(materialName, _view.CcheckBox);
            
            if (materialName == "Si")
                    SetColumnsVisibiliyForElements(materialName, _view.SiCheckBox);
            
            if (materialName == "Mn")
                    SetColumnsVisibiliyForElements(materialName, _view.MnCheckBox);
            
            if (materialName == "P")
                    SetColumnsVisibiliyForElements(materialName, _view.PcheckBox);
            
            if (materialName == "S")
                    SetColumnsVisibiliyForElements(materialName, _view.ScheckBox);
            
            if (materialName == "N")
                    SetColumnsVisibiliyForElements(materialName, _view.NcheckBox);
            
            if (materialName == "Cr")
                    SetColumnsVisibiliyForElements(materialName, _view.CrCheckBox);
            
            if (materialName == "Mo")
                    SetColumnsVisibiliyForElements(materialName, _view.MoCheckBox);
            
            if (materialName == "Nb")
                    SetColumnsVisibiliyForElements(materialName, _view.NbCheckBox);
            
            if (materialName == "Ni")
                    SetColumnsVisibiliyForElements(materialName, _view.NiCheckBox);
            
            if (materialName == "Ti")
                    SetColumnsVisibiliyForElements(materialName, _view.TiCheckBox);
            
            if (materialName == "Al")
                    SetColumnsVisibiliyForElements(materialName, _view.AlCheckBox);

            if (materialName == "V")
                    SetColumnsVisibiliyForElements(materialName, _view.VCheckBox);
            
            if (materialName == "Cu")
                    SetColumnsVisibiliyForElements(materialName, _view.CuCheckBox);
       }

        private void SetColumnsVisibiliyForElements(string materialName, bool visibility)
        {
            if (_view.MinCheckBox)
                _view.DataGridView.Columns[materialName + " min"].Visible = visibility;
            if (_view.MaxCheckBox)
                _view.DataGridView.Columns[materialName + " max"].Visible = visibility;
            if (_view.RealCheckBox)
                _view.DataGridView.Columns[materialName + " real"].Visible = visibility;
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
                    column.Visible = visibility;
            }
        }
        
        public void OnElementsOrderPropertiesButtonClicked()
        {
            var orderPropertiesForm = new MaterialDatabasePropertiesForm();
            orderPropertiesForm.ShowDialog();
        }

        public void OnSelectedDataGridViewRowChanged()
        {
            UpdateEquivalents();
        }

        public void OnAddMaterialButtonClicked()
        {
            var currentNorm = GetCurrentNorm();
            var modifyMaterialForm = new MaterialModificationForm(currentNorm);
            modifyMaterialForm.ShowDialog();
            Init();
        }

        public void OnEditMaterialButtonClicked()
        {
            var currentNorm = GetCurrentNorm();
            var material = GetSelectedMaterial();

            var modifyMaterialForm = new MaterialModificationForm(currentNorm, material);
            modifyMaterialForm.ShowDialog();
            Init();
        }

        private MaterialNorm GetCurrentNorm()
        {
            string currentNormName = _view.NormsList[_view.SelectedNorm];
            MaterialNorm norm = _dataConnector.GetNorm(currentNormName);

            return norm;
        }
    }
}
