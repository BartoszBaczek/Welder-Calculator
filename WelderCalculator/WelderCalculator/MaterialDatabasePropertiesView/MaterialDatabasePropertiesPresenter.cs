using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public void Init()
        {
            LoadComboBoxesWithCurrentOrder();
        }

        private List<Category.OfElement> GetLastSavedOrderOfElements()
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

            return listOfElements;
        }

        private void LoadComboBoxesWithCurrentOrder()
        {
            List<Category.OfElement> currentOrderOfElements = GetLastSavedOrderOfElements();
            List<string> transfromedOrderOfElementsToComboBox = new List<string>();

            for (int i = 0; i < currentOrderOfElements.Count; i++)
            {
                transfromedOrderOfElementsToComboBox.Add((currentOrderOfElements[i].ToString()));
            }
            for (int i = 0; i < transfromedOrderOfElementsToComboBox.Count; i++)
            {
                _view.SetAvalibleElementsForComboBox(transfromedOrderOfElementsToComboBox, i + 1);
                _view.SetSelectedIndex(i+1, i);
            }
        }

        public void DoTest()
        {
            List<string> testList1 = new List<string>()
            {
                "1st element",
                "2nd element",
                "3rd element"
            };

            List<string> testList2 = new List<string>()
            {
                "3rd element",
                "1st element",
                "2nd element",
            };

            List<string> testList3 = new List<string>()
            {
                "2nd element",
                "1st element",
                "3rd element"
            };
            
            List<List<string>> lists = new List<List<string>>()
            {
                testList1,
                testList2,
                testList3
            };
            _view.SetAvalibleElementsForComboBox(lists);
            Debug.WriteLine(_view.GetListOfAvalibleElementsForComboBoxes(1)[0]);
            Debug.WriteLine(_view.GetListOfAvalibleElementsForComboBoxes()[1][2]);
        }

        
    }
}
