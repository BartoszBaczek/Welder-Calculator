using System;
using System.Windows.Forms;

namespace WelderCalculator.MaterialModificationView
{
    public partial class MaterialModificationForm : Form, IMaterialModificationView
    {
        public MaterialModificationPresenter Presenter { private get; set; }
        private readonly WindowMode.Mode _workingMode;

        public MaterialModificationForm()
        {
            InitializeComponent();
            _workingMode = WindowMode.Mode.AddNew;
            new MaterialModificationPresenter(this);
        }

        public MaterialModificationForm(object materialToBind)
        {
            InitializeComponent();
            _workingMode = WindowMode.Mode.Modify;
            new MaterialModificationPresenter(this, materialToBind);
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


        #region Mins
        public double? CMintextbox
        {
            get
            {
                string text = cMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { cMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SiMintextbox
        {
            get
            {
                string text = siMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { siMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MnMintextbox
        {
            get
            {
                string text = mnMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { mnMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }

        }

        public double? PMintextbox
        {
            get
            {
                string text = pMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { pMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SMintextbox
        {
            get
            {
                string text = sMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { sMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NMintextbox
        {
            get
            {
                string text = nMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { nMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrMintextbox
        {
            get
            {
                string text = crMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { crMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MoMintextbox
        {
            get
            {
                string text = moMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { moMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NbMintextbox
        {
            get
            {
                string text = nbMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { nbMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiMintextbox
        {
            get
            {
                string text = niMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { niMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? TiMintextbox
        {
            get
            {
                string text = tiMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { tiMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? AlMintextbox
        {
            get
            {
                string text = alMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { alMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? VMintextbox
        {
            get
            {
                string text = vMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { vMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CuMintextbox
        {
            get
            {
                string text = cuMinTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { cuMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        } 
        #endregion
        #region Maxs
        public double? CMaxtextbox
        {
            get
            {
                string text = cMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { cMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SiMaxtextbox
        {
            get
            {
                string text = siMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { siMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MnMaxtextbox
        {
            get
            {
                string text = mnMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { mnMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? PMaxtextbox
        {
            get
            {
                string text = pMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { pMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SMaxtextbox
        {
            get
            {
                string text = sMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { sMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NMaxtextbox
        {
            get
            {
                string text = cMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { nMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrMaxtextbox
        {
            get
            {
                string text = crMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { crMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MoMaxtextbox
        {
            get
            {
                string text = moMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { moMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NbMaxtextbox
        {
            get
            {
                string text = nbMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { nbMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiMaxtextbox
        {
            get
            {
                string text = niMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { niMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? TiMaxtextbox
        {
            get
            {
                string text = tiMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { tiMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? AlMaxtextbox
        {
            get
            {
                string text = alMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { alMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? VMaxtextbox
        {
            get
            {
                string text = vMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { vMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CuMaxtextbox
        {
            get
            {
                string text = cuMaxTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { cuMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        } 
        #endregion
        #region Reals
        public double? CRealtextbox
        {
            get
            {
                string text = cRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { cRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SiRealtextbox
        {
            get
            {
                string text = siRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { siRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MnRealtextbox
        {
            get
            {
                string text = mnRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { mnRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? PRealtextbox
        {
            get
            {
                string text = pRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { pRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SRealtextbox
        {
            get
            {
                string text = sRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { sRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NRealtextbox
        {
            get
            {
                string text = nRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { nRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrRealtextbox
        {
            get
            {
                string text = crRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { crRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MoRealtextbox
        {
            get
            {
                string text = moRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { moRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NbRealtextbox
        {
            get
            {
                string text = nbRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { nbRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiRealtextbox
        {
            get
            {
                string text = niRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { niRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? TiRealtextbox
        {
            get
            {
                string text = tiRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { tiRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? AlRealtextbox
        {
            get
            {
                string text = alRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { alRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? VRealtextbox
        {
            get
            {
                string text = vRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { vRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CuRealtextbox
        {
            get
            {
                string text = cuRealTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { cuRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        } 
        #endregion
    }
}
