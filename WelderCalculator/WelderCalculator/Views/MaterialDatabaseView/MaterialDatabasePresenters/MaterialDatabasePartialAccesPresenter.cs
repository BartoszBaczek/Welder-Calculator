using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.Views.MaterialDatabaseView.MaterialDatabasePresenters
{
    class MaterialDatabasePartialAccesPresenter : MaterialDatabasePresenter
    {
        public MaterialDatabasePartialAccesPresenter(IMaterialDatabaseView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public override void Init()
        {
            LoadNormsComboBox();
            LoadEquivalantsComboBox();
            MakeAllCheckBoxesChecked();
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
            SetPartialAccesibilityControls();
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

        public override void Refresh()
        {
            LoadNormsComboBox();
            _view.GridSource = null;
            BindDataSourceToDataGridView();
            SetDataGridViewColumnsWidthAndSetInitialVisibility();
        }

        public override void OnSelectedDataGridViewRowChanged()
        {
            UpdateEquivalents();
        }



        //Unavalibles in Partial acces mode
        public override void OnElementsOrderPropertiesButtonClicked()
        {
            MessageBox.Show("Niedostepne");
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

        public override void OnChooseMaterialButtonClicked()
        {
            BaseMaterial selectedMaterial = GetSelectedMaterial();

            if (_view.Accesibility == BaseMaterialDatabaseAccesibility.PartialForFirstMaterial)
                _dataConnector.SaveFirstBasisMarerialForSchaeffler(selectedMaterial);
            else if (_view.Accesibility == BaseMaterialDatabaseAccesibility.PartialForSecondMaterial)
                _dataConnector.SaveSecondBasisMarerialForSchaeffler(selectedMaterial);

        }
    }
}
