﻿using System.Windows.Forms;
using WelderCalculator.Views.AddMaterialDatabaseView;
using WelderCalculator.Views.MaterialDatabaseView;
using WelderCalculator.Views.SchaefflerChartView;

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
            var materialDatabaseForm = new MaterialDatabaseForm(BaseMaterialDatabaseAccesibility.Full);
            materialDatabaseForm.ShowDialog();
        }

        public void OpenSchaefflerChart()
        {
            var schaefflerChartFOrm = new SchaefflerChartForm();
            schaefflerChartFOrm.ShowDialog();
        }

        public void OpenAdditiveMaterialDatabase()
        {
            var additiveMaterialDatabaseForm = new AddMaterialDatabaseForm(AdditiveMaterialDatabaseAccesibility.Full);
            additiveMaterialDatabaseForm.ShowDialog();
        }
    }
}
