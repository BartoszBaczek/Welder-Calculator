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
            LoadComboBoxesWithCurrentOrder();
        }

        private void LoadComboBoxesWithCurrentOrder()
        {
            List<string> testList = new List<string>()
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J",
                "K",
                "L",
                "M",
                "N"
            };

            for (int i = 0; i < testList.Count; i++)
            {
                _view.SetAvalibleElementsForComboBoxes(testList, i+1);
                _view.SetSelectedIndex(i+1, i+1);
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
            _view.SetAvalibleElementsForComboBoxes(lists);
            Debug.WriteLine(_view.GetListOfAvalibleElementsForComboBoxes(1)[0]);
            Debug.WriteLine(_view.GetListOfAvalibleElementsForComboBoxes()[1][2]);
        }

        
    }
}
