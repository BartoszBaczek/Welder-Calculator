using System;
using System.Windows.Forms;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialModificationView
{
    public partial class MaterialModificationForm : Form, IMaterialModificationView
    {
        public MaterialModificationPresenter Presenter { private get; set; }

        public MaterialModificationForm()
        {
            InitializeComponent();
            new MaterialModificationPresenter(this);
        }

        public MaterialModificationForm(Material materialToBind)
        {
            InitializeComponent();
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


        public double? CMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.cMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.cMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SiMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.siMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.siMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MnMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.mnMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.mnMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
            
        }

        public double? PMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.pMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.pMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.sMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.sMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NMintextbox
        {
           get
            {
                string cEquivalentTextBox = this.nMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.nMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.crMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.crMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MoMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.moMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.moMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NbMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.nbMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.nbMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.niMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.niMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? TiMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.tiMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.tiMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? AlMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.alMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.alMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? VMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.vMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.vMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CuMintextbox
        {
            get
            {
                string cEquivalentTextBox = this.cuMinTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.cuMinTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.cMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.cMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SiMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.siMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.siMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MnMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.mnMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.mnMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? PMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.pMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.pMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.sMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.sMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.cMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.nMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.crMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.crMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MoMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.moMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.moMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NbMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.nbMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.nbMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.niMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.niMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? TiMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.tiMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.tiMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? AlMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.alMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.alMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? VMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.vMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.vMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CuMaxtextbox
        {
            get
            {
                string cEquivalentTextBox = this.cuMaxTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.cuMaxTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.cRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.cRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SiRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.siRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.siRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MnRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.mnRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.mnRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? PRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.pRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.pRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? SRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.sRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.sRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.nRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.nRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.crRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.crRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? MoRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.moRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.moRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NbRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.nbRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.nbRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.niRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.niRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? TiRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.tiRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.tiRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? AlRealtextbox
        {
           get
            {
                string cEquivalentTextBox = this.alRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.alRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? VRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.vRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.vRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CuRealtextbox
        {
            get
            {
                string cEquivalentTextBox = this.cuRealTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.cuRealTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }
    }
}
