using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Serialization;

namespace WelderCalculator.MaterialDatabaseView
{
    public partial class MaterialDatabaseForm : Form, IMaterialDatabaseView
    {
        public MaterialDatabasePresenter Presenter { private get; set; }

        public MaterialDatabaseForm()
        {
            InitializeComponent();
            var repository = new Repository();
            new MaterialDatabasePresenter(this, repository);
            Presenter.Init();
        }

        public List<string> NormsList
        {
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

        public bool AlCheckBox
        {
            get { return this.alCheckBox.Checked; }
            set { this.alCheckBox.Checked = value; }
        }

        public bool VCheckBox
        {
            get { return this.vCheckBox.Checked; }
            set { this.vCheckBox.Checked = value; }
        }

        public bool CuCheckBox
        {
            get { return this.cuCheckBox.Checked; }
            set { this.cuCheckBox.Checked = value; }
        }

        public bool NumberCheckBox
        {
            get { return this.numberCheckBox.Checked; }
            set { this.numberCheckBox.Checked = value; }
        }

        public bool MinCheckBox
        {
            get { return this.minCheckBox.Checked; }
            set { this.numberCheckBox.Checked = value; }
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

        #region DataGridView
        public DataTable GridSource
        {
            set { this.materialsDataGridView.DataSource = value; }
        }

        public DataGridView DataGridView
        {
            get { return this.materialsDataGridView; }
        }
        #endregion

        /*Event handling*/
        private void normComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }

        #region Material checkboxes checks changed
        private void cCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void pCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void crCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void niCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void siCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void sCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void moCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void tiCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void mnCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void nCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void nbCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void alCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void cuCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        private void vCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged();
        }
        #endregion

        private void numberCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged();
        }

        private void minCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged();
        }

        private void maxCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged();
        }

        private void realCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged();
        }

        private void orderElementsButton_Click(object sender, System.EventArgs e)
        {
            Presenter.OpenMaterialOrderPropertiesWindow();
        }
     }
}
