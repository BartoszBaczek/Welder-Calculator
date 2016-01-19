using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Repositories;

namespace WelderCalculator.Views.General.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesPresenter
    {
        private readonly IMaterialDatabasePropertiesView _view;
        private readonly DataConnector _dataConnector;

        public MaterialDatabasePropertiesPresenter(IMaterialDatabasePropertiesView view)
        {
            _view = view;
            view.Presenter = this;
            _dataConnector = new DataConnector();
            Init();
        }

        private void Init()
        {
            if (_view.MaterialType == MaterialType.BaseMaterial)
            {
                var lastSavedOrderOfElements = _dataConnector.GetOrderOfElementsForBaseMaterial();
                BindDataToComboBoxes(lastSavedOrderOfElements);
                UpdateComboBoxes();
            }
            else
            {
                var lastSavedOrderOfElements = _dataConnector.GetOrderOfElementsForAdditiveMaterial();
                BindDataToComboBoxes(lastSavedOrderOfElements);
                UpdateComboBoxes();
            }
            
        }

        private void BindDataToComboBoxes(IEnumerable<Category.OfElement> elementsInOrder)
        {
            List<string> dataToBind = elementsInOrder.Select(element => element.ToString()).ToList();

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
            }
            for (int i = 0; i < _view.NumberOfComboBoxes; i++)
            {
                int comboBoxNumber = i + 1;
                List<string> currentDataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxNumber);
                int currentSelectedIndex = _view.GetSelectedIndex(comboBoxNumber);

                string selectedElement = currentDataSource[currentSelectedIndex];

                List<string> dataNotToBind = new List<string>(usedElements);
                dataNotToBind.Remove(selectedElement);

                List<Category.OfElement> orderOfElements;
                if (_view.MaterialType == MaterialType.BaseMaterial)
                    orderOfElements = _dataConnector.GetOrderOfElementsForBaseMaterial();
                else
                    orderOfElements = _dataConnector.GetOrderOfElementsForAdditiveMaterial();
                List<string> maxPossibleDataSource = orderOfElements.Select(element => element.ToString()).ToList();
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
            bool someComboBoxIsEmpty = false;

            List<Category.OfElement> lastSavedOrder;
            if (_view.MaterialType == MaterialType.BaseMaterial)
                lastSavedOrder = _dataConnector.GetOrderOfElementsForBaseMaterial();
            else
                lastSavedOrder = _dataConnector.GetOrderOfElementsForAdditiveMaterial();
            var newOrder = new List<Category.OfElement>();

            for (int i = 0; i < _view.NumberOfComboBoxes; i++)
            {
                int comboBoxID = i + 1;

                var comboBoxDataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxID);
                var comboBoxSelectedIndex = _view.GetSelectedIndex(comboBoxID);

                string elementToAdd = comboBoxDataSource[comboBoxSelectedIndex];
                try
                {
                    Category.OfElement element = (Category.OfElement) Enum.Parse(typeof (Category.OfElement), elementToAdd, true);
                    newOrder.Add(element);
                }
                catch (ArgumentException)
                {
                    someComboBoxIsEmpty = true;
                }
            }

            if (someComboBoxIsEmpty)
            {
                var dialogResult = MessageBox.Show("Niektóre pola zawierają puste miejsca. Czy chcesz przywrócić ostatnią kolejność?", "AWARIA", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    List<Category.OfElement> orderOfElements;
                    if (_view.MaterialType == MaterialType.BaseMaterial)
                        orderOfElements = _dataConnector.GetOrderOfElementsForBaseMaterial();
                    else
                        orderOfElements = _dataConnector.GetOrderOfElementsForAdditiveMaterial();

                    BindDataToComboBoxes(orderOfElements);

                    UpdateComboBoxes();
                }
            }
            else if (!lastSavedOrder.SequenceEqual(newOrder))
            {
                var dialogResult = MessageBox.Show("Czy na pewno chcesz zapisać nową kolejność pierwiastków?", "POTWIERDZENIE", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    if (_view.MaterialType == MaterialType.BaseMaterial)
                        _dataConnector.SaveBaseNormProperties(newOrder);
                    else
                        _dataConnector.SaveAdditiveNormPRoperties(newOrder);

                    _view.CloseDialog();
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
