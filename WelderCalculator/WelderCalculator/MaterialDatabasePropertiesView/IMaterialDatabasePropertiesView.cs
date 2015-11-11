using System.Collections.Generic;

namespace WelderCalculator.MaterialDatabasePropertiesView
{

    public interface IMaterialDatabasePropertiesView
    {
        MaterialDatabasePropertiesPresenter Presenter { set; }

        int NumberOfComboBoxes { get; }

        void SetDataSourcesForComboBoxes(List<List<string>> listsOfDataSources);
        void SetDataSourcesForComboBoxes(int comboBoxIndex, List<string> listOfAvalibleElements);

        List<List<string>> GetListOfAvalibleElementsForComboBoxes();
        List<string> GetListOfAvalibleElementsForComboBoxes(int comboBoxIndex);

        int GetSelectedIndex(int numberOfComboBox);
        void SetSelectedIndex(int numberOfComboBox, int indexToSet);


    }
}
