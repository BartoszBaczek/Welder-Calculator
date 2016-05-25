using System;
using System.Windows.Forms;


namespace WelderCalculator.Views.SchaefflerMinimapView
{
    public partial class SchaefflerMinimapForm : Form, ISchaefflerMinimapView
    {
        public SchaefflerMinimapPresenter Presenter { private get; set; }
        public IntPtr DrawPanelCanvas { get { return drawPanel.Handle; } }

        public int DrawPanelWidth { get { return drawPanel.Width; } }

        public int DrawPanelHeight { get { return drawPanel.Height; } }


        public SchaefflerMinimapForm(MinimapCombination minimapCombination, double additionalMaterialQuantity)
        {
            InitializeComponent();
            new SchaefflerMinimapPresenter(this, minimapCombination, additionalMaterialQuantity);
        }

        public void CancelDialog()
        {
            this.Close();
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            Presenter.OnPaintEvent(drawPanel.Handle, e);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Presenter.OnOKButtonClicked();
        }

        private void SchaefflerMinimapForm_Load(object sender, EventArgs e)
        {

        }
    }
}
