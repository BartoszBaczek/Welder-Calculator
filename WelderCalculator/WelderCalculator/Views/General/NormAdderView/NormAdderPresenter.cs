using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Views.General.MaterialDatabasePropertiesView;

namespace WelderCalculator.Views.General.NormAdderView
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
            if (_view.MaterialType == MaterialType.BaseMaterial)
            {
                if (!string.IsNullOrEmpty(_view.NormName.Trim()))
                {
                    var normToSave = new BaseNorm() { Name = _view.NormName };
                    _dataConnector.SaveBaseNorm(normToSave);
                    _view.CloseDialog();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_view.NormName.Trim()))
                {
                    var normToSave = new AdditiveNorm() { Name = _view.NormName };
                    _dataConnector.SaveAdditiveNorm(normToSave);
                    _view.CloseDialog();
                }
            }
            
        }

        public void OnCancelButtonClicked()
        {
            _view.CloseDialog();
        }
    }
}
