using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WelderCalculator.Views.AddMaterialDatabaseView.AddMaterialDatabasePresenters;

namespace WelderCalculator.Views.AddMaterialDatabaseView
{
    public partial class AddMaterialDatabaseForm : Form, IAdditiveMaterialView
    {
        public AddMaterialDatabasePresenter Presenter { private get; set; }
        public AdditiveMaterialDatabaseAccesibility Accesibility { get; private set; }

        public AddMaterialDatabaseForm(AdditiveMaterialDatabaseAccesibility accesibility)
        {
            Accesibility = accesibility;
            InitializeComponent();

            if (Accesibility == AdditiveMaterialDatabaseAccesibility.Full)
                Presenter = new FullAccesAddMaterialDatabasePresenter(this);
            else
                Presenter = new PartialAccesAddMaterialPresenter(this);

                Presenter.Init();
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

        public bool VCheckBox
        {
            get { return vCheckBox.Checked; }
            set { vCheckBox.Checked = value; }
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


        #region ElementCheckBoxes
        private void cCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("C");
        }
        private void pCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("P");
        }
        private void crCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Cr");
        }
        private void niCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Ni");
        }
        private void siCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Si");
        }
        private void sCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("S");
        }
        private void moCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Mo");
        }
        private void tiCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Ti");
        }
        private void mnCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Mn");
        }
        private void nCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("N");
        }
        private void nbCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Nb");
        }
        private void cuCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("Cu");
        }
        private void vCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnMaterialCheckBoxChanged("V");
        }
        #endregion

        private void numberCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged("Numer");
        }

        private void minCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged("min");
        }

        private void maxCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged("max");
        }

        private void realCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            Presenter.OnViewOptionsCheckBoxChanged("real");
        }

        private void orderElementsButton_Click(object sender, EventArgs e)
        {
            Presenter.OnElementsOrderPropertiesButtonClicked();
            Presenter.Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Presenter.OnAddMaterialButtonClicked();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Presenter.OnEditMaterialButtonClicked();
        }

        private void addNewNormButton_Click(object sender, EventArgs e)
        {
            Presenter.OnAddNormButtonClicked();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Presenter.OnDeleteMaterialButtonClicked();
        }

        private void normComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }

        private void materialsDataGridView_SelectedRowChanged(object sender, EventArgs e)
        {
            Presenter.OnSelectedDataGridViewRowChanged();
        }

        private void deleteNormButton_Click(object sender, EventArgs e)
        {
            Presenter.OnDeleteNormButtonClicked();
            //Trzeba dodac potwierdzenie usunia normy - za duzo do stracenia
        }

        private void chooseMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnChooseMaterialButtonClicked();
        }

        public bool ChooseMaterialVisibityButton
        {
            get { return chooseMaterialButton.Visible; }
            set { chooseMaterialButton.Visible = value; }
        }

        public bool ModifyMaterialVisibilityLayoutPanel
        {
            get { return modifyMaterialControlPanel.Visible; }
            set { modifyMaterialControlPanel.Visible = value; }
        }

        public bool AddNormVisibilityButton
        {
            get { return addNewNormButton.Visible; }
            set { addNewNormButton.Visible = value; }
        }

        public bool DeleteNormVisibilityButton
        {
            get { return deleteNormButton.Visible; }
            set { deleteNormButton.Visible = value; }
        }
    }
}
