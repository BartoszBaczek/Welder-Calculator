using System.Collections.Generic;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesPresenter
    {
        private readonly IMaterialDatabasePropertiesView _view;
        private readonly IElementsOrderPropertiesRepository _repository;
        private readonly MaterialDatabasePropertiesDataReader _dataReader;

        public MaterialDatabasePropertiesPresenter(IMaterialDatabasePropertiesView view,
            IElementsOrderPropertiesRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _dataReader = new MaterialDatabasePropertiesDataReader();
            Init();
        }

        private void Init()
        {
            LoadComboBoxesWithCurrentOrder();
            UpdateDataSourcesForComboBoxes();
        }

        private List<string> GetBasicDataSourceForComboBox()
        {
            var savedOrderOfElements = _dataReader.GetOrderOfElementFromFile();

            //adds empty string as last option in comboBox
            savedOrderOfElements.Add(" ");

            return savedOrderOfElements;
        }

        private void LoadComboBoxesWithCurrentOrder()
        {
            List<string> currentOrderOfElements = GetBasicDataSourceForComboBox();

            for (int i = 1; i <= _view.NumberOfComboBoxes; i++)
            {
                int comboBoxID = i;

                _view.SetDataSourcesForComboBoxes(currentOrderOfElements, comboBoxID);
                _view.SetSelectedIndex(comboBoxID, i - 1);
            }
        }

        private void UpdateDataSourcesForComboBoxes()
        {
            List<string> alreadyUsedElements = new List<string>();

            for (int i = 1; i <= _view.NumberOfComboBoxes; i++)
            {
                int comboBoxID = i;
                List<string> dataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxID);
                int selectedIndex = _view.GetSelectedIndex(comboBoxID);

                if (dataSource[selectedIndex] != string.Empty)
                    alreadyUsedElements.Add(dataSource[selectedIndex]);
            }

            for (int i = 1; i <= _view.NumberOfComboBoxes; i++)
            {
                List<string> basicDataSourcesWithoutUsedElements = GetBasicDataSourceForComboBox();

                foreach (var usedElement in alreadyUsedElements)
                {
                    basicDataSourcesWithoutUsedElements.Remove(usedElement);
                }

                int comboBoxID = i;

                List<string> dataSource = _view.GetListOfAvalibleElementsForComboBoxes(comboBoxID);

                    int selectedIndex = _view.GetSelectedIndex(comboBoxID);
                    basicDataSourcesWithoutUsedElements.Add(dataSource[selectedIndex]);

                    _view.SetDataSourcesForComboBoxes(basicDataSourcesWithoutUsedElements, comboBoxID);
                    _view.SetSelectedIndex(comboBoxID, basicDataSourcesWithoutUsedElements.IndexOf(dataSource[selectedIndex]));
            }
        }

        public void OnSelectedIndexChanged(int comboBoxID)
        {
            UpdateDataSourcesForComboBoxes();
        }
    }
}
