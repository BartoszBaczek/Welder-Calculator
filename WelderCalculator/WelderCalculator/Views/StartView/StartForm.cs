using System;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.PDFUtilities;
using WelderCalculator.Repositories;

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

        private void paintEvent(object sender, PaintEventArgs e)
        {
            DataConnector a = new DataConnector();
            Image newImage = a.GetKsLogo();
            e.Graphics.DrawImage(newImage, new PointF(0, 30));
        }

        private void baseMaterialsDatabaseButton_Click(object sender, EventArgs e)
        {
            Presenter.OnBaseMaterialDatabaseButtonClick();
        }

        private void addMaterialDatabaseButton_Click(object sender, EventArgs e)
        {
            Presenter.OnAddMaterialDatabaseButtonClick();
        }

        private void schaefflerCountingButton_Click(object sender, EventArgs e)
        {
            Presenter.OnScahefflerCountingButtonClicked();
        }

        private void deLongCountingButton_Click(object sender, EventArgs e)
        {
            Presenter.OnDeLongCountingButtonClicked();
        }
    }
}
