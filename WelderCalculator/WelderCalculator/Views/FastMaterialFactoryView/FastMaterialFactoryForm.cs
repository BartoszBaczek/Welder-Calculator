﻿using System;
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

        #region textBoxes
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

        public double? TiBaseMaterial1
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiBaseMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref tiBaseMaterialTextBox, value); }
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

        public double? TiBaseMaterial2
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiBaseMaterial2TextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref tiBaseMaterial2TextBox, value); }
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

        public double? TiAddMaterial
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiAddMaterialTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref tiAddMaterialTextBox, value); }
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
    }
}
