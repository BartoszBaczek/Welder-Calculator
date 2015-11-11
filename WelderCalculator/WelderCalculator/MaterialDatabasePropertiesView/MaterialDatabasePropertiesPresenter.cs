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
            var lastSavedOrderOfElements = _dataReader.GetOrderOfElementFromFile();
            BindDataToComboBoxes(lastSavedOrderOfElements);
        }

        private void BindDataToComboBoxes(List<string> comboBoxesData)
        {
            for (int i = 1; i <= _view.NumberOfComboBoxes; i++)
            {
                int comboBoxIndex = i;

                _view.SetDataSourcesForComboBoxes(comboBoxesData, comboBoxIndex);
                _view.SetSelectedIndex(comboBoxIndex,comboBoxesData.IndexOf(comboBoxesData[i-1]));
            }
        }






        #region Events
        public void OnSelectedIndexChanged()
        {

        }

        public void OnApplyButtonPressed()
        {
            
        }
        public void OnCancelButtonPressed()
        {

        }
        #endregion
    }
}
