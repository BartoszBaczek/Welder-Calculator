using System;
using System.Windows.Forms;

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

        private void wykresSchaeffleraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Presenter.OpenSchaefflerChart();
            Show();
        }

        private void helpStrip_Click(object sender, EventArgs e)
        {
        }

        private void additionalMaterialBaseStrip_Click(object sender, EventArgs e)
        {
            Hide();
            Presenter.OpenAdditiveMaterialDatabase();
            Show();
        }
    }
}
