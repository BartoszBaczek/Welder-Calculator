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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.phaseCheckBox = new System.Windows.Forms.CheckBox();
            this.yAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.xAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.hashCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.phaseCheckBox);
            this.groupBox1.Controls.Add(this.yAxisCheckBox);
            this.groupBox1.Controls.Add(this.xAxisCheckBox);
            this.groupBox1.Controls.Add(this.hashCheckBox);
            this.groupBox1.Controls.Add(this.backgroundCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(807, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Widoczność";
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
            // SchaefflerChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.drawPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "SchaefflerChartForm";
            this.Text = "SchaefflerChartForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel drawPanel;
        private GroupBox groupBox1;
        private CheckBox phaseCheckBox;
        private CheckBox yAxisCheckBox;
        private CheckBox xAxisCheckBox;
        private CheckBox hashCheckBox;
        private CheckBox backgroundCheckBox;

    }
}