using System;
using System.Windows.Forms;
using WelderCalculator.Views.General.MaterialDatabasePropertiesView;

namespace WelderCalculator.Views.General.MaterialModificationView
{
    public partial class MaterialModificationForm : Form, IMaterialModificationView
    {
        public MaterialModificationPresenter Presenter { private get; set; }

        public MaterialType MaterialType { private set; get; }

        public MaterialModificationForm(object norm, MaterialType materialType)
        {
            InitializeComponent();
            MaterialType = materialType;
            if (materialType == MaterialType.AdditionalMaterial)
            {
                numberLabel.Visible = false;
                numberTextBox.Visible = false;
                guidLayoutPanel.Location = numberLabel.Location;
                guidTextBox.Location = numberTextBox.Location;
                alLayoutPanel.Visible = false;
                vLayoutPanel.Location = alLayoutPanel.Location;
            }
            new MaterialModificationPresenter(this, norm);
        }

        public MaterialModificationForm(object norm, object materialToBind, MaterialType materialType)
        {
            InitializeComponent();
            MaterialType = materialType;
            if (materialType == MaterialType.AdditionalMaterial)
            {
                numberLabel.Visible = false;
                numberTextBox.Visible = false;
                guidLayoutPanel.Location = numberLabel.Location;
                guidTextBox.Location = numberTextBox.Location;
                alLayoutPanel.Visible = false;
                vLayoutPanel.Location = alLayoutPanel.Location;
            }
            new MaterialModificationPresenter(this, norm, materialToBind);
        }

        #region Generals
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
        #endregion
        #region Mins
        public double? CMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cMinTextBox, value);}
        }

        public double? SiMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref siMinTextBox, value); }
        }

        public double? MnMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref mnMinTextBox, value); }

        }

        public double? PMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(pMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref pMinTextBox, value); }
        }

        public double? SMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(sMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref sMinTextBox, value); }
        }

        public double? NMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nMinTextBox, value); }
        }

        public double? CrMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref crMinTextBox, value); }
        }

        public double? MoMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref moMinTextBox, value); }
        }

        public double? NbMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nbMinTextBox, value); }
        }

        public double? NiMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref niMinTextBox, value); }
        }

        public double? TiMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref tiMinTextBox, value); }
        }

        public double? AlMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(alMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref alMinTextBox, value); }
        }

        public double? VMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(vMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref vMinTextBox, value); }
        }

        public double? CuMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuMinTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cuMinTextBox, value); }
        } 
        #endregion
        #region Maxs
        public double? CMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cMaxTextbox, value); }
        }

        public double? SiMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref siMaxTextbox, value); }
        }

        public double? MnMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref mnMaxTextbox, value); }
        }

        public double? PMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(pMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref pMaxTextbox, value); }
        }

        public double? SMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(sMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref sMaxTextbox, value); }
        }

        public double? NMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nMaxTextbox, value); }
        }

        public double? CrMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref crMaxTextbox, value); }
        }

        public double? MoMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref moMaxTextbox, value); }
        }

        public double? NbMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nbMaxTextbox, value); }
        }

        public double? NiMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref niMaxTextbox, value); }
        }

        public double? TiMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref tiMaxTextbox, value); }
        }

        public double? AlMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(alMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref alMaxTextbox, value); }
        }

        public double? VMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(vMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref vMaxTextbox, value); }
        }

        public double? CuMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuMaxTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cuMaxTextbox, value); }
        } 
        #endregion
        #region Reals
        public double? CRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cRealTextbox, value); }
        }

        public double? SiRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref siRealTextbox, value); }
        }

        public double? MnRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref mnRealTextbox, value); }
        }

        public double? PRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(pRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref pRealTextbox, value); }
        }

        public double? SRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(sRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref sRealTextbox, value); }
        }

        public double? NRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nRealTextbox, value); }
        }

        public double? CrRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref crRealTextbox, value); }
        }

        public double? MoRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref moRealTextbox, value); }
        }

        public double? NbRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref nbRealTextbox, value); }
        }

        public double? NiRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref niRealTextbox, value); }
        }

        public double? TiRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref tiRealTextbox, value); }
        }

        public double? AlRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(alRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref alRealTextbox, value); }
        }

        public double? VRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(vRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref vRealTextbox, value); }
        }

        public double? CuRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuRealTextbox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref cuRealTextbox, value); }
        } 
        #endregion

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
                MessageBox.Show("Wartosć wpisana w polu " + textbox.Name + " nie jest liczbą");
                return null;
            }
        }

        private void SetTextboxValue(ref TextBox textbox, double? value)
        {
            textbox.Text = value.HasValue ? value.ToString() : string.Empty;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Presenter.OnApplyButtonClicked();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Presenter.OnCancelButtonClicked();
        }

        public void CancelDialog()
        {
            this.Close();
        }
    }
}
