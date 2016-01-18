using System.Windows.Forms;
using WelderCalculator.Databases.BaseMaterialsView;
using WelderCalculator.MaterialDatabasePropertiesView;
using WelderCalculator.MaterialModificationView;
using WelderCalculator.MaterialModificationView.Serialization;
using WelderCalculator.Views.MaterialDatabaseView.MaterialDatabasePresenters;

namespace WelderCalculator.MaterialDatabaseView
{
    public class MaterialDatabaseFullAccesPresenter : MaterialDatabasePresenter
    {
        public MaterialDatabaseFullAccesPresenter(IMaterialDatabaseView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public override void Init()
        {
            LoadNormsComboBox();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
            SetFullAccesibilityControls();
        }

        public override void OnSelectedIndexChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        public override void OnMaterialCheckBoxChanged(string elementName)
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

        public override void OnViewOptionsCheckBoxChanged(string option)
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

        public override void OnElementsOrderPropertiesButtonClicked()
        {
            var orderPropertiesForm = new MaterialDatabasePropertiesForm(MaterialType.BaseMaterial);
            orderPropertiesForm.ShowDialog();
        }

        public override void OnSelectedDataGridViewRowChanged()
        {
            UpdateEquivalents();
        }

        public override void OnAddMaterialButtonClicked()
        {
            var currentNorm = GetCurrentNorm();
            var modifyMaterialForm = new MaterialModificationForm(currentNorm, MaterialType.BaseMaterial);
            modifyMaterialForm.ShowDialog();
            Init();
        }

        public override void OnEditMaterialButtonClicked()
        {
            var currentNorm = GetCurrentNorm();
            var material = GetSelectedMaterial();
            if (material == null)
                return;

            var modifyMaterialForm = new MaterialModificationForm(currentNorm, material, MaterialType.BaseMaterial);
            modifyMaterialForm.ShowDialog();
            Init();
        }

        public override void OnDeleteMaterialButtonClicked()
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

        public override void OnAddNormButtonClicked()
        {
            var addNormView = new NormAdderView(MaterialType.BaseMaterial);
            addNormView.ShowDialog();
            Init();
        }

        public override void OnDeleteNormButtonClicked()
        {
            string selectedNormName = _view.NormsList[_view.SelectedNorm];

            var dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć normę " + selectedNormName + "?", "Usuń normę",
                            MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                _dataConnector.RemoveBaseNorm(selectedNormName);
                Init();
            }
        }

        public override void Refresh()
        {
            LoadNormsComboBox();
            _view.GridSource = null;
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        public override void OnChooseMaterialButtonClicked()
        {
            MessageBox.Show("Niedostepne");
        }
    }
}
