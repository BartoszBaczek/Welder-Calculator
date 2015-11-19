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

            _view.Ctextbox = material.GetElement(Category.OfElement.C);

        }
    }
}
