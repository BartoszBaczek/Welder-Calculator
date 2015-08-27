using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WelderCalculator.Model;
using WelderCalculator.Serialization;

namespace WelderCalculator.StartView
{
    public partial class StartForm : Form, IStartFormView
    {
        public StartFormPresenter Presenter { private get; set; }

        public StartForm()
        {
            InitializeComponent();
            new StartFormPresenter(this);
        }

        private void exitStrip_Click(object sender, EventArgs e)
        {
            Presenter.ExitProgram();
        }

        private void materialBaseStrip_Click(object sender, EventArgs e)
        {
            Hide();
            Presenter.OpenMaterialDatabase();
            Show();
        }

        private void helpStrip_Click(object sender, EventArgs e)
        {
        }
    }
}
