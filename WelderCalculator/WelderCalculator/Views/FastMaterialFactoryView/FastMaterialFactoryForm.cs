using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WelderCalculator.Views.FastMaterialFactoryView
{
    public partial class FastMaterialFactoryForm : Form, IFastMaterialFactoryView
    {
        public FastMaterialFactoryPresenter Presenter { private get; set; }

        public FastMaterialFactoryForm()
        {
            InitializeComponent();
            Presenter = new FastMaterialFactoryPresenter(this);

            ChangeBaseMaterial1Checked = true;
            ChangeBaseMaterial2Checked = true;
            ChangeAdditionalMaterialChecked = true;
        }

        private double? GetTextBoxValue(TextBox textbox)
        {
            try
            {
                string text = textbox.Text.Trim().Replace('.', ',');
                if (string.IsNullOrEmpty(text))
                    return null;
                return Convert.ToDouble(text);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        private void SetTextboxValue(ref TextBox textbox, double? value)
        {
            textbox.Text = value.HasValue ? value.ToString() : string.Empty;
        }

        #region Equivalents

        public List<string> EquivalentsList
        {
            get { return equivalentTypeComboBox.DataSource as List<string>; }
            set { equivalentTypeComboBox.DataSource = value; }
        }

        public int SelectedEquivalent
        {
            get { return equivalentTypeComboBox.SelectedIndex; }
            set { equivalentTypeComboBox.SelectedIndex = value; }
        }

        public double? CrEqBaseMaterial1TextBox
        {
            get
            {
                string crEquivalentTextBox = this.crEqBaseMaterial1TextBox.Text;

                if (string.IsNullOrEmpty(crEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(crEquivalentTextBox, typeof(double));
            }
            set { crEqBaseMaterial1TextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrEqBaseMaterial2TextBox
        {
            get
            {
                string crEquivalentTextBox = this.crEqBaseMaterial2TextBox.Text;

                if (string.IsNullOrEmpty(crEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(crEquivalentTextBox, typeof(double));
            }
            set { crEqBaseMaterial2TextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrEqAddMaterialTextBox
        {
            get
            {
                string crEquivalentTextBox = this.crEqAddMaterialTextBox.Text;

                if (string.IsNullOrEmpty(crEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(crEquivalentTextBox, typeof(double));
            }
            set { crEqAddMaterialTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiEqBaseMaterial1TextBox
        {
            get
            {
                string crEquivalentTextBox = this.niEqBaseMaterial1TextBox.Text;

                if (string.IsNullOrEmpty(crEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(crEquivalentTextBox, typeof(double));
            }
            set { niEqBaseMaterial1TextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiEqBaseMaterial2TextBox
        {
            get
            {
                string crEquivalentTextBox = this.niEqBaseMaterial2TextBox.Text;

                if (string.IsNullOrEmpty(crEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(crEquivalentTextBox, typeof(double));
            }
            set { niEqBaseMaterial2TextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiEqAddMaterialTextBox
        {
            get
            {
                string crEquivalentTextBox = this.niEqAddMaterialTextBox.Text;

                if (string.IsNullOrEmpty(crEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(crEquivalentTextBox, typeof(double));
            }
            set { niEqAddMaterialTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        #endregion

        #region TextBoxes
        public double? NiBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref niBaseMaterialTextBox, value); }
        }

        public double? CrBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref crBaseMaterialTextBox, value); }
        }

        public double? CBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cBaseMaterialTextBox, value); }
        }

        public double? MnBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref mnBaseMaterialTextBox, value); }
        }

        public double? MoBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref moBaseMaterialTextBox, value); }
        }

        public double? NBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nBaseMaterialTextBox, value); }
        }

        public double? SiBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref siBaseMaterialTextBox, value); }
        }

        public double? NbBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nbBaseMaterialTextBox, value); }
        }

        public double? CuBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cuBaseMaterialTextBox, value); }
        }

        public double? NiBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref niBaseMaterial2TextBox, value); }
        }

        public double? CrBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref crBaseMaterial2TextBox, value); }
        }

        public double? CBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cBaseMaterial2TextBox, value); }
        }

        public double? MnBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref mnBaseMaterial2TextBox, value); }
        }

        public double? MoBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref moBaseMaterial2TextBox, value); }
        }

        public double? NBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nBaseMaterial2TextBox, value); }
        }

        public double? SiBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref siBaseMaterial2TextBox, value); }
        }

        public double? NbBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nbBaseMaterial2TextBox, value); }
        }

        public double? CuBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cuBaseMaterial2TextBox, value); }
        }

        public double? NiAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref niAddMaterialTextBox, value); }
        }

        public double? CrAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref crAddMaterialTextBox, value); }
        }

        public double? CAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cAddMaterialTextBox, value); }
        }

        public double? MnAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref mnAddMaterialTextBox, value); }
        }

        public double? MoAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref moAddMaterialTextBox, value); }
        }

        public double? NAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nAddMaterialTextBox, value); }
        }

        public double? SiAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref siAddMaterialTextBox, value); }
        }

        public double? NbAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nbAddMaterialTextBox, value); }
        }

        public double? CuAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cuAddMaterialTextBox, value); }
        }

        public bool ChangeBaseMaterial1Checked
        {
            get { return baseMaterial1ChangeCheckBox.Checked; }
            set {  baseMaterial1ChangeCheckBox.Checked = value; }
        }

        public bool ChangeBaseMaterial2Checked
        {
            get { return baseMaterial2ChangeCheckBox.Checked;  }
            set { baseMaterial2ChangeCheckBox.Checked = value; }
        }

        public bool ChangeAdditionalMaterialChecked
        {
            get {  return addMaterialChangeCheckBox.Checked; }
            set { addMaterialChangeCheckBox.Checked = value; }
        }

        #endregion

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Presenter.OnApplyButtonClicked();
            this.Close();
        }

        private void baseMaterial1ChangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            baseMaterial1GroupBox.Enabled = ChangeBaseMaterial1Checked;
        }

        private void baseMaterial2ChangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            baseMaterial2GroupBox.Enabled = ChangeBaseMaterial2Checked;
        }

        private void addMaterialChangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            addMaterialGroupBox.Enabled = ChangeAdditionalMaterialChecked;
        }

        private void equivalentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.OnEquivalentSelectedIndexChanged();
        }
    }
}
