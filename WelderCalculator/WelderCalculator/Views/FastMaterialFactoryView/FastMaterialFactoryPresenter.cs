using System;
using System.Collections.Generic;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.Views.FastMaterialFactoryView
{
    public class FastMaterialFactoryPresenter
    {
        private readonly IFastMaterialFactoryView _view;
        private readonly DataConnector _dataConnector;

        private BaseMaterial _currentBaseMaterial1State = new BaseMaterial();
        private BaseMaterial _currentBaseMaterial2State = new BaseMaterial();
        private AdditiveMaterial _currentAdditionalMaterial1State = new AdditiveMaterial();

        public FastMaterialFactoryPresenter(IFastMaterialFactoryView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new DataConnector();
            Init();
        }

        private void Init()
        {
            _currentBaseMaterial1State = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            _currentBaseMaterial2State = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            _currentAdditionalMaterial1State = _dataConnector.GetAdditionalMaterialForSchaeffler();

            FillElementsTextBoxesWithCurrentMaterialsState();
            LoadEquivalentsComboBox();
        }

        private void FillElementsTextBoxesWithCurrentMaterialsState()
        {
            // BaseMaterial1
            _view.NiBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Cr).RealValue;
            _view.CBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.C).RealValue;
            _view.MnBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Mo).RealValue;
            _view.NBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.N).RealValue;
            _view.SiBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Si).RealValue;
            _view.NbBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Nb).RealValue;
            _view.TiBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Ti).RealValue;

            // BaseMaterial2
            _view.NiBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Cr).RealValue;
            _view.CBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.C).RealValue;
            _view.MnBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Mo).RealValue;
            _view.NBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.N).RealValue;
            _view.SiBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Si).RealValue;
            _view.NbBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Nb).RealValue;
            _view.TiBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Ti).RealValue;

            // AddMaterial
            _view.NiAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Cr).RealValue;
            _view.CAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.C).RealValue;
            _view.MnAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Mo).RealValue;
            _view.NAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.N).RealValue;
            _view.SiAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Si).RealValue;
            _view.NbAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Nb).RealValue;
            _view.TiAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Ti).RealValue;
        }

        private void FillEquivalentsWithCurrentMaterialsState()
        {
            if (_view.EquivalentsList[_view.SelectedEquivalent] == "Schaeffler")
            {
                _view.CrEqBaseMaterial1TextBox = _currentBaseMaterial1State.CrEqSchaefflerAndDeLong;
                _view.CrEqBaseMaterial2TextBox = _currentBaseMaterial2State.CrEqSchaefflerAndDeLong;
                _view.CrEqAddMaterialTextBox = _currentAdditionalMaterial1State.CrEqSchaefflerAndDeLong;

                _view.NiEqBaseMaterial1TextBox = _currentBaseMaterial1State.NiEqSchaeffler;
                _view.NiEqBaseMaterial2TextBox = _currentBaseMaterial2State.NiEqSchaeffler;
                _view.NiEqAddMaterialTextBox = _currentAdditionalMaterial1State.NiEqSchaeffler;
            }
            else if (_view.EquivalentsList[_view.SelectedEquivalent] == "DeLong")
            {
                _view.CrEqBaseMaterial1TextBox = _currentBaseMaterial1State.CrEqSchaefflerAndDeLong;
                _view.CrEqBaseMaterial2TextBox = _currentBaseMaterial2State.CrEqSchaefflerAndDeLong;
                _view.CrEqAddMaterialTextBox = _currentAdditionalMaterial1State.CrEqSchaefflerAndDeLong;

                _view.NiEqBaseMaterial1TextBox = _currentBaseMaterial1State.NiEqDeLong;
                _view.NiEqBaseMaterial2TextBox = _currentBaseMaterial2State.NiEqDeLong;
                _view.NiEqAddMaterialTextBox = _currentAdditionalMaterial1State.NiEqDeLong;
            }
            else if (_view.EquivalentsList[_view.SelectedEquivalent] == "WRC1992")
            {
                _view.CrEqBaseMaterial1TextBox = _currentBaseMaterial1State.CrEqWRC1992;
                _view.CrEqBaseMaterial2TextBox = _currentBaseMaterial2State.CrEqWRC1992;
                _view.CrEqAddMaterialTextBox = _currentAdditionalMaterial1State.CrEqWRC1992;

                _view.NiEqBaseMaterial1TextBox = _currentBaseMaterial1State.NiEqWRC1992;
                _view.NiEqBaseMaterial2TextBox = _currentBaseMaterial2State.NiEqWRC1992;
                _view.NiEqAddMaterialTextBox = _currentAdditionalMaterial1State.NiEqWRC1992;
            }
        }

        public void OnApplyButtonClicked()
        {
            if (_view.ChangeBaseMaterial1Checked)
            {
                var firstBaseMaterial = new BaseMaterial();
                firstBaseMaterial.Name = "Mat. bazowy 1";
                firstBaseMaterial.GuidNumber = new Guid();
                firstBaseMaterial.CreateBasicListOfElements();
                firstBaseMaterial.GetElement(Category.OfElement.C).RealValue = _view.CBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.Si).RealValue = _view.SiBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.Mn).RealValue = _view.MnBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.N).RealValue = _view.NBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.Cr).RealValue = _view.CrBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.Mo).RealValue = _view.MoBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.Nb).RealValue = _view.NbBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.Ni).RealValue = _view.NiBaseMaterial1;
                firstBaseMaterial.GetElement(Category.OfElement.Ti).RealValue = _view.TiBaseMaterial1;
                _dataConnector.SaveFirstBasisMarerialForSchaeffler(firstBaseMaterial);
            }

            if (_view.ChangeBaseMaterial2Checked)
            {
                var secondBaseMaterial = new BaseMaterial();
                secondBaseMaterial.Name = "Mat. bazowy 2";
                secondBaseMaterial.GuidNumber = new Guid();
                secondBaseMaterial.CreateBasicListOfElements();
                secondBaseMaterial.GetElement(Category.OfElement.C).RealValue = _view.CBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.Si).RealValue = _view.SiBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.Mn).RealValue = _view.MnBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.N).RealValue = _view.NBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.Cr).RealValue = _view.CrBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.Mo).RealValue = _view.MoBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.Nb).RealValue = _view.NbBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.Ni).RealValue = _view.NiBaseMaterial2;
                secondBaseMaterial.GetElement(Category.OfElement.Ti).RealValue = _view.TiBaseMaterial2;
                _dataConnector.SaveSecondBasisMarerialForSchaeffler(secondBaseMaterial);
            }

            if (_view.ChangeAdditionalMaterialChecked)
            {
                var addMaterial = new AdditiveMaterial();
                addMaterial.Name = "Mat. dodatkowy";
                addMaterial.GuidNumber = new Guid();
                addMaterial.CreateBasicListOfElements();
                addMaterial.GetElement(Category.OfElement.C).RealValue = _view.CAddMaterial;
                addMaterial.GetElement(Category.OfElement.Si).RealValue = _view.SiAddMaterial;
                addMaterial.GetElement(Category.OfElement.Mn).RealValue = _view.MnAddMaterial;
                addMaterial.GetElement(Category.OfElement.N).RealValue = _view.NAddMaterial;
                addMaterial.GetElement(Category.OfElement.Cr).RealValue = _view.CrAddMaterial;
                addMaterial.GetElement(Category.OfElement.Mo).RealValue = _view.MoAddMaterial;
                addMaterial.GetElement(Category.OfElement.Nb).RealValue = _view.NbAddMaterial;
                addMaterial.GetElement(Category.OfElement.Ni).RealValue = _view.NiAddMaterial;
                addMaterial.GetElement(Category.OfElement.Ti).RealValue = _view.TiAddMaterial;
                _dataConnector.SaveAdditionalMaterialForSchaeffler(addMaterial);
            }
        }

        public void OnEquivalentSelectedIndexChanged()
        {
            FillEquivalentsWithCurrentMaterialsState();
        }

        private void LoadEquivalentsComboBox()
        {
            _view.EquivalentsList = new List<string>()
            {
                "Schaeffler",
                "DeLong",
                "WRC1992"
            };
        }
    }
}
