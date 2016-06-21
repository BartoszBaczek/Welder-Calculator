using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WelderCalculator.Drawings.Chart;

namespace WelderCalculator.Views.WRCChartView
{
    public partial class WRCChartForm : Form, IWRCChartView
    {

        public WRCChartPresenter Presenter { private get; set; }

        public IntPtr DrawPanelCanvas { get { return drawPanel.Handle; } }

        public int DrawPanelWidth { get { return drawPanel.Width; } }

        public int DrawPanelHeight { get { return drawPanel.Height; } }

        #region VisibilityCheckBoxes

        public bool AxisVisibleCheckBox
        {
            get { return axisCheckBox.Checked; }
            set { axisCheckBox.Checked = value; }
        }

        public bool FerriteNumberVisibleCheckBox
        {
            get { return ferriteNumberCheckBox.Checked; }
            set { ferriteNumberCheckBox.Checked = value; }
        }

        public bool HashVisibleCheckBox
        {
            get { return hashCheckBox.Checked; }
            set { hashCheckBox.Checked = value; }
        }

        public bool PhaseVisibleCheckBox
        {
            get { return phasesCheckBox.Checked; }
            set { phasesCheckBox.Checked = value; }
        }


        private void hashCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(WRC1992LayerType.Hash, HashVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void axisCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(WRC1992LayerType.Axis, AxisVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void ferriteNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(WRC1992LayerType.FnContent, FerriteNumberVisibleCheckBox);
            drawPanel.Refresh();
        }

        private void phasesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Presenter.OnLayerVisibilityChanged(WRC1992LayerType.Phase, PhaseVisibleCheckBox);
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

        public string NewMaterialFerriteNumberTextBox
        {
            get { return newMaterialFerriteNumberTextBox.Text; }
            set { newMaterialFerriteNumberTextBox.Text = value; }
        }

        public string NewMaterialMicrophaseTextBox
        {
            get { return newMaterialMicrophaseTextBox.Text; }
            set { newMaterialMicrophaseTextBox.Text = value; }
        }
        #endregion

        public WRCChartForm()
        {
            InitializeComponent();
            firstBaseMaterialTextBox.ForeColor = Color.Crimson;
            secondBaseMaterialTextBox.ForeColor = Color.OrangeRed;
            additionalMaterialTextBox.ForeColor = Color.DarkMagenta;
            new WRCChartPresenter(this);
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

        private void showMinimapButton_Click(object sender, EventArgs e)
        {
            Presenter.OnShowMinimapButtonClicked();
        }

        private void exportToPDFButton_Click(object sender, EventArgs e)
        {
            Presenter.OnSaveToPDFButtonClicked();
        }
    }
}
