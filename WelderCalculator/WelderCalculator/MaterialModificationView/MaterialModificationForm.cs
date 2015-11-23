using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WelderCalculator.MaterialModificationView
{
    public partial class MaterialModificationForm : Form, IMaterialModificationView
    {
        public MaterialModificationPresenter Presenter { private get; set; }

        public MaterialModificationForm(object norm)
        {
            InitializeComponent();
            new MaterialModificationPresenter(this, norm);
        }

        public MaterialModificationForm(object norm, object materialToBind)
        {
            InitializeComponent();
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
            set { cMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        

        public double? SiMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siMinTextBox);
                return textBoxValue;
            }
            set { siMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? MnMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnMinTextBox);
                return textBoxValue;
            }
            set { mnMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }

        }

        public double? PMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(pMinTextBox);
                return textBoxValue;
            }
            set { pMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? SMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(sMinTextBox);
                return textBoxValue;
            }
            set { sMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nMinTextBox);
                return textBoxValue;
            }
            set { nMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? CrMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crMinTextBox);
                return textBoxValue;
            }
            set { crMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? MoMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moMinTextBox);
                return textBoxValue;
            }
            set { moMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NbMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbMinTextBox);
                return textBoxValue;
            }
            set { nbMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NiMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niMinTextBox);
                return textBoxValue;
            }
            set { niMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? TiMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiMinTextBox);
                return textBoxValue;
            }
            set { tiMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? AlMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(alMinTextBox);
                return textBoxValue;
            }
            set { alMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? VMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(vMinTextBox);
                return textBoxValue;
            }
            set { vMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? CuMintextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuMinTextBox);
                return textBoxValue;
            }
            set { cuMinTextBox.Text = value.HasValue ? value.ToString() : string.Empty; }
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
            set { cMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? SiMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siMaxTextbox);
                return textBoxValue;
            }
            set { siMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? MnMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnMaxTextbox);
                return textBoxValue;
            }
            set { mnMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? PMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(pMaxTextbox);
                return textBoxValue;
            }
            set { pMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? SMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(sMaxTextbox);
                return textBoxValue;
            }
            set { sMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nMaxTextbox);
                return textBoxValue;
            }
            set { nMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? CrMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crMaxTextbox);
                return textBoxValue;
            }
            set { crMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? MoMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moMaxTextbox);
                return textBoxValue;
            }
            set { moMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NbMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbMaxTextbox);
                return textBoxValue;
            }
            set { nbMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NiMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niMaxTextbox);
                return textBoxValue;
            }
            set { niMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? TiMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiMaxTextbox);
                return textBoxValue;
            }
            set { tiMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? AlMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(alMaxTextbox);
                return textBoxValue;
            }
            set { alMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? VMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(vMaxTextbox);
                return textBoxValue;
            }
            set { vMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? CuMaxtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuMaxTextbox);
                return textBoxValue;
            }
            set { cuMaxTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
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
            set { cRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? SiRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(siRealTextbox);
                return textBoxValue;
            }
            set { siRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? MnRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(mnRealTextbox);
                return textBoxValue;
            }
            set { mnRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? PRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(pRealTextbox);
                return textBoxValue;
            }
            set { pRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? SRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(sRealTextbox);
                return textBoxValue;
            }
            set { sRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nRealTextbox);
                return textBoxValue;
            }
            set { nRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? CrRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(crRealTextbox);
                return textBoxValue;
            }
            set { crRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? MoRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(moRealTextbox);
                return textBoxValue;
            }
            set { moRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NbRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(nbRealTextbox);
                return textBoxValue;
            }
            set { nbRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? NiRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(niRealTextbox);
                return textBoxValue;
            }
            set { niRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? TiRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(tiRealTextbox);
                return textBoxValue;
            }
            set { tiRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? AlRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(alRealTextbox);
                return textBoxValue;
            }
            set { alRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? VRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(vRealTextbox);
                return textBoxValue;
            }
            set { vRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        }

        public double? CuRealtextbox
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(cuRealTextbox);
                return textBoxValue;
            }
            set { cuRealTextbox.Text = value.HasValue ? value.ToString() : string.Empty; }
        } 
        #endregion

        private double? GetTextBoxValue(TextBox textbox)
        {
            string text = textbox.Text.Trim();

            if (string.IsNullOrEmpty(text))
                return null;
            return Convert.ToDouble(text);
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
