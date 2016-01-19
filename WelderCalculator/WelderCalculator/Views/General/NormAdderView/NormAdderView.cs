using System;
using System.Windows.Forms;
using WelderCalculator.Views.General.MaterialDatabasePropertiesView;

namespace WelderCalculator.Views.General.NormAdderView
{
    public partial class NormAdderView : Form, INormAdderView
    {
        public NormAdderPresenter Presenter { private get; set; }

        public MaterialType MaterialType { private set; get; }

        public NormAdderView(MaterialType materialType)
        {
            MaterialType = materialType;
            InitializeComponent();
            new NormAdderPresenter(this);
        }

        public string NormName
        {
            get { return normNameTextBox.Text; }
            set { normNameTextBox.Text = value; }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Presenter.OnOkButtonClicked();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Presenter.OnCancelButtonClicked();
        }

        public void CloseDialog()
        {
            this.Close();
        }
    }
}
