using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesPresenter
    {
        private readonly IMaterialDatabasePropertiesView _view;

        private readonly IElementsOrderPropertiesRepository _repository;

        public MaterialDatabasePropertiesPresenter(IMaterialDatabasePropertiesView view,
            IElementsOrderPropertiesRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
        }

        public void Init()
        {
            //for test only
            _view.ElementsList1st = new List<string>() {"1", "2", "3"};
        }
    }
}
