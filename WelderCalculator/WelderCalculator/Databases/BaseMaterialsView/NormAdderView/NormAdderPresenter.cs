using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.MaterialModificationView.Serialization;
using WelderCalculator.Repositories.Model.temp2;

namespace WelderCalculator.Databases.BaseMaterialsView
{
    public class NormAdderPresenter
    {
        private INormAdderView _view;
        private DataConnector _dataConnector;

        public NormAdderPresenter(INormAdderView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public void OnOkButtonClicked()
        {
            if (! string.IsNullOrEmpty(_view.NormName.Trim()))
            {
                var normToSave = new BaseNorm() {Name = _view.NormName};
                _dataConnector.SaveBaseNorm(normToSave);
                _view.CloseDialog();
            }
        }

        public void OnCancelButtonClicked()
        {
            _view.CloseDialog();
        }
    }
}
