using System.Windows.Forms;
using WelderCalculator.Repositories;
using WelderCalculator.Views.General.MaterialDatabasePropertiesView;
using WelderCalculator.Views.General.MaterialModificationView;
using WelderCalculator.Views.General.NormAdderView;

namespace WelderCalculator.Views.AddMaterialDatabaseView.AddMaterialDatabasePresenters
{
    public class FullAccesAddMaterialDatabasePresenter : AddMaterialDatabasePresenter
    {
        public FullAccesAddMaterialDatabasePresenter(IAdditiveMaterialView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public override void Init()
        {
            LoadNormComboBoxes();
            LoadEquivalantsComboBox();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
            SetFullAccesibilityControls();
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

            if (elementName == "Cu")
                SetColumnsVisibiliyForElements(elementName, _view.CuCheckBox);

            if (elementName == "V")
                SetColumnsVisibiliyForElements(elementName, _view.VCheckBox);
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
            }
        }

        public override void OnElementsOrderPropertiesButtonClicked()
        {
            var orderPropertiesForm = new MaterialDatabasePropertiesForm(MaterialType.AdditionalMaterial);
            orderPropertiesForm.ShowDialog();
        }

        public override void Refresh()
        {
            LoadNormComboBoxes();
            _view.GridSource = null;
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        public override void OnAddMaterialButtonClicked()
        {
            if (_view.SelectedNorm != -1)
            {
                var currentNorm = GetCurrentNorm();
                var modifyMaterialForm = new MaterialModificationForm(currentNorm, MaterialType.AdditionalMaterial);
                modifyMaterialForm.ShowDialog();
                Init();
            }
            
        }

        public override void OnEditMaterialButtonClicked()
        {
            if (_view.SelectedNorm != -1)
            {
                var currentNorm = GetCurrentNorm();
                var material = GetSelectedMaterial();
                if (material == null)
                    return;

                var modifyMaterialForm = new MaterialModificationForm(currentNorm, material, MaterialType.AdditionalMaterial);
                modifyMaterialForm.ShowDialog();
                Init();
            }
        }

        public override void OnDeleteMaterialButtonClicked()
        {
            if (_view.SelectedNorm != -1)
            {
                var currentNorm = GetCurrentNorm();
                var selectedMaterial = GetSelectedMaterial();

                if (selectedMaterial == null)
                    return;

                var dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrany materiał?", "Usuń materiał",
                    MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var normToChange = _dataConnector.GetAdditiveNorm(currentNorm.Name);
                    normToChange.Materials.RemoveAll(m => m.GuidNumber == selectedMaterial.GuidNumber);
                    _dataConnector.RemoveAdditiveNorm(normToChange.Name);
                    _dataConnector.SaveAdditiveNorm(normToChange);
                    Init();
                }
            }
        }
        
        public override void OnAddNormButtonClicked()
        {
            var addNormView = new NormAdderView(MaterialType.AdditionalMaterial);
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
                _dataConnector.RemoveAdditiveNorm(selectedNormName);
                Init();
            }
        }

        public override void OnNormSelectedIndexChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        public override void OnSelectedDataGridViewRowChanged()
        {
            UpdateEquivalents();
        }

        public override void OnEquivalentSelectedIndexChanged()
        {
            UpdateEquivalents();
        }

        public override void OnChooseMaterialButtonClicked()
        {
            MessageBox.Show("Niedostepne");
        }
    }
}
