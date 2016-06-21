namespace WelderCalculator.Views.WRCChartView
{
    partial class WRCChartForm
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
            this.drawPanel = new System.Windows.Forms.Panel();
            this.visibilityLayoutPanel = new System.Windows.Forms.GroupBox();
            this.ferriteNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.axisCheckBox = new System.Windows.Forms.CheckBox();
            this.phasesCheckBox = new System.Windows.Forms.CheckBox();
            this.hashCheckBox = new System.Windows.Forms.CheckBox();
            this.chooseMaterialsLayoutPanel = new System.Windows.Forms.GroupBox();
            this.fastMaterialButton = new System.Windows.Forms.Button();
            this.countButton = new System.Windows.Forms.Button();
            this.additionalMaterialQuantityTextBox = new System.Windows.Forms.TextBox();
            this.additionalMaterialQuantityLabel = new System.Windows.Forms.Label();
            this.addititionalMaterialButton = new System.Windows.Forms.Button();
            this.additionalMaterialTextBox = new System.Windows.Forms.TextBox();
            this.firstBaseMaterialButton = new System.Windows.Forms.Button();
            this.secondBaseMaterialButton = new System.Windows.Forms.Button();
            this.firstBaseMaterialTextBox = new System.Windows.Forms.TextBox();
            this.secondBaseMaterialTextBox = new System.Windows.Forms.TextBox();
            this.newMaterialDataLayoutPanel = new System.Windows.Forms.GroupBox();
            this.newMaterialFerriteNumberTextBox = new System.Windows.Forms.TextBox();
            this.newMaterialFerriteNumberLabel = new System.Windows.Forms.Label();
            this.newMaterialMicrophaseTextBox = new System.Windows.Forms.TextBox();
            this.newMaterialMicrophaseLabel = new System.Windows.Forms.Label();
            this.showMinimapButton = new System.Windows.Forms.Button();
            this.visibilityLayoutPanel.SuspendLayout();
            this.chooseMaterialsLayoutPanel.SuspendLayout();
            this.newMaterialDataLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drawPanel.Location = new System.Drawing.Point(12, 13);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(796, 512);
            this.drawPanel.TabIndex = 8;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            // 
            // visibilityLayoutPanel
            // 
            this.visibilityLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.visibilityLayoutPanel.Controls.Add(this.ferriteNumberCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.axisCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.phasesCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.hashCheckBox);
            this.visibilityLayoutPanel.Location = new System.Drawing.Point(814, 13);
            this.visibilityLayoutPanel.Name = "visibilityLayoutPanel";
            this.visibilityLayoutPanel.Size = new System.Drawing.Size(131, 112);
            this.visibilityLayoutPanel.TabIndex = 9;
            this.visibilityLayoutPanel.TabStop = false;
            this.visibilityLayoutPanel.Text = "Widoczność";
            // 
            // ferriteNumberCheckBox
            // 
            this.ferriteNumberCheckBox.AutoSize = true;
            this.ferriteNumberCheckBox.Location = new System.Drawing.Point(8, 65);
            this.ferriteNumberCheckBox.Name = "ferriteNumberCheckBox";
            this.ferriteNumberCheckBox.Size = new System.Drawing.Size(111, 17);
            this.ferriteNumberCheckBox.TabIndex = 5;
            this.ferriteNumberCheckBox.Text = "Liczba ferrytyczna";
            this.ferriteNumberCheckBox.UseVisualStyleBackColor = true;
            this.ferriteNumberCheckBox.CheckedChanged += new System.EventHandler(this.ferriteNumberCheckBox_CheckedChanged);
            // 
            // axisCheckBox
            // 
            this.axisCheckBox.AutoSize = true;
            this.axisCheckBox.Location = new System.Drawing.Point(8, 42);
            this.axisCheckBox.Name = "axisCheckBox";
            this.axisCheckBox.Size = new System.Drawing.Size(49, 17);
            this.axisCheckBox.TabIndex = 3;
            this.axisCheckBox.Text = "Oś Y";
            this.axisCheckBox.UseVisualStyleBackColor = true;
            this.axisCheckBox.CheckedChanged += new System.EventHandler(this.axisCheckBox_CheckedChanged);
            // 
            // phasesCheckBox
            // 
            this.phasesCheckBox.AutoSize = true;
            this.phasesCheckBox.Location = new System.Drawing.Point(8, 88);
            this.phasesCheckBox.Name = "phasesCheckBox";
            this.phasesCheckBox.Size = new System.Drawing.Size(48, 17);
            this.phasesCheckBox.TabIndex = 0;
            this.phasesCheckBox.Text = "Fazy";
            this.phasesCheckBox.UseVisualStyleBackColor = true;
            this.phasesCheckBox.CheckedChanged += new System.EventHandler(this.phasesCheckBox_CheckedChanged);
            // 
            // hashCheckBox
            // 
            this.hashCheckBox.AutoSize = true;
            this.hashCheckBox.Location = new System.Drawing.Point(8, 19);
            this.hashCheckBox.Name = "hashCheckBox";
            this.hashCheckBox.Size = new System.Drawing.Size(51, 17);
            this.hashCheckBox.TabIndex = 1;
            this.hashCheckBox.Text = "Krata";
            this.hashCheckBox.UseVisualStyleBackColor = true;
            this.hashCheckBox.CheckedChanged += new System.EventHandler(this.hashCheckBox_CheckedChanged);
            // 
            // chooseMaterialsLayoutPanel
            // 
            this.chooseMaterialsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseMaterialsLayoutPanel.Controls.Add(this.fastMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.countButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.additionalMaterialQuantityTextBox);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.additionalMaterialQuantityLabel);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.addititionalMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.additionalMaterialTextBox);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.firstBaseMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.secondBaseMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.firstBaseMaterialTextBox);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.secondBaseMaterialTextBox);
            this.chooseMaterialsLayoutPanel.Location = new System.Drawing.Point(815, 131);
            this.chooseMaterialsLayoutPanel.Name = "chooseMaterialsLayoutPanel";
            this.chooseMaterialsLayoutPanel.Size = new System.Drawing.Size(376, 142);
            this.chooseMaterialsLayoutPanel.TabIndex = 10;
            this.chooseMaterialsLayoutPanel.TabStop = false;
            this.chooseMaterialsLayoutPanel.Text = "Dobór materiału";
            // 
            // fastMaterialButton
            // 
            this.fastMaterialButton.Location = new System.Drawing.Point(10, 21);
            this.fastMaterialButton.Name = "fastMaterialButton";
            this.fastMaterialButton.Size = new System.Drawing.Size(103, 75);
            this.fastMaterialButton.TabIndex = 10;
            this.fastMaterialButton.Text = "Szybkie obliczenia";
            this.fastMaterialButton.UseVisualStyleBackColor = true;
            this.fastMaterialButton.Click += new System.EventHandler(this.fastMaterialButton_Click);
            // 
            // countButton
            // 
            this.countButton.Location = new System.Drawing.Point(214, 101);
            this.countButton.Name = "countButton";
            this.countButton.Size = new System.Drawing.Size(156, 23);
            this.countButton.TabIndex = 7;
            this.countButton.Text = "Oblicz";
            this.countButton.UseVisualStyleBackColor = true;
            this.countButton.Click += new System.EventHandler(this.countButton_Click);
            // 
            // additionalMaterialQuantityTextBox
            // 
            this.additionalMaterialQuantityTextBox.Location = new System.Drawing.Point(98, 103);
            this.additionalMaterialQuantityTextBox.Name = "additionalMaterialQuantityTextBox";
            this.additionalMaterialQuantityTextBox.Size = new System.Drawing.Size(100, 20);
            this.additionalMaterialQuantityTextBox.TabIndex = 9;
            // 
            // additionalMaterialQuantityLabel
            // 
            this.additionalMaterialQuantityLabel.AutoSize = true;
            this.additionalMaterialQuantityLabel.Location = new System.Drawing.Point(7, 110);
            this.additionalMaterialQuantityLabel.Name = "additionalMaterialQuantityLabel";
            this.additionalMaterialQuantityLabel.Size = new System.Drawing.Size(85, 13);
            this.additionalMaterialQuantityLabel.TabIndex = 8;
            this.additionalMaterialQuantityLabel.Text = "Ilość stopiwa [%]";
            // 
            // addititionalMaterialButton
            // 
            this.addititionalMaterialButton.Location = new System.Drawing.Point(119, 74);
            this.addititionalMaterialButton.Name = "addititionalMaterialButton";
            this.addititionalMaterialButton.Size = new System.Drawing.Size(75, 23);
            this.addititionalMaterialButton.TabIndex = 7;
            this.addititionalMaterialButton.Text = "Dodatkowy";
            this.addititionalMaterialButton.UseVisualStyleBackColor = true;
            this.addititionalMaterialButton.Click += new System.EventHandler(this.addititionalMaterialButton_Click);
            // 
            // additionalMaterialTextBox
            // 
            this.additionalMaterialTextBox.Location = new System.Drawing.Point(200, 76);
            this.additionalMaterialTextBox.Name = "additionalMaterialTextBox";
            this.additionalMaterialTextBox.Size = new System.Drawing.Size(170, 20);
            this.additionalMaterialTextBox.TabIndex = 6;
            // 
            // firstBaseMaterialButton
            // 
            this.firstBaseMaterialButton.Location = new System.Drawing.Point(119, 19);
            this.firstBaseMaterialButton.Name = "firstBaseMaterialButton";
            this.firstBaseMaterialButton.Size = new System.Drawing.Size(75, 23);
            this.firstBaseMaterialButton.TabIndex = 4;
            this.firstBaseMaterialButton.Text = "Podstawowy";
            this.firstBaseMaterialButton.UseVisualStyleBackColor = true;
            this.firstBaseMaterialButton.Click += new System.EventHandler(this.firstBaseMaterialButton_Click);
            // 
            // secondBaseMaterialButton
            // 
            this.secondBaseMaterialButton.Location = new System.Drawing.Point(119, 45);
            this.secondBaseMaterialButton.Name = "secondBaseMaterialButton";
            this.secondBaseMaterialButton.Size = new System.Drawing.Size(75, 23);
            this.secondBaseMaterialButton.TabIndex = 5;
            this.secondBaseMaterialButton.Text = "Podstawowy";
            this.secondBaseMaterialButton.UseVisualStyleBackColor = true;
            this.secondBaseMaterialButton.Click += new System.EventHandler(this.secondBaseMaterialButton_Click);
            // 
            // firstBaseMaterialTextBox
            // 
            this.firstBaseMaterialTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.firstBaseMaterialTextBox.Location = new System.Drawing.Point(200, 21);
            this.firstBaseMaterialTextBox.Name = "firstBaseMaterialTextBox";
            this.firstBaseMaterialTextBox.Size = new System.Drawing.Size(170, 20);
            this.firstBaseMaterialTextBox.TabIndex = 2;
            // 
            // secondBaseMaterialTextBox
            // 
            this.secondBaseMaterialTextBox.Location = new System.Drawing.Point(200, 47);
            this.secondBaseMaterialTextBox.Name = "secondBaseMaterialTextBox";
            this.secondBaseMaterialTextBox.Size = new System.Drawing.Size(170, 20);
            this.secondBaseMaterialTextBox.TabIndex = 3;
            // 
            // newMaterialDataLayoutPanel
            // 
            this.newMaterialDataLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialFerriteNumberTextBox);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialFerriteNumberLabel);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialMicrophaseTextBox);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialMicrophaseLabel);
            this.newMaterialDataLayoutPanel.Location = new System.Drawing.Point(815, 279);
            this.newMaterialDataLayoutPanel.Name = "newMaterialDataLayoutPanel";
            this.newMaterialDataLayoutPanel.Size = new System.Drawing.Size(376, 80);
            this.newMaterialDataLayoutPanel.TabIndex = 12;
            this.newMaterialDataLayoutPanel.TabStop = false;
            this.newMaterialDataLayoutPanel.Text = "Dobór materiału";
            // 
            // newMaterialFerriteNumberTextBox
            // 
            this.newMaterialFerriteNumberTextBox.Location = new System.Drawing.Point(127, 50);
            this.newMaterialFerriteNumberTextBox.Name = "newMaterialFerriteNumberTextBox";
            this.newMaterialFerriteNumberTextBox.ReadOnly = true;
            this.newMaterialFerriteNumberTextBox.Size = new System.Drawing.Size(243, 20);
            this.newMaterialFerriteNumberTextBox.TabIndex = 13;
            // 
            // newMaterialFerriteNumberLabel
            // 
            this.newMaterialFerriteNumberLabel.AutoSize = true;
            this.newMaterialFerriteNumberLabel.Location = new System.Drawing.Point(6, 53);
            this.newMaterialFerriteNumberLabel.Name = "newMaterialFerriteNumberLabel";
            this.newMaterialFerriteNumberLabel.Size = new System.Drawing.Size(115, 13);
            this.newMaterialFerriteNumberLabel.TabIndex = 12;
            this.newMaterialFerriteNumberLabel.Text = "Liczba ferrytyczna [FN]";
            // 
            // newMaterialMicrophaseTextBox
            // 
            this.newMaterialMicrophaseTextBox.Location = new System.Drawing.Point(127, 24);
            this.newMaterialMicrophaseTextBox.Name = "newMaterialMicrophaseTextBox";
            this.newMaterialMicrophaseTextBox.ReadOnly = true;
            this.newMaterialMicrophaseTextBox.Size = new System.Drawing.Size(243, 20);
            this.newMaterialMicrophaseTextBox.TabIndex = 9;
            // 
            // newMaterialMicrophaseLabel
            // 
            this.newMaterialMicrophaseLabel.AutoSize = true;
            this.newMaterialMicrophaseLabel.Location = new System.Drawing.Point(7, 27);
            this.newMaterialMicrophaseLabel.Name = "newMaterialMicrophaseLabel";
            this.newMaterialMicrophaseLabel.Size = new System.Drawing.Size(30, 13);
            this.newMaterialMicrophaseLabel.TabIndex = 8;
            this.newMaterialMicrophaseLabel.Text = "Faza";
            // 
            // showMinimapButton
            // 
            this.showMinimapButton.Location = new System.Drawing.Point(814, 365);
            this.showMinimapButton.Name = "showMinimapButton";
            this.showMinimapButton.Size = new System.Drawing.Size(376, 57);
            this.showMinimapButton.TabIndex = 13;
            this.showMinimapButton.Text = "Pokaż minimapę";
            this.showMinimapButton.UseVisualStyleBackColor = true;
            this.showMinimapButton.Click += new System.EventHandler(this.showMinimapButton_Click);
            // 
            // WRCChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 532);
            this.Controls.Add(this.showMinimapButton);
            this.Controls.Add(this.newMaterialDataLayoutPanel);
            this.Controls.Add(this.chooseMaterialsLayoutPanel);
            this.Controls.Add(this.visibilityLayoutPanel);
            this.Controls.Add(this.drawPanel);
            this.Name = "WRCChartForm";
            this.Text = "WRCChartForm";
            this.visibilityLayoutPanel.ResumeLayout(false);
            this.visibilityLayoutPanel.PerformLayout();
            this.chooseMaterialsLayoutPanel.ResumeLayout(false);
            this.chooseMaterialsLayoutPanel.PerformLayout();
            this.newMaterialDataLayoutPanel.ResumeLayout(false);
            this.newMaterialDataLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.GroupBox visibilityLayoutPanel;
        private System.Windows.Forms.CheckBox ferriteNumberCheckBox;
        private System.Windows.Forms.CheckBox axisCheckBox;
        private System.Windows.Forms.CheckBox phasesCheckBox;
        private System.Windows.Forms.CheckBox hashCheckBox;
        private System.Windows.Forms.GroupBox chooseMaterialsLayoutPanel;
        private System.Windows.Forms.Button fastMaterialButton;
        private System.Windows.Forms.Button countButton;
        private System.Windows.Forms.TextBox additionalMaterialQuantityTextBox;
        private System.Windows.Forms.Label additionalMaterialQuantityLabel;
        private System.Windows.Forms.Button addititionalMaterialButton;
        private System.Windows.Forms.TextBox additionalMaterialTextBox;
        private System.Windows.Forms.Button firstBaseMaterialButton;
        private System.Windows.Forms.Button secondBaseMaterialButton;
        private System.Windows.Forms.TextBox firstBaseMaterialTextBox;
        private System.Windows.Forms.TextBox secondBaseMaterialTextBox;
        private System.Windows.Forms.GroupBox newMaterialDataLayoutPanel;
        private System.Windows.Forms.TextBox newMaterialFerriteNumberTextBox;
        private System.Windows.Forms.Label newMaterialFerriteNumberLabel;
        private System.Windows.Forms.TextBox newMaterialMicrophaseTextBox;
        private System.Windows.Forms.Label newMaterialMicrophaseLabel;
        private System.Windows.Forms.Button showMinimapButton;
    }
}