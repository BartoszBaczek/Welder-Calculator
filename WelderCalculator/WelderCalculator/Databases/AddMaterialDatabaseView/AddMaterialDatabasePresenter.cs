using WelderCalculator.MaterialModificationView.Serialization;

namespace WelderCalculator.Databases.AddMaterialDatabaseView
{
    public class AddMaterialDatabasePresenter
    {
        private readonly IAdditiveMaterialView _view;
        private readonly DataConnector _dataConnector;

        public AddMaterialDatabasePresenter(IAdditiveMaterialView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
        }

        public void Init()
        {
            LoadNormComboBoxes();
        }

        private void LoadNormComboBoxes()
        {
            _view.NormsList = _dataConnector.GetNamesOfAdditiveNorms();
        }



    }
}
