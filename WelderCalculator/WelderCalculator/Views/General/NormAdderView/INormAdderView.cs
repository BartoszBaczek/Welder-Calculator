using WelderCalculator.Views.General.MaterialDatabasePropertiesView;

namespace WelderCalculator.Views.General.NormAdderView
{
    public interface INormAdderView
    {
        NormAdderPresenter Presenter { set; }

        MaterialType MaterialType { get; }

        string NormName { get; set; }

        void CloseDialog();
    }
}
