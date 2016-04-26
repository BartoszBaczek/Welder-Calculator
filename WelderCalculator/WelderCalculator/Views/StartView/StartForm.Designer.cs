namespace WelderCalculator.StartView
{
    partial class StartForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.materialBaseStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalMaterialBaseStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.wykresSchaeffleraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorStrip = new System.Windows.Forms.ToolStripSeparator();
            this.exitStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.helpStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.baseMaterialsDatabaseButton = new System.Windows.Forms.Button();
            this.addMaterialDatabaseButton = new System.Windows.Forms.Button();
            this.schaefflerCountingButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileStrip,
            this.helpStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileStrip
            // 
            this.fileStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openStrip,
            this.optionsStrip,
            this.separatorStrip,
            this.exitStrip});
            this.fileStrip.Name = "fileStrip";
            this.fileStrip.Size = new System.Drawing.Size(38, 20);
            this.fileStrip.Text = "Plik";
            // 
            // openStrip
            // 
            this.openStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialBaseStrip,
            this.additionalMaterialBaseStrip,
            this.wykresSchaeffleraToolStripMenuItem});
            this.openStrip.Name = "openStrip";
            this.openStrip.Size = new System.Drawing.Size(114, 22);
            this.openStrip.Text = "Otwórz";
            // 
            // materialBaseStrip
            // 
            this.materialBaseStrip.Name = "materialBaseStrip";
            this.materialBaseStrip.Size = new System.Drawing.Size(243, 22);
            this.materialBaseStrip.Text = "Baza materiałów podstawowych";
            this.materialBaseStrip.Click += new System.EventHandler(this.materialBaseStrip_Click);
            // 
            // additionalMaterialBaseStrip
            // 
            this.additionalMaterialBaseStrip.Name = "additionalMaterialBaseStrip";
            this.additionalMaterialBaseStrip.Size = new System.Drawing.Size(243, 22);
            this.additionalMaterialBaseStrip.Text = "Baza materiałów dodatkowych";
            this.additionalMaterialBaseStrip.Click += new System.EventHandler(this.additionalMaterialBaseStrip_Click);
            // 
            // wykresSchaeffleraToolStripMenuItem
            // 
            this.wykresSchaeffleraToolStripMenuItem.Name = "wykresSchaeffleraToolStripMenuItem";
            this.wykresSchaeffleraToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.wykresSchaeffleraToolStripMenuItem.Text = "Wykres Schaefflera";
            this.wykresSchaeffleraToolStripMenuItem.Click += new System.EventHandler(this.wykresSchaeffleraToolStripMenuItem_Click);
            // 
            // optionsStrip
            // 
            this.optionsStrip.Name = "optionsStrip";
            this.optionsStrip.Size = new System.Drawing.Size(114, 22);
            this.optionsStrip.Text = "Opcje";
            // 
            // separatorStrip
            // 
            this.separatorStrip.Name = "separatorStrip";
            this.separatorStrip.Size = new System.Drawing.Size(111, 6);
            // 
            // exitStrip
            // 
            this.exitStrip.Name = "exitStrip";
            this.exitStrip.Size = new System.Drawing.Size(114, 22);
            this.exitStrip.Text = "Wyjście";
            this.exitStrip.Click += new System.EventHandler(this.exitStrip_Click);
            // 
            // helpStrip
            // 
            this.helpStrip.Name = "helpStrip";
            this.helpStrip.Size = new System.Drawing.Size(57, 20);
            this.helpStrip.Text = "Pomoc";
            this.helpStrip.Click += new System.EventHandler(this.helpStrip_Click);
            // 
            // baseMaterialsDatabaseButton
            // 
            this.baseMaterialsDatabaseButton.Location = new System.Drawing.Point(183, 27);
            this.baseMaterialsDatabaseButton.Name = "baseMaterialsDatabaseButton";
            this.baseMaterialsDatabaseButton.Size = new System.Drawing.Size(93, 57);
            this.baseMaterialsDatabaseButton.TabIndex = 1;
            this.baseMaterialsDatabaseButton.Text = "Baza materiałów podstawowych";
            this.baseMaterialsDatabaseButton.UseVisualStyleBackColor = true;
            this.baseMaterialsDatabaseButton.Click += new System.EventHandler(this.baseMaterialsDatabaseButton_Click);
            // 
            // addMaterialDatabaseButton
            // 
            this.addMaterialDatabaseButton.Location = new System.Drawing.Point(183, 90);
            this.addMaterialDatabaseButton.Name = "addMaterialDatabaseButton";
            this.addMaterialDatabaseButton.Size = new System.Drawing.Size(93, 61);
            this.addMaterialDatabaseButton.TabIndex = 2;
            this.addMaterialDatabaseButton.Text = "Baza materiałów dodatkowych";
            this.addMaterialDatabaseButton.UseVisualStyleBackColor = true;
            this.addMaterialDatabaseButton.Click += new System.EventHandler(this.addMaterialDatabaseButton_Click);
            // 
            // schaefflerCountingButton
            // 
            this.schaefflerCountingButton.Location = new System.Drawing.Point(183, 157);
            this.schaefflerCountingButton.Name = "schaefflerCountingButton";
            this.schaefflerCountingButton.Size = new System.Drawing.Size(93, 23);
            this.schaefflerCountingButton.TabIndex = 3;
            this.schaefflerCountingButton.Text = "Obliczenia";
            this.schaefflerCountingButton.UseVisualStyleBackColor = true;
            this.schaefflerCountingButton.Click += new System.EventHandler(this.schaefflerCountingButton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.schaefflerCountingButton);
            this.Controls.Add(this.addMaterialDatabaseButton);
            this.Controls.Add(this.baseMaterialsDatabaseButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paintEvent);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileStrip;
        private System.Windows.Forms.ToolStripMenuItem openStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsStrip;
        private System.Windows.Forms.ToolStripSeparator separatorStrip;
        private System.Windows.Forms.ToolStripMenuItem exitStrip;
        private System.Windows.Forms.ToolStripMenuItem helpStrip;
        private System.Windows.Forms.ToolStripMenuItem materialBaseStrip;
        private System.Windows.Forms.ToolStripMenuItem additionalMaterialBaseStrip;
        private System.Windows.Forms.ToolStripMenuItem wykresSchaeffleraToolStripMenuItem;
        private System.Windows.Forms.Button baseMaterialsDatabaseButton;
        private System.Windows.Forms.Button addMaterialDatabaseButton;
        private System.Windows.Forms.Button schaefflerCountingButton;
    }
}