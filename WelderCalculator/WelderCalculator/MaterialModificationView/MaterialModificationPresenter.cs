using System;
using System.Linq;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialModificationView
{
    public class MaterialModificationPresenter
    {
        private readonly IMaterialModificationView _view;
        private readonly WindowMode.Mode _workingMode;

        //connector to repo?

        public MaterialModificationPresenter(IMaterialModificationView view)
        {
            _workingMode = WindowMode.Mode.AddNew;
            _view = view;
            view.Presenter = this;
            //_connector = new connector?
        }

        public MaterialModificationPresenter(IMaterialModificationView view, object materialToModify)
        {
            _workingMode = WindowMode.Mode.ModifyCurrent;
            _view = view;
            view.Presenter = this;
            //_connector = new connector?
            BindToControls(materialToModify);
            var a = BuildMaterial();
        }

        private void BindToControls(object asdas)
        {
            var material = asdas as Material;
            _view.NameTextbox = material.Name;
            _view.NumberTextbox = material.Number;
            _view.GuidTextbox = material.GuidNumber.ToString();

            var e = material.GetElement(Category.OfElement.C);
            _view.CMintextbox = e.Min;
            _view.CMaxtextbox = e.Max;
            _view.CRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Si);
            _view.SiMintextbox = e.Min;
            _view.SiMaxtextbox = e.Max;
            _view.SiRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Mn);
            _view.MnMintextbox = e.Min;
            _view.MnMaxtextbox = e.Max;
            _view.MnRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.P);
            _view.PMintextbox = e.Min;
            _view.PMaxtextbox = e.Max;
            _view.PRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.S);
            _view.SMintextbox = e.Min;
            _view.SMaxtextbox = e.Max;
            _view.SRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.N);
            _view.NMintextbox = e.Min;
            _view.NMaxtextbox = e.Max;
            _view.NRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Cr);
            _view.CrMintextbox = e.Min;
            _view.CrMaxtextbox = e.Max;
            _view.CrRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Mo);
            _view.MoMintextbox = e.Min;
            _view.MoMaxtextbox = e.Max;
            _view.MoRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Nb);
            _view.NbMintextbox = e.Min;
            _view.NbMaxtextbox = e.Max;
            _view.NbRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Ni);
            _view.NiMintextbox = e.Min;
            _view.NiMaxtextbox = e.Min;
            _view.NiRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Ti);
            _view.TiMintextbox = e.Min;
            _view.TiMaxtextbox = e.Max;
            _view.TiRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Al);
            _view.AlMintextbox = e.Min;
            _view.AlMaxtextbox = e.Max;
            _view.AlRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.V);
            _view.VMintextbox = e.Min;
            _view.VMaxtextbox = e.Max;
            _view.VRealtextbox = e.RealValue;

            e = material.GetElement(Category.OfElement.Cu);
            _view.CuMintextbox = e.Min;
            _view.CuMaxtextbox = e.Max;
            _view.CuRealtextbox = e.RealValue;
        }

        private Material BuildMaterial()
        {
            var material = new Material();
            material.CreateBasicListOfElements();

            material.Name = _view.NameTextbox;
            material.Number = _view.NumberTextbox;

            material.GetElement(Category.OfElement.C).Min = _view.CMintextbox;
            material.GetElement(Category.OfElement.C).Max = _view.CMaxtextbox;
            material.GetElement(Category.OfElement.C).RealValue = _view.CRealtextbox;

            material.GetElement(Category.OfElement.Si).Min = _view.SiMintextbox;
            material.GetElement(Category.OfElement.Si).Max = _view.SiMaxtextbox;
            material.GetElement(Category.OfElement.Si).RealValue = _view.SiRealtextbox;

            material.GetElement(Category.OfElement.Mn).Min = _view.MnMintextbox;
            material.GetElement(Category.OfElement.Mn).Max = _view.MnMaxtextbox;
            material.GetElement(Category.OfElement.Mn).RealValue = _view.MnRealtextbox;

            material.GetElement(Category.OfElement.P).Min = _view.PMintextbox;
            material.GetElement(Category.OfElement.P).Max = _view.PMaxtextbox;
            material.GetElement(Category.OfElement.P).RealValue = _view.PRealtextbox;

            material.GetElement(Category.OfElement.S).Min = _view.SMintextbox;
            material.GetElement(Category.OfElement.S).Max = _view.SMaxtextbox;
            material.GetElement(Category.OfElement.S).RealValue = _view.SRealtextbox;

            material.GetElement(Category.OfElement.N).Min = _view.NMintextbox;
            material.GetElement(Category.OfElement.N).Max = _view.NMaxtextbox;
            material.GetElement(Category.OfElement.N).RealValue = _view.NRealtextbox;

            material.GetElement(Category.OfElement.Cr).Min = _view.CrMintextbox;
            material.GetElement(Category.OfElement.Cr).Max = _view.CrMaxtextbox;
            material.GetElement(Category.OfElement.Cr).RealValue = _view.CrRealtextbox;

            material.GetElement(Category.OfElement.Mo).Min = _view.MoMintextbox;
            material.GetElement(Category.OfElement.Mo).Max = _view.MoMaxtextbox;
            material.GetElement(Category.OfElement.Mo).RealValue = _view.MoRealtextbox;

            material.GetElement(Category.OfElement.Nb).Min = _view.NbMintextbox;
            material.GetElement(Category.OfElement.Nb).Max = _view.NbMaxtextbox;
            material.GetElement(Category.OfElement.Nb).RealValue = _view.NbRealtextbox;

            material.GetElement(Category.OfElement.Ni).Min = _view.NiMintextbox;
            material.GetElement(Category.OfElement.Ni).Max = _view.NiMaxtextbox;
            material.GetElement(Category.OfElement.Ni).RealValue = _view.NiRealtextbox;

            material.GetElement(Category.OfElement.Ti).Min = _view.TiMintextbox;
            material.GetElement(Category.OfElement.Ti).Max = _view.TiMaxtextbox;
            material.GetElement(Category.OfElement.Ti).RealValue = _view.TiRealtextbox;

            material.GetElement(Category.OfElement.Al).Min = _view.AlMintextbox;
            material.GetElement(Category.OfElement.Al).Max = _view.AlMaxtextbox;
            material.GetElement(Category.OfElement.Al).RealValue = _view.AlRealtextbox;

            material.GetElement(Category.OfElement.V).Min = _view.VMintextbox;
            material.GetElement(Category.OfElement.V).Max = _view.VMaxtextbox;
            material.GetElement(Category.OfElement.V).RealValue = _view.VRealtextbox;

            material.GetElement(Category.OfElement.Cu).Min = _view.CuMintextbox;
            material.GetElement(Category.OfElement.Cu).Max = _view.CuMaxtextbox;
            material.GetElement(Category.OfElement.Cu).RealValue = _view.CuRealtextbox;

            if (_workingMode == WindowMode.Mode.AddNew)
                material.GuidNumber = Guid.NewGuid();
            else if (_workingMode == WindowMode.Mode.ModifyCurrent)
                material.GuidNumber = Guid.Parse(_view.GuidTextbox);

            return material;
        }
    
    
    }
}
