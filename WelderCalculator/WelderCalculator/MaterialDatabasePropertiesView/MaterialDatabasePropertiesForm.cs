using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Schema;
using WelderCalculator.MaterialDatabasePropertiesView.Serialization;

namespace WelderCalculator.MaterialDatabasePropertiesView
{
    public partial class MaterialDatabasePropertiesForm : Form, IMaterialDatabasePropertiesView
    {
        public MaterialDatabasePropertiesPresenter Presenter { private get; set; }

        public MaterialDatabasePropertiesForm()
        {
            InitializeComponent();
            var repository = new ElementsOrderPropertiesRepository();
            new MaterialDatabasePropertiesPresenter(this, repository);
            Presenter.Init();
        }

        #region ComboBoxes
        public List<string> ElementsList1st
        {
            set { this.comboBox1st.DataSource = value;  }
        }
        public int SelectedElement1st
        {
            get { return this.comboBox1st.SelectedIndex; }
            set { this.comboBox1st.SelectedIndex = value; }
        }

        public List<string> ElementsList2nd
        {
            set { this.comboBox2nd.DataSource = value; }
        }
        public int SelectedElement2nd
        {
            get { return this.comboBox2nd.SelectedIndex; }
            set { this.comboBox2nd.SelectedIndex = value; }
        }

        public List<string> ElementsList3rd
        {
            set { this.comboBox3rd.DataSource = value; }
        }
        public int SelectedElement3rd
        {
            get { return this.comboBox3rd.SelectedIndex; }
            set { this.comboBox3rd.SelectedIndex = value; }
        }

        public List<string> ElementsList4th
        {
            set { this.comboBox4th.DataSource = value; }
        }
        public int SelectedElement4th
        {
            get { return this.comboBox4th.SelectedIndex; }
            set { this.comboBox4th.SelectedIndex = value; }
        }

        public List<string> ElementsList5th
        {
            set { this.comboBox5th.DataSource = value; }
        }
        public int SelectedElement5th
        {
            get { return this.comboBox5th.SelectedIndex; }
            set { this.comboBox5th.SelectedIndex = value; }
        }

        public List<string> ElementsList6th
        {
            set { this.comboBox6th.DataSource = value;  }
        }
        public int SelectedElement6th
        {
            get { return this.comboBox6th.SelectedIndex; }
            set { this.comboBox6th.SelectedIndex = value; }
        }

        public List<string> ElementsList7th
        {
            set { this.comboBox7th.DataSource = value;  }
        }
        public int SelectedElement7th
        {
            get { return this.comboBox7th.SelectedIndex; }
            set { this.comboBox7th.SelectedIndex = value; }
        }

        public List<string> ElementsList8th
        {
            set { this.comboBox8th.DataSource = value; }
        }
        public int SelectedElement8th
        {
            get { return this.comboBox8th.SelectedIndex; }
            set { this.comboBox8th.SelectedIndex = value; }
        }

        public List<string> ElementsList9th
        {
            set { this.comboBox9th.DataSource = value; }
        }
        public int SelectedElement9th
        {
            get { return this.comboBox9th.SelectedIndex; }
            set { this.comboBox9th.SelectedIndex = value; }
        }

        public List<string> ElementsList10th
        {
            set { this.comboBox10th.DataSource = value; }
        }
        public int SelectedElement10th
        {
            get { return this.comboBox10th.SelectedIndex; }
            set { this.comboBox10th.SelectedIndex = value; }
        }

        public List<string> ElementsList11th
        {
            set { this.comboBox11th.DataSource = value; }
        }
        public int SelectedElement11th
        {
            get { return this.comboBox11th.SelectedIndex; }
            set { this.comboBox11th.SelectedIndex = value; }
        }

        public List<string> ElementsList12th
        {
            set { this.comboBox12th.DataSource = value; }
        }
        public int SelectedElement12th
        {
            get { return this.comboBox12th.SelectedIndex; }
            set { this.comboBox12th.SelectedIndex = value; }
        }

        public List<string> ElementsList13th
        {
            set { this.comboBox13th.DataSource = value;  }
        }
        public int SelectedElement13th
        {
            get { return this.comboBox13th.SelectedIndex; }
            set { this.comboBox13th.SelectedIndex = value; }
        }

        public List<string> ElementsList14th
        {
            set { this.comboBox14th.DataSource = value;  }
        }
        public int SelectedElement14th
        {
            get { return this.comboBox14th.SelectedIndex; }
            set { this.comboBox14th.SelectedIndex = value; }
        }
        #endregion

    }
}
