﻿namespace WelderCalculator.MaterialDatabaseView
{
    partial class MaterialDatabaseForm
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
            this.ViewLayoutPanel = new System.Windows.Forms.GroupBox();
            this.alCheckBox = new System.Windows.Forms.CheckBox();
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
            this.DataModifLayoutPanel = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.normLabel = new System.Windows.Forms.Label();
            this.normComboBox = new System.Windows.Forms.ComboBox();
            this.EqLayoutPanel = new System.Windows.Forms.GroupBox();
            this.niTextBox = new System.Windows.Forms.TextBox();
            this.crTextBox = new System.Windows.Forms.TextBox();
            this.crLabel = new System.Windows.Forms.Label();
            this.cTextBox = new System.Windows.Forms.TextBox();
            this.niLabel = new System.Windows.Forms.Label();
            this.cLabel = new System.Windows.Forms.Label();
            this.materialsDataGridView = new System.Windows.Forms.DataGridView();
            this.ViewLayoutPanel.SuspendLayout();
            this.DataModifLayoutPanel.SuspendLayout();
            this.EqLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewLayoutPanel
            // 
            this.ViewLayoutPanel.Controls.Add(this.alCheckBox);
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
            this.ViewLayoutPanel.Size = new System.Drawing.Size(260, 108);
            this.ViewLayoutPanel.TabIndex = 13;
            this.ViewLayoutPanel.TabStop = false;
            this.ViewLayoutPanel.Text = "Opcje wyświetlania";
            // 
            // alCheckBox
            // 
            this.alCheckBox.AutoSize = true;
            this.alCheckBox.Location = new System.Drawing.Point(169, 86);
            this.alCheckBox.Name = "alCheckBox";
            this.alCheckBox.Size = new System.Drawing.Size(91, 17);
            this.alCheckBox.TabIndex = 12;
            this.alCheckBox.Text = "Aluminium (Al)";
            this.alCheckBox.UseVisualStyleBackColor = true;
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
            // 
            // nbCheckBox
            // 
            this.nbCheckBox.AutoSize = true;
            this.nbCheckBox.Location = new System.Drawing.Point(169, 65);
            this.nbCheckBox.Name = "nbCheckBox";
            this.nbCheckBox.Size = new System.Drawing.Size(40, 17);
            this.nbCheckBox.TabIndex = 8;
            this.nbCheckBox.Text = "Nb";
            this.nbCheckBox.UseVisualStyleBackColor = true;
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
            // 
            // mnCheckBox
            // 
            this.mnCheckBox.AutoSize = true;
            this.mnCheckBox.Location = new System.Drawing.Point(167, 20);
            this.mnCheckBox.Name = "mnCheckBox";
            this.mnCheckBox.Size = new System.Drawing.Size(89, 17);
            this.mnCheckBox.TabIndex = 8;
            this.mnCheckBox.Text = "Mangan (Mn)";
            this.mnCheckBox.UseVisualStyleBackColor = true;
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
            // 
            // DataModifLayoutPanel
            // 
            this.DataModifLayoutPanel.Controls.Add(this.deleteButton);
            this.DataModifLayoutPanel.Controls.Add(this.editButton);
            this.DataModifLayoutPanel.Controls.Add(this.addButton);
            this.DataModifLayoutPanel.Location = new System.Drawing.Point(198, 12);
            this.DataModifLayoutPanel.Name = "DataModifLayoutPanel";
            this.DataModifLayoutPanel.Size = new System.Drawing.Size(99, 108);
            this.DataModifLayoutPanel.TabIndex = 11;
            this.DataModifLayoutPanel.TabStop = false;
            this.DataModifLayoutPanel.Text = "Modyfikacja";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(18, 79);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(18, 50);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edytuj";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(18, 21);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // normLabel
            // 
            this.normLabel.AutoSize = true;
            this.normLabel.Location = new System.Drawing.Point(2, 90);
            this.normLabel.Name = "normLabel";
            this.normLabel.Size = new System.Drawing.Size(41, 13);
            this.normLabel.TabIndex = 10;
            this.normLabel.Text = "Norma:";
            // 
            // normComboBox
            // 
            this.normComboBox.FormattingEnabled = true;
            this.normComboBox.Location = new System.Drawing.Point(49, 87);
            this.normComboBox.Name = "normComboBox";
            this.normComboBox.Size = new System.Drawing.Size(140, 21);
            this.normComboBox.TabIndex = 9;
            // 
            // EqLayoutPanel
            // 
            this.EqLayoutPanel.Controls.Add(this.niTextBox);
            this.EqLayoutPanel.Controls.Add(this.crTextBox);
            this.EqLayoutPanel.Controls.Add(this.crLabel);
            this.EqLayoutPanel.Controls.Add(this.cTextBox);
            this.EqLayoutPanel.Controls.Add(this.niLabel);
            this.EqLayoutPanel.Controls.Add(this.cLabel);
            this.EqLayoutPanel.Location = new System.Drawing.Point(303, 12);
            this.EqLayoutPanel.Name = "EqLayoutPanel";
            this.EqLayoutPanel.Size = new System.Drawing.Size(207, 108);
            this.EqLayoutPanel.TabIndex = 8;
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
            // materialsDataGridView
            // 
            this.materialsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.materialsDataGridView.Location = new System.Drawing.Point(35, 136);
            this.materialsDataGridView.Name = "materialsDataGridView";
            this.materialsDataGridView.Size = new System.Drawing.Size(892, 252);
            this.materialsDataGridView.TabIndex = 14;
            // 
            // MaterialDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 400);
            this.Controls.Add(this.materialsDataGridView);
            this.Controls.Add(this.ViewLayoutPanel);
            this.Controls.Add(this.DataModifLayoutPanel);
            this.Controls.Add(this.normLabel);
            this.Controls.Add(this.normComboBox);
            this.Controls.Add(this.EqLayoutPanel);
            this.Name = "MaterialDatabaseForm";
            this.Text = "MaterialDatabaseForm";
            this.ViewLayoutPanel.ResumeLayout(false);
            this.ViewLayoutPanel.PerformLayout();
            this.DataModifLayoutPanel.ResumeLayout(false);
            this.EqLayoutPanel.ResumeLayout(false);
            this.EqLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //Equivalents controls
        private System.Windows.Forms.GroupBox EqLayoutPanel;
        private System.Windows.Forms.Label niLabel;
        private System.Windows.Forms.TextBox niTextBox;
        private System.Windows.Forms.Label crLabel;
        private System.Windows.Forms.TextBox crTextBox;
        private System.Windows.Forms.Label cLabel;
        private System.Windows.Forms.TextBox cTextBox;

        //General controls
        private System.Windows.Forms.Label normLabel;
        private System.Windows.Forms.ComboBox normComboBox;

        //DataModification controls
        private System.Windows.Forms.GroupBox DataModifLayoutPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button addButton;

        //View controls
        private System.Windows.Forms.GroupBox ViewLayoutPanel;
        private System.Windows.Forms.CheckBox alCheckBox;
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

        //DataGridView
        private System.Windows.Forms.DataGridView materialsDataGridView;


    }
}