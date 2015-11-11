using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesPresenter
    {
        private readonly IMaterialDatabasePropertiesView _view;
        private readonly MaterialDatabasePropertiesDataConnector _dataConnector;

        public MaterialDatabasePropertiesPresenter(IMaterialDatabasePropertiesView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new MaterialDatabasePropertiesDataConnector();
            Init();
        }

        private void Init()
        {
            var lastSavedOrderOfElements = _dataConnector.GetOrderOfElementFromFile();
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

                if (!string.IsNullOrEmpty(currentDataSource[currentSelectedIndex]))
                    usedElements.Add(currentDataSource[currentSelectedIndex]);
                else
                {
                    Debug.WriteLine("PUSTKA");
                    Debug.WriteLine(" ");
                }
            }
            for (int i = 0; i < _view.NumberOfComboBoxes; i++)
            {
                int comboBoxNumber = i + 1;
                List<string> currentDataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxNumber);
                int currentSelectedIndex = _view.GetSelectedIndex(comboBoxNumber);

                string selectedElement = currentDataSource[currentSelectedIndex];

                List<string> dataNotToBind = new List<string>(usedElements);
                dataNotToBind.Remove(selectedElement);

                List<string> maxPossibleDataSource = _dataConnector.GetOrderOfElementFromFile();
                maxPossibleDataSource.Add(string.Empty);

                currentDataSource = maxPossibleDataSource.Except(dataNotToBind).ToList();
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
            var lastSavedOrder = _dataConnector.GetOrderOfElementFromFile();
            var newOrder = new List<string>();

            for (int i = 0; i < _view.NumberOfComboBoxes; i++)
            {
                int comboBoxID = i + 1;

                var comboBoxDataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxID);
                var comboBoxSelectedIndex = _view.GetSelectedIndex(comboBoxID);

                newOrder.Add(comboBoxDataSource[comboBoxSelectedIndex]);
            }

            if (newOrder.Contains(string.Empty))
            {
                var dialogResult = MessageBox.Show("Niektóre pola zawierają puste miejsca. Czy chcesz przywrócić ostatnią kolejność?", "AWARIA", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var lastSavedOrderOfElements = _dataConnector.GetOrderOfElementFromFile();
                    BindDataToComboBoxes(lastSavedOrderOfElements);

                    UpdateComboBoxes();
                }
            }
            else if (!lastSavedOrder.SequenceEqual(newOrder))
            {
                var dialogResult = MessageBox.Show("Czy na pewno chcesz zapisać nową kolejność pierwiastków?", "POTWIERDZENIE", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    _dataConnector.SaveOrderOfElementsToFile(newOrder);
                }
            }
            else
            {
                MessageBox.Show("Kolejność nie zmieniła się");
            }
        }
        public void OnCancelButtonPressed()
        {
            _view.CloseDialog();
        }
        #endregion
    }
}
