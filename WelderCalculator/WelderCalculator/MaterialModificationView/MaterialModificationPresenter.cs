using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialModificationView
{
    public class MaterialModificationPresenter
    {
        private readonly IMaterialModificationView _view;
        //connector to repo?

        public MaterialModificationPresenter(IMaterialModificationView view)
        {
            _view = view;
            view.Presenter = this;
            //_connector = new connector?
        }

        public MaterialModificationPresenter(IMaterialModificationView view, Material materialToModify)
        {
            _view = view;
            view.Presenter = this;
            //_connector = new connector?
            BindToControls(materialToModify);
        }

        private void BindToControls(Material material)
        {
            _view.NameTextbox = material.Name;
            _view.NumberTextbox = material.Number;
            _view.GuidTextbox = material.GuidNumber.ToString();

            Element e = material.GetElement(Category.OfElement.C);
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
    }
}
