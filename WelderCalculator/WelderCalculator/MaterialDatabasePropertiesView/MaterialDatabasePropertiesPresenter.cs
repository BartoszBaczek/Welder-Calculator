using System;
using System.Collections.Generic;
using System.Linq;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public class MaterialDatabasePropertiesPresenter
    {
        #region Aa
        //FOR TESTS - DELETE LATER
        private List<Category.OfElement> listOfElements = Enum.GetValues(typeof(Category.OfElement))
                                 .Cast<Category.OfElement>()
                                 .ToList();
        // END FOR TESTS
        #endregion
        
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

        public void Init()
        {
            FillComboBoxesWithCurrentOrder();
        }

        private void FillComboBoxesWithCurrentOrder()
        {
            List<string> listOfElementsAsString = new List<string>();
            //convert listOfEnums to ListOfStrings
            for (int i = 0; i < listOfElements.Count; i++)
            {
                listOfElementsAsString.Add(listOfElements[i].ToString());
            }

            for (int i = 0; i < _view.ElementsComboBoxes.Count; i++)
            {
                _view.ElementsComboBoxes[i].AvalibleElements = listOfElementsAsString;
                _view.ElementsComboBoxes[i].CurrentIndex = i;
            }

            _view.ApplyChangesInComboBoxes();
        }

        
    }
}
