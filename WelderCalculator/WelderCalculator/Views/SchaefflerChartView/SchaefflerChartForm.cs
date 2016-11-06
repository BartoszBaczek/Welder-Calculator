using System;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.Drawings.Chart;

namespace WelderCalculator.Views.SchaefflerChartView
{
    public partial class SchaefflerChartForm : Form, ISchaefflerChartView
    {
        public SchaefflerChartPresenter Presenter { private get; set; }

        public int DrawPanelWidth { get { return drawPanel.Width; } }

        public int DrawPanelHeight { get { return drawPanel.Height; } }

        public IntPtr DrawPanelCanvas { get { return drawPanel.Handle; } }

        public SchaefflerChartForm()
        {
            InitializeComponent();
            firstBaseMaterialTextBox.ForeColor = Color.Crimson;
            secondBaseMaterialTextBox.ForeColor = Color.OrangeRed;
            additionalMaterialTextBox.ForeColor = Color.DarkMagenta;
            new SchaefflerChartPresenter(this);
            EnableResizeRedraw();
        }

        private void EnableResizeRedraw()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            Presenter.OnPaintEvent(drawPanel.Handle, e);
        }

        #region Visibility checkboxes

        public bool CrackingVisibleCheckBox
        {
            get { return crackingVisibleCheckBox.Checked; }
            set { crackingVisibleCheckBox.Checked = value; }
        }
        public bool PhaseVisibleCheckBox
        {
            get { return phaseTextCheckBox.Checked; }
            set { phaseTextCheckBox.Checked = value; } 
        }

        public bool HashVisibleCheckBox
        {
            get { return hashCheckBox.Checked; }
            set { hashCheckBox.Checked = value; } 
        }

        public bool XAxisVisibleCheckBox
        {
            get { return xAxisCheckBox.Checked; }
            set { xAxisCheckBox.Checked = value; } 
        }

        public bool YAxisVisibleCheckBox
        {
            get { return yAxisCheckBox.Checked; }
            set { yAxisCheckBox.Checked = value; } 
        }

        public bool PhaseLinesVisibleCheckBox
        {
            get { return phaseCheckBox.Checked; }
            set { phaseCheckBox.Checked = value; } 
        }

        private void crackingVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(SchaefflerLayerType.Cracking, CrackingVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void phaseTextCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(SchaefflerLayerType.PhaseText, PhaseVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void hashCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(SchaefflerLayerType.Hash, HashVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void xAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(SchaefflerLayerType.AxisX, XAxisVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void yAxisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(SchaefflerLayerType.AxisY, YAxisVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void phaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(SchaefflerLayerType.Phase, PhaseLinesVisibleCheckBox);
            drawPanel.Refresh();
        }
        #endregion


        #region Controls setting parameters
        public string FirstBaseMaterialTextBox
        {
            get { return firstBaseMaterialTextBox.Text; }
            set { firstBaseMaterialTextBox.Text = value; }
        }

        public string SecondBaseMaterialTextBox
        {
            get { return secondBaseMaterialTextBox.Text; }
            set { secondBaseMaterialTextBox.Text = value; }
        }

        public string AdditionalMaterialTextBox
        {
            get { return additionalMaterialTextBox.Text; }
            set { additionalMaterialTextBox.Text = value; }
        }

        public double? AdditionalMaterialQuantity
        {
            get
            {
                double? textBoxValue = GetTextBoxValue(additionalMaterialQuantityTextBox);
                return textBoxValue;
            }
            set { SetTextboxValue(ref additionalMaterialQuantityTextBox, value); }
        }

        private double? GetTextBoxValue(TextBox textbox)
        {
            try
            {
                string text = textbox.Text.Trim().Replace('.', ',');
                if (string.IsNullOrEmpty(text))
                    return null;
                return Convert.ToDouble(text);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        private void SetTextboxValue(ref TextBox textbox, double? value)
        {
            textbox.Text = value.HasValue ? value.ToString() : string.Empty;
        }

        public string NewMaterialMicrophaseTextBox
        {
            get { return newMaterialMicrophaseTextBox.Text; }
            set { newMaterialMicrophaseTextBox.Text = value; }
        }

        public string NewMaterialFerriteQuantityTextBox
        {
            get { return newMaterialFerriteQuantityTextbox.Text; }
            set { newMaterialFerriteQuantityTextbox.Text = value; }
        }

        #endregion

        private void firstBaseMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnFirstBaseMaterialButtonClicked();
        }

        private void secondBaseMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnSecondBaseMaterialButtonClicked();
        }

        private void addititionalMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnAdditionalMaterialButtonClicked();
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            Presenter.OnCountButtonClicked();
        }

        private void fastMaterialButton_Click(object sender, EventArgs e)
        {
            Presenter.OnFastMaterialButtonClicked();
        }

        private void exportToPDFButton_Click(object sender, EventArgs e)
        {
            Presenter.OnSaveToPDFButtonClicked();
        }
    }
}
