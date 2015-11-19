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
        }
    }
}
