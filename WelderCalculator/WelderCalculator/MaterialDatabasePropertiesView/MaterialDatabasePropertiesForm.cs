using System.Collections.Generic;
using System.Windows.Forms;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;
using WelderCalculator.Model;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public partial class MaterialDatabasePropertiesForm : Form, IMaterialDatabasePropertiesView
    {
        public MaterialDatabasePropertiesPresenter Presenter { private get; set; }

        private List<ComboBox> _comboBoxes;
        private List<FormComboBox> _tempComboBoxes; 

        public MaterialDatabasePropertiesForm()
        {
            InitializeComponent();

            _comboBoxes = new List<ComboBox>()
            {
                comboBox1st, comboBox2nd, comboBox3rd, comboBox4th,
                comboBox5th, comboBox6th, comboBox7th, comboBox8th,
                comboBox9th, comboBox10th, comboBox11th, comboBox12th,
                comboBox13th, comboBox14th
            };
            _tempComboBoxes = new List<FormComboBox>()
            {
                new FormComboBox(comboBox1st.DataSource as List<string>, comboBox1st.SelectedIndex),
                new FormComboBox(comboBox2nd.DataSource as List<string>, comboBox2nd.SelectedIndex),
                new FormComboBox(comboBox3rd.DataSource as List<string>, comboBox3rd.SelectedIndex),
                new FormComboBox(comboBox4th.DataSource as List<string>, comboBox4th.SelectedIndex),
                new FormComboBox(comboBox5th.DataSource as List<string>, comboBox5th.SelectedIndex),
                new FormComboBox(comboBox6th.DataSource as List<string>, comboBox6th.SelectedIndex),
                new FormComboBox(comboBox7th.DataSource as List<string>, comboBox7th.SelectedIndex),
                new FormComboBox(comboBox8th.DataSource as List<string>, comboBox8th.SelectedIndex),
                new FormComboBox(comboBox9th.DataSource as List<string>, comboBox9th.SelectedIndex),
                new FormComboBox(comboBox10th.DataSource as List<string>, comboBox10th.SelectedIndex),
                new FormComboBox(comboBox11th.DataSource as List<string>, comboBox11th.SelectedIndex),
                new FormComboBox(comboBox12th.DataSource as List<string>, comboBox12th.SelectedIndex),
                new FormComboBox(comboBox13th.DataSource as List<string>, comboBox13th.SelectedIndex),
                new FormComboBox(comboBox14th.DataSource as List<string>, comboBox14th.SelectedIndex),
            };

            var repository = new ElementsOrderPropertiesRepository();
            new MaterialDatabasePropertiesPresenter(this, repository);
        }



        public List<FormComboBox> ElementsComboBoxes
        {
            get { return _tempComboBoxes; }
            set { _tempComboBoxes = value; }
        }

        public void ApplyChangesInComboBoxes()
        {
            for (int i = 0; i < _comboBoxes.Count; i++)
            {
                _comboBoxes[i].DataSource = _tempComboBoxes[i].AvalibleElements;
                _comboBoxes[i].SelectedIndex = _tempComboBoxes[i].CurrentIndex;
            }
        }

        private List<FormComboBox> CurrentComboBoxes()
        {
            return new List<FormComboBox>()
                {
                    new FormComboBox(comboBox1st.DataSource as List<string>, comboBox1st.SelectedIndex),
                    new FormComboBox(comboBox2nd.DataSource as List<string>, comboBox2nd.SelectedIndex),
                    new FormComboBox(comboBox3rd.DataSource as List<string>, comboBox3rd.SelectedIndex),
                    new FormComboBox(comboBox4th.DataSource as List<string>, comboBox4th.SelectedIndex),
                    new FormComboBox(comboBox5th.DataSource as List<string>, comboBox5th.SelectedIndex),
                    new FormComboBox(comboBox6th.DataSource as List<string>, comboBox6th.SelectedIndex),
                    new FormComboBox(comboBox7th.DataSource as List<string>, comboBox7th.SelectedIndex),
                    new FormComboBox(comboBox8th.DataSource as List<string>, comboBox8th.SelectedIndex),
                    new FormComboBox(comboBox9th.DataSource as List<string>, comboBox9th.SelectedIndex),
                    new FormComboBox(comboBox10th.DataSource as List<string>, comboBox10th.SelectedIndex),
                    new FormComboBox(comboBox11th.DataSource as List<string>, comboBox11th.SelectedIndex),
                    new FormComboBox(comboBox12th.DataSource as List<string>, comboBox12th.SelectedIndex),
                    new FormComboBox(comboBox13th.DataSource as List<string>, comboBox13th.SelectedIndex),
                    new FormComboBox(comboBox14th.DataSource as List<string>, comboBox14th.SelectedIndex)
                };
        }

    }
}
