using System.Security.AccessControl;

namespace WelderCalculator.Databases.AddMaterialDatabaseView
{
    partial class AddMaterialDatabaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.normComboBox = new System.Windows.Forms.ComboBox();
            this.normNameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.EqLayoutPanel = new System.Windows.Forms.GroupBox();
            this.niTextBox = new System.Windows.Forms.TextBox();
            this.crTextBox = new System.Windows.Forms.TextBox();
            this.crLabel = new System.Windows.Forms.Label();
            this.cTextBox = new System.Windows.Forms.TextBox();
            this.niLabel = new System.Windows.Forms.Label();
            this.cLabel = new System.Windows.Forms.Label();
            this.ViewLayoutPanel = new System.Windows.Forms.GroupBox();
            this.orderElementsButton = new System.Windows.Forms.Button();
            this.cuCheckBox = new System.Windows.Forms.CheckBox();
            this.tiCheckBox = new System.Windows.Forms.CheckBox();
            this.niCheckBox = new System.Windows.Forms.CheckBox();
            this.nbCheckBox = new System.Windows.Forms.CheckBox();
            this.nCheckBox = new System.Windows.Forms.CheckBox();
            this.mnCheckBox = new System.Windows.Forms.CheckBox();
            this.moCheckBox = new System.Windows.Forms.CheckBox();
            this.sCheckBox = new System.Windows.Forms.CheckBox();
            this.siCheckBox = new System.Windows.Forms.CheckBox();
            this.crCheckBox = new System.Windows.Forms.CheckBox();
            this.pCheckBox = new System.Windows.Forms.CheckBox();
            this.cCheckBox = new System.Windows.Forms.CheckBox();
            this.materialsDataGridView = new System.Windows.Forms.DataGridView();
            this.carbonLabel = new System.Windows.Forms.GroupBox();
            this.alloyTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.nominalContainmentNameCheckBox = new System.Windows.Forms.CheckBox();
            this.realCheckBox = new System.Windows.Forms.CheckBox();
            this.maxCheckBox = new System.Windows.Forms.CheckBox();
            this.minCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.EqLayoutPanel.SuspendLayout();
            this.ViewLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsDataGridView)).BeginInit();
            this.carbonLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // normComboBox
            // 
            this.normComboBox.FormattingEnabled = true;
            this.normComboBox.Location = new System.Drawing.Point(49, 87);
            this.normComboBox.Name = "normComboBox";
            this.normComboBox.Size = new System.Drawing.Size(140, 21);
            this.normComboBox.TabIndex = 0;
            // 
            // normNameLabel
            // 
            this.normNameLabel.AutoSize = true;
            this.normNameLabel.Location = new System.Drawing.Point(2, 90);
            this.normNameLabel.Name = "normNameLabel";
            this.normNameLabel.Size = new System.Drawing.Size(41, 13);
            this.normNameLabel.TabIndex = 1;
            this.normNameLabel.Text = "Norma:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Location = new System.Drawing.Point(198, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modyfikacja";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(18, 79);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(18, 21);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(18, 50);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Edytuj";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // EqLayoutPanel
            // 
            this.EqLayoutPanel.Controls.Add(this.niTextBox);
            this.EqLayoutPanel.Controls.Add(this.crTextBox);
            this.EqLayoutPanel.Controls.Add(this.crLabel);
            this.EqLayoutPanel.Controls.Add(this.cTextBox);
            this.EqLayoutPanel.Controls.Add(this.niLabel);
            this.EqLayoutPanel.Controls.Add(this.cLabel);
            this.EqLayoutPanel.Location = new System.Drawing.Point(302, 12);
            this.EqLayoutPanel.Name = "EqLayoutPanel";
            this.EqLayoutPanel.Size = new System.Drawing.Size(207, 108);
            this.EqLayoutPanel.TabIndex = 9;
            this.EqLayoutPanel.TabStop = false;
            this.EqLayoutPanel.Text = "Równoważniki";
            // 
            // niTextBox
            // 
            this.niTextBox.Location = new System.Drawing.Point(28, 75);
            this.niTextBox.Name = "niTextBox";
            this.niTextBox.Size = new System.Drawing.Size(172, 20);
            this.niTextBox.TabIndex = 4;
            // 
            // crTextBox
            // 
            this.crTextBox.Location = new System.Drawing.Point(28, 49);
            this.crTextBox.Name = "crTextBox";
            this.crTextBox.Size = new System.Drawing.Size(172, 20);
            this.crTextBox.TabIndex = 3;
            // 
            // crLabel
            // 
            this.crLabel.AutoSize = true;
            this.crLabel.Location = new System.Drawing.Point(3, 52);
            this.crLabel.Name = "crLabel";
            this.crLabel.Size = new System.Drawing.Size(20, 13);
            this.crLabel.TabIndex = 1;
            this.crLabel.Text = "Cr:";
            // 
            // cTextBox
            // 
            this.cTextBox.Location = new System.Drawing.Point(29, 23);
            this.cTextBox.Name = "cTextBox";
            this.cTextBox.Size = new System.Drawing.Size(172, 20);
            this.cTextBox.TabIndex = 2;
            // 
            // niLabel
            // 
            this.niLabel.AutoSize = true;
            this.niLabel.Location = new System.Drawing.Point(3, 78);
            this.niLabel.Name = "niLabel";
            this.niLabel.Size = new System.Drawing.Size(20, 13);
            this.niLabel.TabIndex = 2;
            this.niLabel.Text = "Ni:";
            // 
            // cLabel
            // 
            this.cLabel.AutoSize = true;
            this.cLabel.Location = new System.Drawing.Point(6, 26);
            this.cLabel.Name = "cLabel";
            this.cLabel.Size = new System.Drawing.Size(17, 13);
            this.cLabel.TabIndex = 0;
            this.cLabel.Text = "C:";
            // 
            // ViewLayoutPanel
            // 
            this.ViewLayoutPanel.Controls.Add(this.orderElementsButton);
            this.ViewLayoutPanel.Controls.Add(this.cuCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.tiCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.niCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.nbCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.nCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.mnCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.moCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.sCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.siCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.crCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.pCheckBox);
            this.ViewLayoutPanel.Controls.Add(this.cCheckBox);
            this.ViewLayoutPanel.Location = new System.Drawing.Point(516, 12);
            this.ViewLayoutPanel.Name = "ViewLayoutPanel";
            this.ViewLayoutPanel.Size = new System.Drawing.Size(350, 108);
            this.ViewLayoutPanel.TabIndex = 14;
            this.ViewLayoutPanel.TabStop = false;
            this.ViewLayoutPanel.Text = "Opcje wyświetlania";
            // 
            // orderElementsButton
            // 
            this.orderElementsButton.Location = new System.Drawing.Point(267, 79);
            this.orderElementsButton.Name = "orderElementsButton";
            this.orderElementsButton.Size = new System.Drawing.Size(75, 23);
            this.orderElementsButton.TabIndex = 17;
            this.orderElementsButton.Text = "Kolejność";
            this.orderElementsButton.UseVisualStyleBackColor = true;
            this.orderElementsButton.Click += new System.EventHandler(this.orderElementsButton_Click);
            // 
            // cuCheckBox
            // 
            this.cuCheckBox.AutoSize = true;
            this.cuCheckBox.Location = new System.Drawing.Point(169, 88);
            this.cuCheckBox.Name = "cuCheckBox";
            this.cuCheckBox.Size = new System.Drawing.Size(76, 17);
            this.cuCheckBox.TabIndex = 16;
            this.cuCheckBox.Text = "Miedź (Cu)";
            this.cuCheckBox.UseVisualStyleBackColor = true;
            this.cuCheckBox.CheckedChanged += new System.EventHandler(this.cuCheckBox_CheckedChanged);
            // 
            // tiCheckBox
            // 
            this.tiCheckBox.AutoSize = true;
            this.tiCheckBox.Location = new System.Drawing.Point(77, 86);
            this.tiCheckBox.Name = "tiCheckBox";
            this.tiCheckBox.Size = new System.Drawing.Size(71, 17);
            this.tiCheckBox.TabIndex = 13;
            this.tiCheckBox.Text = "Tytan (Ti)";
            this.tiCheckBox.UseVisualStyleBackColor = true;
            this.tiCheckBox.CheckedChanged += new System.EventHandler(this.tiCheckBox_CheckedChanged);
            // 
            // niCheckBox
            // 
            this.niCheckBox.AutoSize = true;
            this.niCheckBox.Location = new System.Drawing.Point(6, 86);
            this.niCheckBox.Name = "niCheckBox";
            this.niCheckBox.Size = new System.Drawing.Size(71, 17);
            this.niCheckBox.TabIndex = 14;
            this.niCheckBox.Text = "Nikiel (Ni)";
            this.niCheckBox.UseVisualStyleBackColor = true;
            this.niCheckBox.CheckedChanged += new System.EventHandler(this.niCheckBox_CheckedChanged);
            // 
            // nbCheckBox
            // 
            this.nbCheckBox.AutoSize = true;
            this.nbCheckBox.Location = new System.Drawing.Point(169, 65);
            this.nbCheckBox.Name = "nbCheckBox";
            this.nbCheckBox.Size = new System.Drawing.Size(71, 17);
            this.nbCheckBox.TabIndex = 8;
            this.nbCheckBox.Text = "Niob (Nb)";
            this.nbCheckBox.UseVisualStyleBackColor = true;
            this.nbCheckBox.CheckedChanged += new System.EventHandler(this.nbCheckBox_CheckedChanged);
            // 
            // nCheckBox
            // 
            this.nCheckBox.AutoSize = true;
            this.nCheckBox.Location = new System.Drawing.Point(169, 43);
            this.nCheckBox.Name = "nCheckBox";
            this.nCheckBox.Size = new System.Drawing.Size(64, 17);
            this.nCheckBox.TabIndex = 8;
            this.nCheckBox.Text = "Azot (N)";
            this.nCheckBox.UseVisualStyleBackColor = true;
            this.nCheckBox.CheckedChanged += new System.EventHandler(this.nCheckBox_CheckedChanged);
            // 
            // mnCheckBox
            // 
            this.mnCheckBox.AutoSize = true;
            this.mnCheckBox.Location = new System.Drawing.Point(169, 19);
            this.mnCheckBox.Name = "mnCheckBox";
            this.mnCheckBox.Size = new System.Drawing.Size(89, 17);
            this.mnCheckBox.TabIndex = 8;
            this.mnCheckBox.Text = "Mangan (Mn)";
            this.mnCheckBox.UseVisualStyleBackColor = true;
            this.mnCheckBox.CheckedChanged += new System.EventHandler(this.mnCheckBox_CheckedChanged);
            // 
            // moCheckBox
            // 
            this.moCheckBox.AutoSize = true;
            this.moCheckBox.Location = new System.Drawing.Point(77, 65);
            this.moCheckBox.Name = "moCheckBox";
            this.moCheckBox.Size = new System.Drawing.Size(93, 17);
            this.moCheckBox.TabIndex = 8;
            this.moCheckBox.Text = "Molibden (Mo)";
            this.moCheckBox.UseVisualStyleBackColor = true;
            this.moCheckBox.CheckedChanged += new System.EventHandler(this.moCheckBox_CheckedChanged);
            // 
            // sCheckBox
            // 
            this.sCheckBox.AutoSize = true;
            this.sCheckBox.Location = new System.Drawing.Point(77, 42);
            this.sCheckBox.Name = "sCheckBox";
            this.sCheckBox.Size = new System.Drawing.Size(72, 17);
            this.sCheckBox.TabIndex = 11;
            this.sCheckBox.Text = "Siarka (S)";
            this.sCheckBox.UseVisualStyleBackColor = true;
            this.sCheckBox.CheckedChanged += new System.EventHandler(this.sCheckBox_CheckedChanged);
            // 
            // siCheckBox
            // 
            this.siCheckBox.AutoSize = true;
            this.siCheckBox.Location = new System.Drawing.Point(77, 19);
            this.siCheckBox.Name = "siCheckBox";
            this.siCheckBox.Size = new System.Drawing.Size(73, 17);
            this.siCheckBox.TabIndex = 10;
            this.siCheckBox.Text = "Krzem (Si)";
            this.siCheckBox.UseVisualStyleBackColor = true;
            this.siCheckBox.CheckedChanged += new System.EventHandler(this.siCheckBox_CheckedChanged);
            // 
            // crCheckBox
            // 
            this.crCheckBox.AutoSize = true;
            this.crCheckBox.Location = new System.Drawing.Point(6, 65);
            this.crCheckBox.Name = "crCheckBox";
            this.crCheckBox.Size = new System.Drawing.Size(75, 17);
            this.crCheckBox.TabIndex = 9;
            this.crCheckBox.Text = "Chrom (Cr)";
            this.crCheckBox.UseVisualStyleBackColor = true;
            this.crCheckBox.CheckedChanged += new System.EventHandler(this.crCheckBox_CheckedChanged);
            // 
            // pCheckBox
            // 
            this.pCheckBox.AutoSize = true;
            this.pCheckBox.Location = new System.Drawing.Point(6, 42);
            this.pCheckBox.Name = "pCheckBox";
            this.pCheckBox.Size = new System.Drawing.Size(69, 17);
            this.pCheckBox.TabIndex = 8;
            this.pCheckBox.Text = "Potas (P)";
            this.pCheckBox.UseVisualStyleBackColor = true;
            this.pCheckBox.CheckedChanged += new System.EventHandler(this.pCheckBox_CheckedChanged);
            // 
            // cCheckBox
            // 
            this.cCheckBox.AutoSize = true;
            this.cCheckBox.Location = new System.Drawing.Point(6, 19);
            this.cCheckBox.Name = "cCheckBox";
            this.cCheckBox.Size = new System.Drawing.Size(75, 17);
            this.cCheckBox.TabIndex = 7;
            this.cCheckBox.Text = "Węgiel (C)";
            this.cCheckBox.UseVisualStyleBackColor = true;
            this.cCheckBox.CheckedChanged += new System.EventHandler(this.cCheckBox_CheckedChanged);
            // 
            // materialsDataGridView
            // 
            this.materialsDataGridView.AllowUserToAddRows = false;
            this.materialsDataGridView.AllowUserToDeleteRows = false;
            this.materialsDataGridView.AllowUserToResizeRows = false;
            this.materialsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialsDataGridView.Location = new System.Drawing.Point(35, 136);
            this.materialsDataGridView.MultiSelect = false;
            this.materialsDataGridView.Name = "materialsDataGridView";
            this.materialsDataGridView.ReadOnly = true;
            this.materialsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.materialsDataGridView.Size = new System.Drawing.Size(934, 252);
            this.materialsDataGridView.TabIndex = 15;
            // 
            // carbonLabel
            // 
            this.carbonLabel.CausesValidation = false;
            this.carbonLabel.Controls.Add(this.alloyTypeCheckBox);
            this.carbonLabel.Controls.Add(this.nominalContainmentNameCheckBox);
            this.carbonLabel.Controls.Add(this.realCheckBox);
            this.carbonLabel.Controls.Add(this.maxCheckBox);
            this.carbonLabel.Controls.Add(this.minCheckBox);
            this.carbonLabel.Location = new System.Drawing.Point(872, 17);
            this.carbonLabel.Name = "carbonLabel";
            this.carbonLabel.Size = new System.Drawing.Size(97, 103);
            this.carbonLabel.TabIndex = 16;
            this.carbonLabel.TabStop = false;
            this.carbonLabel.Text = "Wyświetlaj";
            // 
            // alloyTypeCheckBox
            // 
            this.alloyTypeCheckBox.AutoSize = true;
            this.alloyTypeCheckBox.Location = new System.Drawing.Point(6, 83);
            this.alloyTypeCheckBox.Name = "alloyTypeCheckBox";
            this.alloyTypeCheckBox.Size = new System.Drawing.Size(73, 17);
            this.alloyTypeCheckBox.TabIndex = 6;
            this.alloyTypeCheckBox.Text = "Typ stopu";
            this.alloyTypeCheckBox.UseVisualStyleBackColor = true;
            this.alloyTypeCheckBox.CheckedChanged += new System.EventHandler(this.alloyTypeCheckBox_CheckedChanged);
            // 
            // nominalContainmentNameCheckBox
            // 
            this.nominalContainmentNameCheckBox.AutoSize = true;
            this.nominalContainmentNameCheckBox.Location = new System.Drawing.Point(6, 63);
            this.nominalContainmentNameCheckBox.Name = "nominalContainmentNameCheckBox";
            this.nominalContainmentNameCheckBox.Size = new System.Drawing.Size(81, 17);
            this.nominalContainmentNameCheckBox.TabIndex = 5;
            this.nominalContainmentNameCheckBox.Text = "Skład nom.";
            this.nominalContainmentNameCheckBox.UseVisualStyleBackColor = true;
            this.nominalContainmentNameCheckBox.CheckedChanged += new System.EventHandler(this.nominalContainmentNameCheckBox_CheckedChanged);
            // 
            // realCheckBox
            // 
            this.realCheckBox.AutoSize = true;
            this.realCheckBox.Location = new System.Drawing.Point(6, 40);
            this.realCheckBox.Name = "realCheckBox";
            this.realCheckBox.Size = new System.Drawing.Size(48, 17);
            this.realCheckBox.TabIndex = 4;
            this.realCheckBox.Text = "Real";
            this.realCheckBox.UseVisualStyleBackColor = true;
            this.realCheckBox.CheckedChanged += new System.EventHandler(this.realCheckBox_CheckedChanged);
            // 
            // maxCheckBox
            // 
            this.maxCheckBox.AutoSize = true;
            this.maxCheckBox.Location = new System.Drawing.Point(45, 18);
            this.maxCheckBox.Name = "maxCheckBox";
            this.maxCheckBox.Size = new System.Drawing.Size(46, 17);
            this.maxCheckBox.TabIndex = 3;
            this.maxCheckBox.Text = "Max";
            this.maxCheckBox.UseVisualStyleBackColor = true;
            this.maxCheckBox.CheckedChanged += new System.EventHandler(this.maxCheckBox_CheckedChanged);
            // 
            // minCheckBox
            // 
            this.minCheckBox.AutoSize = true;
            this.minCheckBox.Location = new System.Drawing.Point(6, 18);
            this.minCheckBox.Name = "minCheckBox";
            this.minCheckBox.Size = new System.Drawing.Size(43, 17);
            this.minCheckBox.TabIndex = 2;
            this.minCheckBox.Text = "Min";
            this.minCheckBox.UseVisualStyleBackColor = true;
            this.minCheckBox.CheckedChanged += new System.EventHandler(this.minCheckBox_CheckedChanged);
            // 
            // AddMaterialDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 400);
            this.Controls.Add(this.carbonLabel);
            this.Controls.Add(this.materialsDataGridView);
            this.Controls.Add(this.ViewLayoutPanel);
            this.Controls.Add(this.EqLayoutPanel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.normNameLabel);
            this.Controls.Add(this.normComboBox);
            this.Name = "AddMaterialDatabaseForm";
            this.Text = "Materiał dodatkowy";
            this.groupBox1.ResumeLayout(false);
            this.EqLayoutPanel.ResumeLayout(false);
            this.EqLayoutPanel.PerformLayout();
            this.ViewLayoutPanel.ResumeLayout(false);
            this.ViewLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsDataGridView)).EndInit();
            this.carbonLabel.ResumeLayout(false);
            this.carbonLabel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox normComboBox;
        private System.Windows.Forms.Label normNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox EqLayoutPanel;
        private System.Windows.Forms.TextBox niTextBox;
        private System.Windows.Forms.TextBox crTextBox;
        private System.Windows.Forms.Label crLabel;
        private System.Windows.Forms.TextBox cTextBox;
        private System.Windows.Forms.Label niLabel;
        private System.Windows.Forms.Label cLabel;
        private System.Windows.Forms.GroupBox ViewLayoutPanel;
        private System.Windows.Forms.Button orderElementsButton;
        private System.Windows.Forms.CheckBox cuCheckBox;
        private System.Windows.Forms.CheckBox tiCheckBox;
        private System.Windows.Forms.CheckBox niCheckBox;
        private System.Windows.Forms.CheckBox nbCheckBox;
        private System.Windows.Forms.CheckBox nCheckBox;
        private System.Windows.Forms.CheckBox mnCheckBox;
        private System.Windows.Forms.CheckBox moCheckBox;
        private System.Windows.Forms.CheckBox sCheckBox;
        private System.Windows.Forms.CheckBox siCheckBox;
        private System.Windows.Forms.CheckBox crCheckBox;
        private System.Windows.Forms.CheckBox pCheckBox;
        private System.Windows.Forms.CheckBox cCheckBox;
        private System.Windows.Forms.DataGridView materialsDataGridView;
        private System.Windows.Forms.GroupBox carbonLabel;
        private System.Windows.Forms.CheckBox realCheckBox;
        private System.Windows.Forms.CheckBox maxCheckBox;
        private System.Windows.Forms.CheckBox minCheckBox;
        private System.Windows.Forms.CheckBox alloyTypeCheckBox;
        private System.Windows.Forms.CheckBox nominalContainmentNameCheckBox;
    }
}