using System;
using System.Windows.Forms;

namespace WelderCalculator.MaterialModificationView
{
    public partial class MaterialModificationForm : Form, IMaterialModificationView
    {
        public MaterialModificationPresenter Presenter { private get; set; }

        public MaterialModificationForm()
        {
            InitializeComponent();
            new MaterialModificationPresenter();
        }

        public string NameTextbox
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        public string NumberTextbox
        {
            get { return numberTextBox.Text; }
            set { numberTextBox.Text = value; }
        }

        public string GuidTextbox
        {
            get { return guidTextBox.Text; }
            set { guidTextBox.Text = value; }
        }
    }
}
