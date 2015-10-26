using System.Collections.Generic;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabasePropertiesView
{

    public interface IMaterialDatabasePropertiesView
    {
        MaterialDatabasePropertiesPresenter Presenter { set; }

        List<FormComboBox> ElementsComboBoxes { get; set; }

        void ApplyChangesInComboBoxes();
    }
}
