using System.Security.AccessControl;
using System.Windows.Forms;

namespace WelderCalculator.Views.SchaefflerChartView
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
            this.visibilityLayoutPanel = new System.Windows.Forms.GroupBox();
            this.crackingVisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.phaseCheckBox = new System.Windows.Forms.CheckBox();
            this.yAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.xAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.phaseTextCheckBox = new System.Windows.Forms.CheckBox();
            this.hashCheckBox = new System.Windows.Forms.CheckBox();
            this.firstBaseMaterialTextBox = new System.Windows.Forms.TextBox();
            this.secondBaseMaterialTextBox = new System.Windows.Forms.TextBox();
            this.firstBaseMaterialButton = new System.Windows.Forms.Button();
            this.secondBaseMaterialButton = new System.Windows.Forms.Button();
            this.chooseMaterialsLayoutPanel = new System.Windows.Forms.GroupBox();
            this.fastMaterialButton = new System.Windows.Forms.Button();
            this.countButton = new System.Windows.Forms.Button();
            this.additionalMaterialQuantityTextBox = new System.Windows.Forms.TextBox();
            this.additionalMaterialQuantityLabel = new System.Windows.Forms.Label();
            this.addititionalMaterialButton = new System.Windows.Forms.Button();
            this.additionalMaterialTextBox = new System.Windows.Forms.TextBox();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.newMaterialDataLayoutPanel = new System.Windows.Forms.GroupBox();
            this.newMaterialBrittlenessTextbox = new System.Windows.Forms.TextBox();
            this.newMaterialBrittlenessLabel = new System.Windows.Forms.Label();
            this.newMaterialFerriteQuantityTextbox = new System.Windows.Forms.TextBox();
            this.newMaterialFerriteQunatityLabel = new System.Windows.Forms.Label();
            this.newMaterialMicrophaseTextBox = new System.Windows.Forms.TextBox();
            this.newMaterialMicrophaseLabel = new System.Windows.Forms.Label();
            this.legendLayoutPanel = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveChartTestButton = new System.Windows.Forms.Button();
            this.visibilityLayoutPanel.SuspendLayout();
            this.chooseMaterialsLayoutPanel.SuspendLayout();
            this.newMaterialDataLayoutPanel.SuspendLayout();
            this.legendLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // visibilityLayoutPanel
            // 
            this.visibilityLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.visibilityLayoutPanel.Controls.Add(this.crackingVisibleCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.phaseCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.yAxisCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.xAxisCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.phaseTextCheckBox);
            this.visibilityLayoutPanel.Controls.Add(this.hashCheckBox);
            this.visibilityLayoutPanel.Location = new System.Drawing.Point(815, 12);
            this.visibilityLayoutPanel.Name = "visibilityLayoutPanel";
            this.visibilityLayoutPanel.Size = new System.Drawing.Size(131, 155);
            this.visibilityLayoutPanel.TabIndex = 1;
            this.visibilityLayoutPanel.TabStop = false;
            this.visibilityLayoutPanel.Text = "Widoczność";
            // 
            // crackingVisibleCheckBox
            // 
            this.crackingVisibleCheckBox.AutoSize = true;
            this.crackingVisibleCheckBox.Location = new System.Drawing.Point(10, 132);
            this.crackingVisibleCheckBox.Name = "crackingVisibleCheckBox";
            this.crackingVisibleCheckBox.Size = new System.Drawing.Size(79, 17);
            this.crackingVisibleCheckBox.TabIndex = 5;
            this.crackingVisibleCheckBox.Text = "Zagrożenia";
            this.crackingVisibleCheckBox.UseVisualStyleBackColor = true;
            this.crackingVisibleCheckBox.CheckedChanged += new System.EventHandler(this.crackingVisibleCheckBox_CheckedChanged);
            // 
            // phaseCheckBox
            // 
            this.phaseCheckBox.AutoSize = true;
            this.phaseCheckBox.Location = new System.Drawing.Point(10, 88);
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
            this.yAxisCheckBox.Location = new System.Drawing.Point(10, 65);
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
            this.xAxisCheckBox.Location = new System.Drawing.Point(10, 42);
            this.xAxisCheckBox.Name = "xAxisCheckBox";
            this.xAxisCheckBox.Size = new System.Drawing.Size(49, 17);
            this.xAxisCheckBox.TabIndex = 2;
            this.xAxisCheckBox.Text = "Oś X";
            this.xAxisCheckBox.UseVisualStyleBackColor = true;
            this.xAxisCheckBox.CheckedChanged += new System.EventHandler(this.xAxisCheckBox_CheckedChanged);
            // 
            // phaseTextCheckBox
            // 
            this.phaseTextCheckBox.AutoSize = true;
            this.phaseTextCheckBox.Location = new System.Drawing.Point(10, 111);
            this.phaseTextCheckBox.Name = "phaseTextCheckBox";
            this.phaseTextCheckBox.Size = new System.Drawing.Size(48, 17);
            this.phaseTextCheckBox.TabIndex = 0;
            this.phaseTextCheckBox.Text = "Fazy";
            this.phaseTextCheckBox.UseVisualStyleBackColor = true;
            this.phaseTextCheckBox.CheckedChanged += new System.EventHandler(this.phaseTextCheckBox_CheckedChanged);
            // 
            // hashCheckBox
            // 
            this.hashCheckBox.AutoSize = true;
            this.hashCheckBox.Location = new System.Drawing.Point(10, 19);
            this.hashCheckBox.Name = "hashCheckBox";
            this.hashCheckBox.Size = new System.Drawing.Size(51, 17);
            this.hashCheckBox.TabIndex = 1;
            this.hashCheckBox.Text = "Krata";
            this.hashCheckBox.UseVisualStyleBackColor = true;
            this.hashCheckBox.CheckedChanged += new System.EventHandler(this.hashCheckBox_CheckedChanged);
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
            this.chooseMaterialsLayoutPanel.Location = new System.Drawing.Point(815, 173);
            this.chooseMaterialsLayoutPanel.Name = "chooseMaterialsLayoutPanel";
            this.chooseMaterialsLayoutPanel.Size = new System.Drawing.Size(376, 142);
            this.chooseMaterialsLayoutPanel.TabIndex = 6;
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
            // drawPanel
            // 
            this.drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawPanel.Location = new System.Drawing.Point(13, 13);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(796, 511);
            this.drawPanel.TabIndex = 7;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            // 
            // newMaterialDataLayoutPanel
            // 
            this.newMaterialDataLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialBrittlenessTextbox);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialBrittlenessLabel);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialFerriteQuantityTextbox);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialFerriteQunatityLabel);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialMicrophaseTextBox);
            this.newMaterialDataLayoutPanel.Controls.Add(this.newMaterialMicrophaseLabel);
            this.newMaterialDataLayoutPanel.Location = new System.Drawing.Point(815, 321);
            this.newMaterialDataLayoutPanel.Name = "newMaterialDataLayoutPanel";
            this.newMaterialDataLayoutPanel.Size = new System.Drawing.Size(376, 107);
            this.newMaterialDataLayoutPanel.TabIndex = 11;
            this.newMaterialDataLayoutPanel.TabStop = false;
            this.newMaterialDataLayoutPanel.Text = "Dobór materiału";
            // 
            // newMaterialBrittlenessTextbox
            // 
            this.newMaterialBrittlenessTextbox.Location = new System.Drawing.Point(127, 79);
            this.newMaterialBrittlenessTextbox.Name = "newMaterialBrittlenessTextbox";
            this.newMaterialBrittlenessTextbox.ReadOnly = true;
            this.newMaterialBrittlenessTextbox.Size = new System.Drawing.Size(243, 20);
            this.newMaterialBrittlenessTextbox.TabIndex = 13;
            // 
            // newMaterialBrittlenessLabel
            // 
            this.newMaterialBrittlenessLabel.AutoSize = true;
            this.newMaterialBrittlenessLabel.Location = new System.Drawing.Point(7, 82);
            this.newMaterialBrittlenessLabel.Name = "newMaterialBrittlenessLabel";
            this.newMaterialBrittlenessLabel.Size = new System.Drawing.Size(60, 13);
            this.newMaterialBrittlenessLabel.TabIndex = 12;
            this.newMaterialBrittlenessLabel.Text = "Zagrożenia";
            // 
            // newMaterialFerriteQuantityTextbox
            // 
            this.newMaterialFerriteQuantityTextbox.Location = new System.Drawing.Point(127, 52);
            this.newMaterialFerriteQuantityTextbox.Name = "newMaterialFerriteQuantityTextbox";
            this.newMaterialFerriteQuantityTextbox.ReadOnly = true;
            this.newMaterialFerriteQuantityTextbox.Size = new System.Drawing.Size(243, 20);
            this.newMaterialFerriteQuantityTextbox.TabIndex = 11;
            // 
            // newMaterialFerriteQunatityLabel
            // 
            this.newMaterialFerriteQunatityLabel.AutoSize = true;
            this.newMaterialFerriteQunatityLabel.Location = new System.Drawing.Point(7, 55);
            this.newMaterialFerriteQunatityLabel.Name = "newMaterialFerriteQunatityLabel";
            this.newMaterialFerriteQunatityLabel.Size = new System.Drawing.Size(106, 13);
            this.newMaterialFerriteQunatityLabel.TabIndex = 10;
            this.newMaterialFerriteQunatityLabel.Text = "Zawartość ferrytu [%]";
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
            // legendLayoutPanel
            // 
            this.legendLayoutPanel.Controls.Add(this.label10);
            this.legendLayoutPanel.Controls.Add(this.label9);
            this.legendLayoutPanel.Controls.Add(this.label8);
            this.legendLayoutPanel.Controls.Add(this.label7);
            this.legendLayoutPanel.Controls.Add(this.label6);
            this.legendLayoutPanel.Controls.Add(this.label5);
            this.legendLayoutPanel.Controls.Add(this.label4);
            this.legendLayoutPanel.Controls.Add(this.label3);
            this.legendLayoutPanel.Controls.Add(this.label2);
            this.legendLayoutPanel.Controls.Add(this.label1);
            this.legendLayoutPanel.Location = new System.Drawing.Point(952, 17);
            this.legendLayoutPanel.Name = "legendLayoutPanel";
            this.legendLayoutPanel.Size = new System.Drawing.Size(239, 144);
            this.legendLayoutPanel.TabIndex = 13;
            this.legendLayoutPanel.TabStop = false;
            this.legendLayoutPanel.Text = "Legenda";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(92, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 18);
            this.label10.TabIndex = 10;
            this.label10.Text = "(rozrost ziaren w fazie alfa)";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(92, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "- kruchość";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(92, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "(przemiana alfa -> delta)";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(92, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "- kruchość";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "- pękanie zimne";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "- pękanie gorące";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(47)))));
            this.label4.Location = new System.Drawing.Point(8, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Czerwony";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(7, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pomarańczowy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Żółty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(7, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Niebieski";
            // 
            // saveChartTestButton
            // 
            this.saveChartTestButton.Location = new System.Drawing.Point(825, 435);
            this.saveChartTestButton.Name = "saveChartTestButton";
            this.saveChartTestButton.Size = new System.Drawing.Size(366, 89);
            this.saveChartTestButton.TabIndex = 14;
            this.saveChartTestButton.Text = "ZapiszWykres (TESTOWE)";
            this.saveChartTestButton.UseVisualStyleBackColor = true;
            this.saveChartTestButton.Click += new System.EventHandler(this.saveChartTestButton_Click);
            // 
            // SchaefflerChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 536);
            this.Controls.Add(this.saveChartTestButton);
            this.Controls.Add(this.legendLayoutPanel);
            this.Controls.Add(this.newMaterialDataLayoutPanel);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.chooseMaterialsLayoutPanel);
            this.Controls.Add(this.visibilityLayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SchaefflerChartForm";
            this.Text = "SchaefflerChartForm";
            this.visibilityLayoutPanel.ResumeLayout(false);
            this.visibilityLayoutPanel.PerformLayout();
            this.chooseMaterialsLayoutPanel.ResumeLayout(false);
            this.chooseMaterialsLayoutPanel.PerformLayout();
            this.newMaterialDataLayoutPanel.ResumeLayout(false);
            this.newMaterialDataLayoutPanel.PerformLayout();
            this.legendLayoutPanel.ResumeLayout(false);
            this.legendLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox visibilityLayoutPanel;
        private CheckBox phaseCheckBox;
        private CheckBox yAxisCheckBox;
        private CheckBox xAxisCheckBox;
        private CheckBox hashCheckBox;
        private CheckBox phaseTextCheckBox;
        private TextBox firstBaseMaterialTextBox;
        private TextBox secondBaseMaterialTextBox;
        private Button firstBaseMaterialButton;
        private Button secondBaseMaterialButton;
        private GroupBox chooseMaterialsLayoutPanel;
        private Button addititionalMaterialButton;
        private TextBox additionalMaterialTextBox;
        private TextBox additionalMaterialQuantityTextBox;
        private Label additionalMaterialQuantityLabel;
        private Button countButton;
        private Panel drawPanel;
        private Button fastMaterialButton;
        private GroupBox newMaterialDataLayoutPanel;
        private TextBox newMaterialBrittlenessTextbox;
        private Label newMaterialBrittlenessLabel;
        private TextBox newMaterialFerriteQuantityTextbox;
        private Label newMaterialFerriteQunatityLabel;
        private TextBox newMaterialMicrophaseTextBox;
        private Label newMaterialMicrophaseLabel;
        private CheckBox crackingVisibleCheckBox;
        private GroupBox legendLayoutPanel;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button saveChartTestButton;
    }
}