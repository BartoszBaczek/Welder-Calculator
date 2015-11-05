using System.Collections.Generic;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesPresenter
    {
        private readonly IMaterialDatabasePropertiesView _view;
        private readonly IElementsOrderPropertiesRepository _repository;


        public MaterialDatabasePropertiesPresenter(IMaterialDatabasePropertiesView view,
            IElementsOrderPropertiesRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            Init();
        }

        private void Init()
        {
            LoadComboBoxesWithCurrentOrder();
            UpdateDataSourcesForComboBoxes();
        }

        private List<string> GetBasicDataSourceForComboBox()
        {
            #region All enums to List
            //FOR TESTS - DELETE LATER
            //List<Category.OfElement> listOfElements = Enum.GetValues(typeof(Category.OfElement))
            //                        .Cast<Category.OfElement>()
            //                        .ToList();
            // END FOR TESTS
            #endregion
            List<Category.OfElement> listOfElements = new List<Category.OfElement>()
            {
                Category.OfElement.Al,
                Category.OfElement.C,
                Category.OfElement.Cu,
                Category.OfElement.Cr,
                Category.OfElement.S,
                Category.OfElement.Mn,
                Category.OfElement.Mo,
                Category.OfElement.N,
                Category.OfElement.Nb,
                Category.OfElement.Ni,
                Category.OfElement.P,
                Category.OfElement.V,
                Category.OfElement.Si,
                Category.OfElement.Ti
            };
            List<string> listOfElementsForComboBox = new List<string>();

            foreach (var element in listOfElements)
            {
                listOfElementsForComboBox.Add(element.ToString());
            }

            string emptyField = "";
            listOfElementsForComboBox.Add(emptyField);

            return listOfElementsForComboBox;
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

                if (!(dataSource[selectedIndex] == string.Empty))
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
    }
}
