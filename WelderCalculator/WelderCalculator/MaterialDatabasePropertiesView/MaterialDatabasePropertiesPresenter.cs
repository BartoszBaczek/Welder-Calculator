using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            UpdateComboBoxes();
        }

        private void BindDataToComboBoxes(List<string> elementsInOrder)
        {
            var dataToBind = elementsInOrder;
            dataToBind.Add(String.Empty);

            for (int i = 0; i < _view.NumberOfComboBoxes; i++)
            {
                int comboBoxNumber = i + 1;

                _view.SetDataSourcesForComboBoxes(comboBoxNumber, dataToBind);
                _view.SetSelectedIndex(comboBoxNumber, i);
            }
        }

        private void UpdateComboBoxes()
        {
            var usedElements = new List<string>();

            for (int i = 0; i < _view.NumberOfComboBoxes; i++)
            {
                int comboBoxNumber = i + 1;
                List<string> currentDataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxNumber);
                int currentSelectedIndex = _view.GetSelectedIndex(comboBoxNumber);

                usedElements.Add(currentDataSource[currentSelectedIndex]);
            }

            for (int i = 0; i < _view.NumberOfComboBoxes; i++)
            {
                int comboBoxNumber = i + 1;
                List<string> currentDataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxNumber);
                int currentSelectedIndex = _view.GetSelectedIndex(comboBoxNumber);

                string selectedElement = currentDataSource[currentSelectedIndex];

                List<string> dataNotToBind = new List<string>(usedElements);
                dataNotToBind.Remove(selectedElement);

                currentDataSource = currentDataSource.Except(dataNotToBind).ToList();
                int indexToSelectedElement = currentDataSource.IndexOf(selectedElement);
                _view.SetDataSourcesForComboBoxes(comboBoxNumber, currentDataSource);
                _view.SetSelectedIndex(comboBoxNumber, indexToSelectedElement);
            } 
        }

        #region Events
        public void OnSelectedIndexChanged()
        {
            UpdateComboBoxes();
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
