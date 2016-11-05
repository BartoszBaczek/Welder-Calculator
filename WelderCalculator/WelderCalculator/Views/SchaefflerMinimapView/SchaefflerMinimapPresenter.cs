using System;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.Repositories;
using WelderCalculator.Drawings.Chart;
using WelderCalculator.Helpers;
namespace WelderCalculator.Views.SchaefflerMinimapView
{
    public class SchaefflerMinimapPresenter
    {
        private readonly ISchaefflerMinimapView _view;
        private readonly DataConnector _dataConnector;
        private IChart _chart;
        private readonly MinimapCombination _minimapCombination;
        private double _additionalMaterialQuantity;

        public SchaefflerMinimapPresenter(ISchaefflerMinimapView view, MinimapCombination minimapCombination, double additionalMaterialQuantity)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
            _minimapCombination = minimapCombination;
            _additionalMaterialQuantity = additionalMaterialQuantity;

            LoadChartData();
            DrawLines();

            SaveMinimap();
        }


        public void SaveMinimap()
        {
            int widthForA4 = (int)((float)_view.DrawPanelWidth * 0.8);
            int heightForA4 = (int)((float)_view.DrawPanelHeight * 0.8);

            Bitmap bitmap = new Bitmap(widthForA4, heightForA4);

            if (_minimapCombination == MinimapCombination.SchaefflerDeLong)
            {
                _chart = new Chart(Graphics.FromImage(bitmap),
                _dataConnector.GetSchaefflerDeLongMinimapImages(),
                _dataConnector.GetSchaefflerDeLongMinimapSizingData());
            }
            else if (_minimapCombination == MinimapCombination.SchaefflerWRC1992)
            {
                _chart = new Chart(Graphics.FromImage(bitmap),
                    _dataConnector.GetSchaefflerWRC1992MinimapImages(),
                    _dataConnector.GetSchaefflerWRC1992MinimapSizingData());
            }

            _chart.ResizeTo(widthForA4, heightForA4);
            _chart.Draw();
            DrawLines();

            _dataConnector.SaveMinimapForPDF(bitmap);



            if (_minimapCombination == MinimapCombination.SchaefflerDeLong)
            {
                _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                _dataConnector.GetSchaefflerDeLongMinimapImages(),
                _dataConnector.GetSchaefflerDeLongMinimapSizingData());
            }
            else if (_minimapCombination == MinimapCombination.SchaefflerWRC1992)
            {
                _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                    _dataConnector.GetSchaefflerWRC1992MinimapImages(),
                    _dataConnector.GetSchaefflerWRC1992MinimapSizingData());
            }
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
            DrawLines();
        }

        private void LoadChartData()
        {
            if (_minimapCombination == MinimapCombination.SchaefflerDeLong)
            {
                _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                    _dataConnector.GetSchaefflerDeLongMinimapImages(),
                    _dataConnector.GetSchaefflerDeLongMinimapSizingData());
            }
            else if (_minimapCombination == MinimapCombination.SchaefflerWRC1992)
            {
                _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                    _dataConnector.GetSchaefflerWRC1992MinimapImages(),
                    _dataConnector.GetSchaefflerWRC1992MinimapSizingData());
            }
        }

        public void OnPaintEvent(IntPtr panelHandle, PaintEventArgs e)
        {
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
        }

        public void OnOKButtonClicked()
        {
            _view.CancelDialog();
        }

        private void DrawLines()
        {
            double? additionalMaterialQuantity = _additionalMaterialQuantity;
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (additionalMaterialQuantity > 0 &&
                                                                                    additionalMaterialQuantity < 100);
            if (!(additionalMaterialQuantity.HasValue && additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100");
                return;
            }

            var firstMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            var secondMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            var addMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();

            PointF pointForFirstMaterial = new PointF();   
            PointF pointForSecondMaterial = new PointF();  
            PointF pointForAddMaterial = new PointF();

            if (_minimapCombination == MinimapCombination.SchaefflerDeLong)
            {
                pointForFirstMaterial = new PointF((float)firstMaterial.CrEqSchaefflerAndDeLong, (float)firstMaterial.NiEqDeLong);
                pointForSecondMaterial  = new PointF((float)secondMaterial.CrEqSchaefflerAndDeLong, (float)secondMaterial.NiEqDeLong);
                pointForAddMaterial = new PointF((float)addMaterial.CrEqSchaefflerAndDeLong, (float)addMaterial.NiEqDeLong);
            }
            else if(_minimapCombination == MinimapCombination.SchaefflerWRC1992)
            {
                pointForFirstMaterial = new PointF((float)firstMaterial.CrEqWRC1992, (float)firstMaterial.NiEqWRC1992);
                pointForSecondMaterial = new PointF((float)secondMaterial.CrEqWRC1992, (float)secondMaterial.NiEqWRC1992);
                pointForAddMaterial = new PointF((float)addMaterial.CrEqWRC1992, (float)addMaterial.NiEqWRC1992);
            }

            PointF pointInTheMiddleOfLine = GeometryHelper.GetPointInTheMiddle(pointForFirstMaterial, pointForSecondMaterial);

            PointF pointInTheMiddleOfLineWithTranslation = GeometryHelper.GetPointInTheMiddleWithTranslation((double)additionalMaterialQuantity / 100.0d, pointInTheMiddleOfLine, pointForAddMaterial);
            RedrawChart(pointForFirstMaterial, pointForSecondMaterial, pointForAddMaterial, pointInTheMiddleOfLine, pointInTheMiddleOfLineWithTranslation);
        }

        private void RedrawChart(PointF pointForFirstMaterial, PointF pointForSecondMaterial, PointF pointForAddMaterial, PointF pointInTheMiddleOfLine, PointF pointInTheMiddleOfLineWithTranslation)
        {
            _chart.Clean();

            // point for each material
            _chart.AddPoint(pointForFirstMaterial, Color.Crimson);
            _chart.AddPoint(pointForSecondMaterial, Color.OrangeRed);
            _chart.AddPoint(pointForAddMaterial, Color.DarkMagenta);

            // line between base materials
            _chart.AddLine(pointForFirstMaterial, pointForSecondMaterial, Color.GreenYellow);

            // all the rest
            _chart.AddPoint(pointInTheMiddleOfLine, Color.Blue);
            _chart.AddLine(pointInTheMiddleOfLine, pointForAddMaterial, Color.GreenYellow);
            _chart.AddPoint(pointInTheMiddleOfLineWithTranslation, Color.Red);

            _chart.Draw();
        }
    }
}
