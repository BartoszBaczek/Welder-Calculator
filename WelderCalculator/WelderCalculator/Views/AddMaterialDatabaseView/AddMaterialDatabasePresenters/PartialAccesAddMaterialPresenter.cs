using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Views.General.MaterialDatabasePropertiesView;

namespace WelderCalculator.Views.AddMaterialDatabaseView.AddMaterialDatabasePresenters
{
    public class PartialAccesAddMaterialPresenter : AddMaterialDatabasePresenter
    {
        public PartialAccesAddMaterialPresenter(IAdditiveMaterialView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public override void Init()
        {
            LoadNormComboBoxes();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
            SetPartialAccesibilityControls();
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
            MessageBox.Show("Niedostepne");
        }

        public override void OnEditMaterialButtonClicked()
        {
            MessageBox.Show("Niedostepne");
        }

        public override void OnDeleteMaterialButtonClicked()
        {
            MessageBox.Show("Niedostepne");
        }
        
        public override void OnAddNormButtonClicked()
        {
            MessageBox.Show("Niedostepne");
        }

        public override void OnDeleteNormButtonClicked()
        {
            MessageBox.Show("Niedostepne");
        }

        public override void OnSelectedIndexChanged()
        {
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        public override void OnSelectedDataGridViewRowChanged()
        {
            UpdateEquivalents();
        }

        public override void OnChooseMaterialButtonClicked()
        {
            AdditiveMaterial selectedMaterial = GetSelectedMaterial();
            _dataConnector.SaveAdditionalMaterialForSchaeffler(selectedMaterial);
        }
    }
}
