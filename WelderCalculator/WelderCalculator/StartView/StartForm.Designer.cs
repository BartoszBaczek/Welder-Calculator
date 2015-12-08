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
            this.openStrip.Size = new System.Drawing.Size(152, 22);
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
            this.optionsStrip.Size = new System.Drawing.Size(152, 22);
            this.optionsStrip.Text = "Opcje";
            // 
            // separatorStrip
            // 
            this.separatorStrip.Name = "separatorStrip";
            this.separatorStrip.Size = new System.Drawing.Size(149, 6);
            // 
            // exitStrip
            // 
            this.exitStrip.Name = "exitStrip";
            this.exitStrip.Size = new System.Drawing.Size(152, 22);
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
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartForm";
            this.Text = "StartForm";
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
    }
}