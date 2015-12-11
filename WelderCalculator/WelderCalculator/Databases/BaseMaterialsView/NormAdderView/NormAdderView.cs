using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WelderCalculator.Databases.BaseMaterialsView
{
    public partial class NormAdderView : Form, INormAdderView
    {
        public NormAdderPresenter Presenter { private get; set; }

        public NormAdderView()
        {
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
