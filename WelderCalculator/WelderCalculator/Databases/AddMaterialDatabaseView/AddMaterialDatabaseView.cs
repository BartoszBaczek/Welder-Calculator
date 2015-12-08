using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WelderCalculator.MaterialDatabaseView;

namespace WelderCalculator.Databases.AddMaterialDatabaseView
{
    public partial class AddMaterialDatabaseForm : Form, IAdditiveMaterialView
    {
        public AddMaterialDatabasePresenter Presenter { private get; set; }

        public AddMaterialDatabaseForm()
        {
            InitializeComponent();
            new AddMaterialDatabasePresenter(this);
        }

        public List<string> NormsList
        {
            get { return this.normComboBox.DataSource as List<string>; }
            set { this.normComboBox.DataSource = value; }
        }

        public int SelectedNorm
        {
            get { return this.normComboBox.SelectedIndex; }
            set { this.normComboBox.SelectedIndex = value; }
        }

        #region Checkboxes
        public bool CcheckBox
        {
            get { return this.cCheckBox.Checked; }
            set { this.cCheckBox.Checked = value; }
        }

        public bool SiCheckBox
        {
            get { return this.siCheckBox.Checked; }
            set { this.siCheckBox.Checked = value; }
        }

        public bool MnCheckBox
        {
            get { return this.mnCheckBox.Checked; }
            set { this.mnCheckBox.Checked = value; }
        }

        public bool PcheckBox
        {
            get { return this.pCheckBox.Checked; }
            set { this.pCheckBox.Checked = value; }
        }

        public bool ScheckBox
        {
            get { return this.sCheckBox.Checked; }
            set { this.sCheckBox.Checked = value; }
        }

        public bool NcheckBox
        {
            get { return this.nCheckBox.Checked; }
            set { this.nCheckBox.Checked = value; }
        }

        public bool CrCheckBox
        {
            get { return this.crCheckBox.Checked; }
            set { this.crCheckBox.Checked = value; }
        }

        public bool MoCheckBox
        {
            get { return this.moCheckBox.Checked; }
            set { this.moCheckBox.Checked = value; }
        }

        public bool NbCheckBox
        {
            get { return this.nbCheckBox.Checked; }
            set { this.nbCheckBox.Checked = value; }
        }

        public bool NiCheckBox
        {
            get { return this.niCheckBox.Checked; }
            set { this.niCheckBox.Checked = value; }
        }

        public bool TiCheckBox
        {
            get { return this.tiCheckBox.Checked; }
            set { this.tiCheckBox.Checked = value; }
        }

        public bool CuCheckBox
        {
            get { return this.cuCheckBox.Checked; }
            set { this.cuCheckBox.Checked = value; }
        }

        public bool NominalContainmentNameCheckBox
        {
            get { return this.nominalContainmentNameCheckBox.Checked; }
            set { this.nominalContainmentNameCheckBox.Checked = value; }
        }
        public bool AlloyTypeNameCheckBox
        {
            get { return alloyTypeCheckBox.Checked; }
            set { alloyTypeCheckBox.Checked = value; }
        }

        public bool MinCheckBox
        {
            get { return this.minCheckBox.Checked; }
            set { this.minCheckBox.Checked = value; }
        }

        public bool MaxCheckBox
        {
            get { return this.maxCheckBox.Checked; }
            set { this.maxCheckBox.Checked = value; }
        }

        public bool RealCheckBox
        {
            get { return this.realCheckBox.Checked; }
            set { this.realCheckBox.Checked = value; }
        }
        #endregion

        public DataTable GridSource
        {
            set { this.materialsDataGridView.DataSource = value; }
        }

        public DataGridView DataGridView
        {
            get { return this.materialsDataGridView; }
        }

        public DataGridViewRow SelectedRow
        {
            get
            {
                if (this.materialsDataGridView.SelectedRows.Count >= 1)
                    return materialsDataGridView.SelectedRows[0];
                else return new DataGridViewRow();
            }
        }

        public double? CEquivalentTextBox
        {
            get
            {
                string cEquivalentTextBox = this.cTextBox.Text;

                if (string.IsNullOrEmpty(cEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(cEquivalentTextBox, typeof(double));
            }
            set { this.cTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? NiEquivalentTextBox
        {
            get
            {
                string nNiEquivalentTextBox = this.niTextBox.Text;

                if (string.IsNullOrEmpty(nNiEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(nNiEquivalentTextBox, typeof(double));
            }
            set { this.niTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }

        public double? CrEquivalentTextBox
        {
            get
            {
                string crEquivalentTextBox = this.niTextBox.Text;

                if (string.IsNullOrEmpty(crEquivalentTextBox))
                    return null;
                return
                    (double)Convert.ChangeType(crEquivalentTextBox, typeof(double));
            }
            set { this.crTextBox.Text = value.HasValue ? value.ToString() : "Brak danych"; }
        }
    }
}
