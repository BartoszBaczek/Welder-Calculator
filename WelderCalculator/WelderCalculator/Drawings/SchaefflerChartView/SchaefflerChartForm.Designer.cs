using System.Windows.Forms;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    partial class SchaefflerChartForm
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
            this.phaseCheckBox = new System.Windows.Forms.CheckBox();
            this.yAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.xAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.hashCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundCheckBox = new System.Windows.Forms.CheckBox();
            this.firstBaseMaterialTextBox = new System.Windows.Forms.TextBox();
            this.secondBaseMaterialTextBox = new System.Windows.Forms.TextBox();
            this.firstBaseMaterialButton = new System.Windows.Forms.Button();
            this.secondBaseMaterialButton = new System.Windows.Forms.Button();
            this.chooseMaterialsLayoutPanel = new System.Windows.Forms.GroupBox();
            this.addititionalMaterialButton = new System.Windows.Forms.Button();
            this.additionalMaterialButton = new System.Windows.Forms.TextBox();
            this.additionalMaterialQuantityLabel = new System.Windows.Forms.Label();
            this.additionalMaterialQuantityTextBox = new System.Windows.Forms.TextBox();
            this.visibilityLayoutPanel.SuspendLayout();
            this.chooseMaterialsLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.drawPanel.Location = new System.Drawing.Point(12, 12);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(788, 512);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            // 
            // visibilityLayoutPanel
            // 
            this.visibilityLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.visibilityLayoutPanel.Controls.Add(this.phaseCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.yAxisCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.xAxisCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.hashCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.backgroundCheckBox);
            this.visibilityLayoutPanel.Location = new System.Drawing.Point(815, 12);
            this.visibilityLayoutPanel.Name = "visibilityLayoutPanel";
            this.visibilityLayoutPanel.Size = new System.Drawing.Size(131, 137);
            this.visibilityLayoutPanel.TabIndex = 1;
            this.visibilityLayoutPanel.TabStop = false;
            this.visibilityLayoutPanel.Text = "Widoczność";
            // 
            // phaseCheckBox
            // 
            this.phaseCheckBox.AutoSize = true;
            this.phaseCheckBox.Location = new System.Drawing.Point(7, 112);
            this.phaseCheckBox.Name = "phaseCheckBox";
            this.phaseCheckBox.Size = new System.Drawing.Size(85, 17);
            this.phaseCheckBox.TabIndex = 4;
            this.phaseCheckBox.Text = "Linie fazowe";
            this.phaseCheckBox.UseVisualStyleBackColor = true;
            this.phaseCheckBox.CheckedChanged += new System.EventHandler(this.phaseCheckBox_CheckedChanged);
            // 
            // yAxisCheckBox
            // 
            this.yAxisCheckBox.AutoSize = true;
            this.yAxisCheckBox.Location = new System.Drawing.Point(7, 89);
            this.yAxisCheckBox.Name = "yAxisCheckBox";
            this.yAxisCheckBox.Size = new System.Drawing.Size(49, 17);
            this.yAxisCheckBox.TabIndex = 3;
            this.yAxisCheckBox.Text = "Oś Y";
            this.yAxisCheckBox.UseVisualStyleBackColor = true;
            this.yAxisCheckBox.CheckedChanged += new System.EventHandler(this.yAxisCheckBox_CheckedChanged);
            // 
            // xAxisCheckBox
            // 
            this.xAxisCheckBox.AutoSize = true;
            this.xAxisCheckBox.Location = new System.Drawing.Point(7, 66);
            this.xAxisCheckBox.Name = "xAxisCheckBox";
            this.xAxisCheckBox.Size = new System.Drawing.Size(49, 17);
            this.xAxisCheckBox.TabIndex = 2;
            this.xAxisCheckBox.Text = "Oś X";
            this.xAxisCheckBox.UseVisualStyleBackColor = true;
            this.xAxisCheckBox.CheckedChanged += new System.EventHandler(this.xAxisCheckBox_CheckedChanged);
            // 
            // hashCheckBox
            // 
            this.hashCheckBox.AutoSize = true;
            this.hashCheckBox.Location = new System.Drawing.Point(7, 43);
            this.hashCheckBox.Name = "hashCheckBox";
            this.hashCheckBox.Size = new System.Drawing.Size(51, 17);
            this.hashCheckBox.TabIndex = 1;
            this.hashCheckBox.Text = "Krata";
            this.hashCheckBox.UseVisualStyleBackColor = true;
            this.hashCheckBox.CheckedChanged += new System.EventHandler(this.hashCheckBox_CheckedChanged);
            // 
            // backgroundCheckBox
            // 
            this.backgroundCheckBox.AutoSize = true;
            this.backgroundCheckBox.Location = new System.Drawing.Point(7, 20);
            this.backgroundCheckBox.Name = "backgroundCheckBox";
            this.backgroundCheckBox.Size = new System.Drawing.Size(43, 17);
            this.backgroundCheckBox.TabIndex = 0;
            this.backgroundCheckBox.Text = "Tło";
            this.backgroundCheckBox.UseVisualStyleBackColor = true;
            this.backgroundCheckBox.CheckedChanged += new System.EventHandler(this.backgroundCheckBox_CheckedChanged);
            // 
            // firstBaseMaterialTextBox
            // 
            this.firstBaseMaterialTextBox.Location = new System.Drawing.Point(98, 22);
            this.firstBaseMaterialTextBox.Name = "firstBaseMaterialTextBox";
            this.firstBaseMaterialTextBox.Size = new System.Drawing.Size(272, 20);
            this.firstBaseMaterialTextBox.TabIndex = 2;
            // 
            // secondBaseMaterialTextBox
            // 
            this.secondBaseMaterialTextBox.Location = new System.Drawing.Point(98, 48);
            this.secondBaseMaterialTextBox.Name = "secondBaseMaterialTextBox";
            this.secondBaseMaterialTextBox.Size = new System.Drawing.Size(272, 20);
            this.secondBaseMaterialTextBox.TabIndex = 3;
            // 
            // firstBaseMaterialButton
            // 
            this.firstBaseMaterialButton.Location = new System.Drawing.Point(7, 19);
            this.firstBaseMaterialButton.Name = "firstBaseMaterialButton";
            this.firstBaseMaterialButton.Size = new System.Drawing.Size(75, 23);
            this.firstBaseMaterialButton.TabIndex = 4;
            this.firstBaseMaterialButton.Text = "Podstawowy";
            this.firstBaseMaterialButton.UseVisualStyleBackColor = true;
            // 
            // secondBaseMaterialButton
            // 
            this.secondBaseMaterialButton.Location = new System.Drawing.Point(7, 48);
            this.secondBaseMaterialButton.Name = "secondBaseMaterialButton";
            this.secondBaseMaterialButton.Size = new System.Drawing.Size(75, 23);
            this.secondBaseMaterialButton.TabIndex = 5;
            this.secondBaseMaterialButton.Text = "Podstawowy";
            this.secondBaseMaterialButton.UseVisualStyleBackColor = true;
            // 
            // chooseMaterialsLayoutPanel
            // 
            this.chooseMaterialsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseMaterialsLayoutPanel.Controls.Add(this.additionalMaterialQuantityTextBox);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.additionalMaterialQuantityLabel);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.addititionalMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.additionalMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.firstBaseMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.secondBaseMaterialButton);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.firstBaseMaterialTextBox);
            this.chooseMaterialsLayoutPanel.Controls.Add(this.secondBaseMaterialTextBox);
            this.chooseMaterialsLayoutPanel.Location = new System.Drawing.Point(815, 155);
            this.chooseMaterialsLayoutPanel.Name = "chooseMaterialsLayoutPanel";
            this.chooseMaterialsLayoutPanel.Size = new System.Drawing.Size(376, 142);
            this.chooseMaterialsLayoutPanel.TabIndex = 6;
            this.chooseMaterialsLayoutPanel.TabStop = false;
            this.chooseMaterialsLayoutPanel.Text = "Dobór materiału";
            // 
            // addititionalMaterialButton
            // 
            this.addititionalMaterialButton.Location = new System.Drawing.Point(7, 77);
            this.addititionalMaterialButton.Name = "addititionalMaterialButton";
            this.addititionalMaterialButton.Size = new System.Drawing.Size(75, 23);
            this.addititionalMaterialButton.TabIndex = 7;
            this.addititionalMaterialButton.Text = "Dodatkowy";
            this.addititionalMaterialButton.UseVisualStyleBackColor = true;
            // 
            // additionalMaterialButton
            // 
            this.additionalMaterialButton.Location = new System.Drawing.Point(98, 77);
            this.additionalMaterialButton.Name = "additionalMaterialButton";
            this.additionalMaterialButton.Size = new System.Drawing.Size(272, 20);
            this.additionalMaterialButton.TabIndex = 6;
            // 
            // additionalMaterialQuantityLabel
            // 
            this.additionalMaterialQuantityLabel.AutoSize = true;
            this.additionalMaterialQuantityLabel.Location = new System.Drawing.Point(7, 107);
            this.additionalMaterialQuantityLabel.Name = "additionalMaterialQuantityLabel";
            this.additionalMaterialQuantityLabel.Size = new System.Drawing.Size(85, 13);
            this.additionalMaterialQuantityLabel.TabIndex = 8;
            this.additionalMaterialQuantityLabel.Text = "Ilość stopiwa [%]";
            // 
            // additionalMaterialQuantityTextBox
            // 
            this.additionalMaterialQuantityTextBox.Location = new System.Drawing.Point(98, 100);
            this.additionalMaterialQuantityTextBox.Name = "additionalMaterialQuantityTextBox";
            this.additionalMaterialQuantityTextBox.Size = new System.Drawing.Size(100, 20);
            this.additionalMaterialQuantityTextBox.TabIndex = 9;
            // 
            // SchaefflerChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 536);
            this.Controls.Add(this.chooseMaterialsLayoutPanel);
            this.Controls.Add(this.visibilityLayoutPanel);
            this.Controls.Add(this.drawPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "SchaefflerChartForm";
            this.Text = "SchaefflerChartForm";
            this.visibilityLayoutPanel.ResumeLayout(false);
            this.visibilityLayoutPanel.PerformLayout();
            this.chooseMaterialsLayoutPanel.ResumeLayout(false);
            this.chooseMaterialsLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel drawPanel;
        private GroupBox visibilityLayoutPanel;
        private CheckBox phaseCheckBox;
        private CheckBox yAxisCheckBox;
        private CheckBox xAxisCheckBox;
        private CheckBox hashCheckBox;
        private CheckBox backgroundCheckBox;
        private TextBox firstBaseMaterialTextBox;
        private TextBox secondBaseMaterialTextBox;
        private Button firstBaseMaterialButton;
        private Button secondBaseMaterialButton;
        private GroupBox chooseMaterialsLayoutPanel;
        private Button addititionalMaterialButton;
        private TextBox additionalMaterialButton;
        private TextBox additionalMaterialQuantityTextBox;
        private Label additionalMaterialQuantityLabel;

    }
}