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

        public double? Ctextbox
        {
            get
            {
                string text = cTextbox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double) Convert.ChangeType(text, typeof (double));
            }
            set { cTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? Sitextbox
        {
            get
            {
                string text = siTextBox.Text;

                if (string.IsNullOrEmpty(text))
                    return null;
                return
                    (double)Convert.ChangeType(text, typeof(double));
            }
            set { siTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Mntextbox
        {
            get
            {
                string cEquivalentTextBox = mnTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { mnTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Ptextbox
        {
            get
            {
                string cEquivalentTextBox = pTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { pTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Stextbox
        {
            get
            {
                string cEquivalentTextBox = sTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { sTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Ntextbox
        {
            get
            {
                string cEquivalentTextBox = nTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { nTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Crtextbox
        {
            get
            {
                string cEquivalentTextBox = crTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { crTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Motextbox
        {
            get
            {
                string cEquivalentTextBox = moTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { moTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Nbtextbox
        {
            get
            {
                string cEquivalentTextBox = nbTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { nbTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Nitextbox
        {
            get
            {
                string cEquivalentTextBox = niTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { niTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Titextbox
        {
            get
            {
                string cEquivalentTextBox = tiTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { tiTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Altextbox
        {
            get
            {
                string cEquivalentTextBox = alTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { alTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Vtextbox
        {
            get
            {
                string cEquivalentTextBox = vTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { vTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }

        public double? Cutextbox
        {
            get
            {
                string cEquivalentTextBox = cuTextbox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { cuTextbox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        
        }
    }
}
