using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesPresenter
    {
        private readonly IMaterialDatabasePropertiesView _view;
        private readonly MaterialDatabasePropertiesDataReader _dataReader;

        public MaterialDatabasePropertiesPresenter(IMaterialDatabasePropertiesView view)
        {
            _view = view;
            view.Presenter = this;
            _dataReader = new MaterialDatabasePropertiesDataReader();
            Init();
        }

        private void Init()
        {
            
        }
        
        public void OnSelectedIndexChanged()
        {

        }

        public void OnApplyButtonPressed()
        {
            
        }
        public void OnCancelButtonPressed()
        {

        }
    }
}
