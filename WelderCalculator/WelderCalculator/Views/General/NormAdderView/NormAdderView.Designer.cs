namespace WelderCalculator.Views.General.NormAdderView
{
    partial class NormAdderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NormAdderView));
            this.normNameTextBox = new System.Windows.Forms.TextBox();
            this.normNameLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // normNameTextBox
            // 
            this.normNameTextBox.Location = new System.Drawing.Point(95, 32);
            this.normNameTextBox.Name = "normNameTextBox";
            this.normNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.normNameTextBox.TabIndex = 0;
            // 
            // normNameLabel
            // 
            this.normNameLabel.AutoSize = true;
            this.normNameLabel.Location = new System.Drawing.Point(13, 35);
            this.normNameLabel.Name = "normNameLabel";
            this.normNameLabel.Size = new System.Drawing.Size(76, 13);
            this.normNameLabel.TabIndex = 1;
            this.normNameLabel.Text = "Nazwa Normy:";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(28, 84);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(148, 84);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NormAdderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 119);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.normNameLabel);
            this.Controls.Add(this.normNameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NormAdderView";
            this.Text = "Dodaj normę";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox normNameTextBox;
        private System.Windows.Forms.Label normNameLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}