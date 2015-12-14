using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public enum MaterialType
    {
        AdditionalMaterial,
        BaseMaterial
    };

    public partial class MaterialDatabasePropertiesForm : Form, IMaterialDatabasePropertiesView
    {
        public MaterialDatabasePropertiesPresenter Presenter { private get; set; }

        public MaterialType MaterialType { get; private set; }

        public int NumberOfComboBoxes { get { return MaterialType == MaterialType.BaseMaterial ? 14 : 12; } }


        public MaterialDatabasePropertiesForm(MaterialType materialType)
        {
            MaterialType = materialType;
            InitializeComponent();
            new MaterialDatabasePropertiesPresenter(this);
            if (MaterialType == MaterialType.AdditionalMaterial)
            {
                label10.Visible = false;    //change name to label 13
                label11.Visible = false;    //change name to label 14
                comboBox13th.Visible = false;
                comboBox14th.Visible = false;
            }
        }

        #region DataSourcesForComboBoxes
        public void SetDataSourcesForComboBoxes(int comboBoxIndex, List<string> listOfAvalibleElements)
        {
            if (comboBoxIndex < 1 || comboBoxIndex > NumberOfComboBoxes)
                throw new ArgumentException("There is no comboBox with that number");

            switch (comboBoxIndex)
            {
                case 1:
                    comboBox1st.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 2:
                    comboBox2nd.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 3:
                    comboBox3rd.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 4:
                    comboBox4th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 5:
                    comboBox5th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 6:
                    comboBox6th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 7:
                    comboBox7th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 8:
                    comboBox8th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 9:
                    comboBox9th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 10:
                    comboBox10th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 11:
                    comboBox11th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 12:
                    comboBox12th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 13:
                    comboBox13th.DataSource = listOfAvalibleElements.ToList();
                    break;
                case 14:
                    comboBox14th.DataSource = listOfAvalibleElements.ToList();
                    break;
                default:
                    throw new ArgumentException("There is no comboBox with requested number");
            }
        }

        public List<string> GetListOfAvalibleElementsForComboBoxes(int comboBoxIndex)
        {
            if (comboBoxIndex < 1 || comboBoxIndex > NumberOfComboBoxes)
                throw new ArgumentException("There is no combo box with that number");

            switch (comboBoxIndex)
            {
                case 1:
                    return comboBox1st.DataSource as List<string>;
                case 2:
                    return comboBox2nd.DataSource as List<string>;
                case 3:
                    return comboBox3rd.DataSource as List<string>;
                case 4:
                    return comboBox4th.DataSource as List<string>;
                case 5:
                    return comboBox5th.DataSource as List<string>;
                case 6:
                    return comboBox6th.DataSource as List<string>;
                case 7:
                    return comboBox7th.DataSource as List<string>;
                case 8:
                    return comboBox8th.DataSource as List<string>;
                case 9:
                    return comboBox9th.DataSource as List<string>;
                case 10:
                    return comboBox10th.DataSource as List<string>;
                case 11:
                    return comboBox11th.DataSource as List<string>;
                case 12:
                    return comboBox12th.DataSource as List<string>;
                case 13:
                    return comboBox13th.DataSource as List<string>;
                case 14:
                    return comboBox14th.DataSource as List<string>;
                default:
                    throw new Exception("Cos sie zjebalo");
            }
        }
        #endregion

        #region SelectedIndexesForComboBoxes
        public int GetSelectedIndex(int numberOfComboBox)
        {
            if (numberOfComboBox < 1 || numberOfComboBox > NumberOfComboBoxes)
                throw new ArgumentException("Number of comboBox is out of range");
            switch (numberOfComboBox)
            {
                case 1:
                    return comboBox1st.SelectedIndex;
                case 2:
                    return comboBox2nd.SelectedIndex;
                case 3:
                    return comboBox3rd.SelectedIndex;
                case 4:
                    return comboBox4th.SelectedIndex;
                case 5:
                    return comboBox5th.SelectedIndex;
                case 6:
                    return comboBox6th.SelectedIndex;
                case 7:
                    return comboBox7th.SelectedIndex;
                case 8:
                    return comboBox8th.SelectedIndex;
                case 9:
                    return comboBox9th.SelectedIndex;
                case 10:
                    return comboBox10th.SelectedIndex;
                case 11:
                    return comboBox11th.SelectedIndex;
                case 12:
                    return comboBox12th.SelectedIndex;
                case 13:
                    return comboBox13th.SelectedIndex;
                case 14:
                    return comboBox14th.SelectedIndex;
                default:
                    throw new Exception("Cos sie zjebalo");
            }
        }

        public void SetSelectedIndex(int numberOfComboBox, int indexToSet)
        {
            if (numberOfComboBox < 1 || numberOfComboBox > NumberOfComboBoxes)
                throw new ArgumentException("There is no comboBox with that number");

            switch (numberOfComboBox)
            {
                case 1:
                    comboBox1st.SelectedIndex = indexToSet;
                    break;
                case 2:
                    comboBox2nd.SelectedIndex = indexToSet;
                    break;
                case 3:
                    comboBox3rd.SelectedIndex = indexToSet;
                    break;
                case 4:
                    comboBox4th.SelectedIndex = indexToSet;
                    break;
                case 5:
                    comboBox5th.SelectedIndex = indexToSet;
                    break;
                case 6:
                    comboBox6th.SelectedIndex = indexToSet;
                    break;
                case 7:
                    comboBox7th.SelectedIndex = indexToSet;
                    break;
                case 8:
                    comboBox8th.SelectedIndex = indexToSet;
                    break;
                case 9:
                    comboBox9th.SelectedIndex = indexToSet;
                    break;
                case 10:
                    comboBox10th.SelectedIndex = indexToSet;
                    break;
                case 11:
                    comboBox11th.SelectedIndex = indexToSet;
                    break;
                case 12:
                    comboBox12th.SelectedIndex = indexToSet;
                    break;
                case 13:
                    comboBox13th.SelectedIndex = indexToSet;
                    break;
                case 14:
                    comboBox14th.SelectedIndex = indexToSet;
                    break;
            }
        }
        #endregion

        #region OnSelectedIndexChanged

        private void comboBox1st_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox2nd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox3rd_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox4th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox5th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox6th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox7th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox8th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox9th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox10th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox11th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox12th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox13th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        private void comboBox14th_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Presenter.OnSelectedIndexChanged();
        }
        #endregion

        private void applyOrderButton_Click(object sender, EventArgs e)
        {
            Presenter.OnApplyButtonPressed();
        }

        private void cancelOrderButton_Click(object sender, EventArgs e)
        {
            Presenter.OnCancelButtonPressed();
        }

        public void CloseDialog()
        {
            this.Close();
        }
    }
}

