using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public partial class MaterialDatabasePropertiesForm : Form, IMaterialDatabasePropertiesView
    {

        public MaterialDatabasePropertiesPresenter Presenter { private get; set; }

        private const int NUMBER_OF_COMBOBOXES_IN_FORM = 14;

        public MaterialDatabasePropertiesForm()
        {
            InitializeComponent();

            new MaterialDatabasePropertiesPresenter(this, new ElementsOrderPropertiesRepository());
        }

        #region DataSourcesForComboBoxes
        public void SetAvalibleElementsForComboBoxes(List<List<string>> listsOfAvalibleElements)
        {
            if (listsOfAvalibleElements.Count != NUMBER_OF_COMBOBOXES_IN_FORM)
                throw new InvalidOperationException("Number of elements in listOfAvalibleElements must be the same as number of comboBoxes");

            for (int i = 0; i < listsOfAvalibleElements.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        comboBox1st.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 1:
                        comboBox2nd.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 2:
                        comboBox3rd.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 3:
                        comboBox4th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 4:
                        comboBox5th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 5:
                        comboBox6th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 6:
                        comboBox7th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 7:
                        comboBox8th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 8:
                        comboBox9th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 9:
                        comboBox10th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 10:
                        comboBox11th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 11:
                        comboBox12th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 12:
                        comboBox13th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                    case 13:
                        comboBox14th.DataSource = listsOfAvalibleElements[i].ToList();
                        break;
                }
            }
        }

        public void SetAvalibleElementsForComboBoxes(List<string> listOfAvalibleElements, int comboBoxIndex)
        {
            if (comboBoxIndex < 1 || comboBoxIndex > NUMBER_OF_COMBOBOXES_IN_FORM)
                throw new ArgumentException("There is no comboBox with that number");

            switch (comboBoxIndex)
            {
                case 1:
                    comboBox1st.DataSource = listOfAvalibleElements;
                    break;
                case 2:
                    comboBox2nd.DataSource = listOfAvalibleElements;
                    break;
                case 3:
                    comboBox3rd.DataSource = listOfAvalibleElements;
                    break;
                case 4:
                    comboBox4th.DataSource = listOfAvalibleElements;
                    break;
                case 5:
                    comboBox5th.DataSource = listOfAvalibleElements;
                    break;
                case 6:
                    comboBox6th.DataSource = listOfAvalibleElements;
                    break;
                case 7:
                    comboBox7th.DataSource = listOfAvalibleElements;
                    break;
                case 8:
                    comboBox8th.DataSource = listOfAvalibleElements;
                    break;
                case 9:
                    comboBox9th.DataSource = listOfAvalibleElements;
                    break;
                case 10:
                    comboBox10th.DataSource = listOfAvalibleElements;
                    break;
                case 11:
                    comboBox11th.DataSource = listOfAvalibleElements;
                    break;
                case 12:
                    comboBox12th.DataSource = listOfAvalibleElements;
                    break;
                case 13:
                    comboBox13th.DataSource = listOfAvalibleElements;
                    break;
                case 14:
                    comboBox14th.DataSource = listOfAvalibleElements;
                    break;
            }
        }

        public List<List<string>> GetListOfAvalibleElementsForComboBoxes()
        {
            return new List<List<string>>()
            {
                comboBox1st.DataSource as List<string>,
                comboBox2nd.DataSource as List<string>,
                comboBox3rd.DataSource as List<string>,
                comboBox4th.DataSource as List<string>,
                comboBox5th.DataSource as List<string>,
                comboBox6th.DataSource as List<string>,
                comboBox7th.DataSource as List<string>,
                comboBox8th.DataSource as List<string>,
                comboBox9th.DataSource as List<string>,
                comboBox10th.DataSource as List<string>,
                comboBox11th.DataSource as List<string>,
                comboBox12th.DataSource as List<string>,
                comboBox13th.DataSource as List<string>,
                comboBox14th.DataSource as List<string>,
            };
        }

        public List<string> GetListOfAvalibleElementsForComboBoxes(int comboBoxIndex)
        {
            if (comboBoxIndex < 1 || comboBoxIndex > NUMBER_OF_COMBOBOXES_IN_FORM)
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
            if (numberOfComboBox < 1 || numberOfComboBox > NUMBER_OF_COMBOBOXES_IN_FORM)
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
            if (numberOfComboBox < 1 || numberOfComboBox > NUMBER_OF_COMBOBOXES_IN_FORM)
                throw new ArgumentException("There is no comboBox with that number");
            
            switch (numberOfComboBox)
            {
                case 1:
                    if (comboBox1st.DataSource == null)
                        throw new ArgumentException("BindDataSource to ComboBox at first");
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
        
        private void applyOrderButton_Click(object sender, EventArgs e)
        {
            Presenter.DoTest();
        }
    }
}

