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
    }
}
