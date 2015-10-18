using System.Collections.Generic;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public interface IMaterialDatabasePropertiesView
    {
        MaterialDatabasePropertiesPresenter Presenter { set; }

        #region ElementLists & SelectedElementLists
        List<string> ElementsList1st { set; }
        int SelectedElement1st { get; set; }

        List<string> ElementsList2nd { set; }
        int SelectedElement2nd { get; set; }

        List<string> ElementsList3rd { set; }
        int SelectedElement3rd { get; set; }

        List<string> ElementsList4th { set; }
        int SelectedElement4th { get; set; }

        List<string> ElementsList5th { set; }
        int SelectedElement5th { get; set; }

        List<string> ElementsList6th { set; }
        int SelectedElement6th { get; set; }

        List<string> ElementsList7th { set; }
        int SelectedElement7th { get; set; }

        List<string> ElementsList8th { set; }
        int SelectedElement8th { get; set; }

        List<string> ElementsList9th { set; }
        int SelectedElement9th { get; set; }

        List<string> ElementsList10th { set; }
        int SelectedElement10th { get; set; }

        List<string> ElementsList11th { set; }
        int SelectedElement11th { get; set; }

        List<string> ElementsList12th { set; }
        int SelectedElement12th { get; set; }

        List<string> ElementsList13th { set; }
        int SelectedElement13th { get; set; }

        List<string> ElementsList14th { set; }
        int SelectedElement14th { get; set; }
        #endregion
    }
}
