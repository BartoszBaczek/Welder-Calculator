using System;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.Views.FastMaterialFactoryView
{
    public class FastMaterialFactoryPresenter
    {
        private readonly IFastMaterialFactoryView _view;
        private readonly DataConnector _dataConnector;

        public FastMaterialFactoryPresenter(IFastMaterialFactoryView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new DataConnector();
            Init();
        }

        private void Init()
        {
            var firstBaseMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            _view.NiBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.Cr).RealValue;
            _view.CBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.C).RealValue;
            _view.MnBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.Mo).RealValue;
            _view.NBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.N).RealValue;
            _view.SiBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.Si).RealValue;
            _view.NbBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.Nb).RealValue;
            _view.TiBaseMaterial1 = firstBaseMaterial.GetElement(Category.OfElement.Ti).RealValue;

            var secondBaseMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            _view.NiBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.Cr).RealValue;
            _view.CBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.C).RealValue;
            _view.MnBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.Mo).RealValue;
            _view.NBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.N).RealValue;
            _view.SiBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.Si).RealValue;
            _view.NbBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.Nb).RealValue;
            _view.TiBaseMaterial2 = secondBaseMaterial.GetElement(Category.OfElement.Ti).RealValue;

            var addMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
            _view.NiAddMaterial = addMaterial.GetElement(Category.OfElement.Ni).RealValue;
            _view.CrAddMaterial = addMaterial.GetElement(Category.OfElement.Cr).RealValue;
            _view.CAddMaterial = addMaterial.GetElement(Category.OfElement.C).RealValue;
            _view.MnAddMaterial = addMaterial.GetElement(Category.OfElement.Mn).RealValue;
            _view.MoAddMaterial = addMaterial.GetElement(Category.OfElement.Mo).RealValue;
            _view.NAddMaterial = addMaterial.GetElement(Category.OfElement.N).RealValue;
            _view.SiAddMaterial = addMaterial.GetElement(Category.OfElement.Si).RealValue;
            _view.NbAddMaterial = addMaterial.GetElement(Category.OfElement.Nb).RealValue;
            _view.TiAddMaterial = addMaterial.GetElement(Category.OfElement.Ti).RealValue;
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
    }
}
