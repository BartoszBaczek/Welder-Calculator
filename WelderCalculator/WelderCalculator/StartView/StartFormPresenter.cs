using System.Windows.Forms;
using WelderCalculator.Databases.AddMaterialDatabaseView;
using WelderCalculator.Drawings.SchaefflerChartView;
using WelderCalculator.MaterialDatabaseView;

namespace WelderCalculator.StartView
{
    public class StartFormPresenter
    {
        private readonly IStartFormView _view;

        public StartFormPresenter(IStartFormView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public void ExitProgram()
        {
            Application.Exit();
        }

        public void OpenMaterialDatabase()
        {
            var materialDatabaseForm = new MaterialDatabaseForm();
            materialDatabaseForm.ShowDialog();
        }

        public void OpenSchaefflerChart()
        {
            var schaefflerChartFOrm = new SchaefflerChartForm();
            schaefflerChartFOrm.ShowDialog();
        }

        public void OpenAdditiveMaterialDatabase()
        {
            var additiveMaterialDatabaseForm = new AddMaterialDatabaseForm();
            additiveMaterialDatabaseForm.ShowDialog();
        }
    }
}
