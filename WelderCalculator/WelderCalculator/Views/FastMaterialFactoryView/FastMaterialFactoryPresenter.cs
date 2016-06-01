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

            LoadEquivalentsComboBox();
            FillElementsTextBoxesWithCurrentMaterialsState();
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
            _view.CuBaseMaterial1 = _currentBaseMaterial1State.GetElement(Category.OfElement.Cu).RealValue;

            // BaseMaterial2
            _view.NiBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Cr).RealValue;
            _view.CBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.C).RealValue;
            _view.MnBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Mo).RealValue;
            _view.NBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.N).RealValue;
            _view.SiBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Si).RealValue;
            _view.NbBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Nb).RealValue;
            _view.CuBaseMaterial2 = _currentBaseMaterial2State.GetElement(Category.OfElement.Cu).RealValue;

            // AddMaterial
            _view.NiAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Cr).RealValue;
            _view.CAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.C).RealValue;
            _view.MnAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Mo).RealValue;
            _view.NAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.N).RealValue;
            _view.SiAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Si).RealValue;
            _view.NbAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Nb).RealValue;
            _view.CuAddMaterial = _currentAdditionalMaterial1State.GetElement(Category.OfElement.Cu).RealValue;
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
                firstBaseMaterial.GetElement(Category.OfElement.C).RealValue = _view.CBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.Si).RealValue = _view.SiBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.Mn).RealValue = _view.MnBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.N).RealValue = _view.NBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.Cr).RealValue = _view.CrBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.Mo).RealValue = _view.MoBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.Nb).RealValue = _view.NbBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.Ni).RealValue = _view.NiBaseMaterial1 ?? 0;
                firstBaseMaterial.GetElement(Category.OfElement.Cu).RealValue = _view.CuBaseMaterial1 ?? 0;
                _dataConnector.SaveFirstBasisMarerialForSchaeffler(firstBaseMaterial);
            }

            if (_view.ChangeBaseMaterial2Checked)
            {
                var secondBaseMaterial = new BaseMaterial();
                secondBaseMaterial.Name = "Mat. bazowy 2";
                secondBaseMaterial.GuidNumber = new Guid();
                secondBaseMaterial.CreateBasicListOfElements();
                secondBaseMaterial.GetElement(Category.OfElement.C).RealValue = _view.CBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.Si).RealValue = _view.SiBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.Mn).RealValue = _view.MnBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.N).RealValue = _view.NBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.Cr).RealValue = _view.CrBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.Mo).RealValue = _view.MoBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.Nb).RealValue = _view.NbBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.Ni).RealValue = _view.NiBaseMaterial2 ?? 0;
                secondBaseMaterial.GetElement(Category.OfElement.Cu).RealValue = _view.CuBaseMaterial2 ?? 0;
                _dataConnector.SaveSecondBasisMarerialForSchaeffler(secondBaseMaterial);
            }

            if (_view.ChangeAdditionalMaterialChecked)
            {
                var addMaterial = new AdditiveMaterial();
                addMaterial.Name = "Mat. dodatkowy";
                addMaterial.GuidNumber = new Guid();
                addMaterial.CreateBasicListOfElements();
                addMaterial.GetElement(Category.OfElement.C).RealValue = _view.CAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.Si).RealValue = _view.SiAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.Mn).RealValue = _view.MnAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.N).RealValue = _view.NAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.Cr).RealValue = _view.CrAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.Mo).RealValue = _view.MoAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.Nb).RealValue = _view.NbAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.Ni).RealValue = _view.NiAddMaterial ?? 0;
                addMaterial.GetElement(Category.OfElement.Cu).RealValue = _view.CuAddMaterial ?? 0;
                _dataConnector.SaveAdditionalMaterialForSchaeffler(addMaterial);
            }
        }

        public void OnEquivalentSelectedIndexChanged()
        {
            FillEquivalentsWithCurrentMaterialsState();
        }

        public void OnElementTextBoxChanged(string elementTextBoxName)
        {
            switch (elementTextBoxName)
            {
                case "niBaseMaterial":
                    if (_view.NiBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.Ni).RealValue = _view.NiBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "crBaseMaterial":
                    if (_view.CrBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.Cr).RealValue = _view.CrBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "cBaseMaterial":
                    if (_view.CBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.C).RealValue = _view.CBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "mnBaseMaterial":
                    if (_view.MnBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.Mn).RealValue = _view.MnBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "moBaseMaterial":
                    if (_view.MoBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.Mo).RealValue = _view.MoBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "nBaseMaterial":
                    if (_view.NBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.N).RealValue = _view.NBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "siBaseMaterial":
                    if (_view.SiBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.Si).RealValue = _view.SiBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "nbBaseMaterial":
                    if (_view.NbBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.Nb).RealValue = _view.NbBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "cuBaseMaterial":
                    if (_view.CuBaseMaterial1 != null)
                    {
                        _currentBaseMaterial1State.GetElement(Category.OfElement.Cu).RealValue = _view.CuBaseMaterial1;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;


                case "niBaseMaterial2":
                    if (_view.NiBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.Ni).RealValue = _view.NiBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "crBaseMaterial2":
                    if (_view.CrBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.Cr).RealValue = _view.CrBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "cBaseMaterial2":
                    if (_view.CBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.C).RealValue = _view.CBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "mnBaseMaterial2":
                    if (_view.MnBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.Mn).RealValue = _view.MnBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "moBaseMaterial2":
                    if (_view.MoBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.Mo).RealValue = _view.MoBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "nBaseMaterial2":
                    if (_view.NBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.N).RealValue = _view.NBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "siBaseMaterial2":
                    if (_view.SiBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.Si).RealValue = _view.SiBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "nbBaseMaterial2":
                    if (_view.NbBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.Nb).RealValue = _view.NbBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "cuBaseMaterial2":
                    if (_view.CuBaseMaterial2 != null)
                    {
                        _currentBaseMaterial2State.GetElement(Category.OfElement.Cu).RealValue = _view.CuBaseMaterial2;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;


                case "niAddMaterial":
                    if (_view.NiAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.Ni).RealValue = _view.NiAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "crAddMaterial":
                    if (_view.CrAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.Cr).RealValue = _view.CrAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "cAddMaterial":
                    if (_view.CAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.C).RealValue = _view.CAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "mnAddMaterial":
                    if (_view.MnAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.Mn).RealValue = _view.MnAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "moAddMaterial":
                    if (_view.MoAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.Mo).RealValue = _view.MoAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "nAddMaterial":
                    if (_view.NAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.N).RealValue = _view.NAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "siAddMaterial":
                    if (_view.SiAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.Si).RealValue = _view.SiAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "nbAddMaterial":
                    if (_view.NbAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.Nb).RealValue = _view.NbAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;
                case "cuAddMaterial":
                    if (_view.CuAddMaterial != null)
                    {
                        _currentAdditionalMaterial1State.GetElement(Category.OfElement.Cu).RealValue = _view.CuAddMaterial;
                        FillEquivalentsWithCurrentMaterialsState();
                    }
                    break;

            }
        }
    }
}
