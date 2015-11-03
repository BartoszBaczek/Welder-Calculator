using System.Collections.Generic;

namespace WelderCalculator.MaterialDatabasePropertiesView
{

    public interface IMaterialDatabasePropertiesView
    {
        MaterialDatabasePropertiesPresenter Presenter { set; }

        void SetAvalibleElementsForComboBoxes(List<List<string>> listsOfAvalibleElements);
        void SetAvalibleElementsForComboBoxes(List<string> listOfAvalibleElements, int comboBoxIndex);

        List<List<string>> GetListOfAvalibleElementsForComboBoxes();
        List<string> GetListOfAvalibleElementsForComboBoxes(int comboBoxIndex);

        int GetSelectedIndex(int numberOfComboBox);
        void SetSelectedIndex(int numberOfComboBoxm, int indexToSet);


    }
}
