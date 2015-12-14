using System.Collections.Generic;

namespace WelderCalculator.MaterialDatabasePropertiesView
{

    public interface IMaterialDatabasePropertiesView
    {
        MaterialType MaterialType { get; }
        MaterialDatabasePropertiesPresenter Presenter { set; }

        int NumberOfComboBoxes { get; }

        void SetDataSourcesForComboBoxes(int comboBoxIndex, List<string> listOfAvalibleElements);
        List<string> GetListOfAvalibleElementsForComboBoxes(int comboBoxIndex);

        int GetSelectedIndex(int numberOfComboBox);
        void SetSelectedIndex(int numberOfComboBox, int indexToSet);

        void CloseDialog();
    }
}
