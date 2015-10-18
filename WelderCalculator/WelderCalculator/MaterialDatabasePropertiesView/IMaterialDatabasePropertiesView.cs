using System.Collections.Generic;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public interface IMaterialDatabasePropertiesView
    {
        MaterialDatabasePropertiesPresenter Presenter { set; }

        #region ElementLists & SelectedElementLists
        List<string> ElementsList1st { get; set; }
        int SelectedElement1st { get; set; }
        List<string> ElementsList2nd { get; set; }
        int SelectedElement2nd { get; set; }
        List<string> ElementsList3rd { get; set; }
        int SelectedElement3rd { get; set; }
        List<string> ElementsList4th { get; set; }
        int SelectedElement4th { get; set; }
        List<string> ElementsList5th { get; set; }
        int SelectedElement5th { get; set; }
        List<string> ElementsList6th { get; set; }
        int SelectedElement6th { get; set; }
        List<string> ElementsList7th { get; set; }
        int SelectedElement7th { get; set; }
        List<string> ElementsList8th { get; set; }
        int SelectedElement8th { get; set; }
        List<string> ElementsList9th { get; set; }
        int SelectedElement9th { get; set; }
        List<string> ElementsList10th { get; set; }
        int SelectedElement10th { get; set; }
        List<string> ElementsList11th { get; set; }
        int SelectedElement11th { get; set; }
        List<string> ElementsList12th { get; set; }
        int SelectedElement12th { get; set; }
        List<string> ElementsList13th { get; set; }
        int SelectedElement13th { get; set; }
        List<string> ElementsList14th { get; set; }
        int SelectedElement14th { get; set; }
        #endregion
    }
}
