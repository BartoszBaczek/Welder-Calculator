using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WelderCalculator.MaterialModificationView.Serialization;

namespace WelderCalculator.Drawings.SchaefflerChartView
{
    public class SchaefflerChartPresenter
    {
        private readonly ISchaefflerChartView _view;
        private List<Image> imagesToDraw;
        private readonly DataConnector _dataConnector;
        private readonly ChartManager _chartManager;

        public SchaefflerChartPresenter(ISchaefflerChartView view)
        {
            _view = view;
            _view.Presenter = this; 
            _dataConnector = new DataConnector();
            _chartManager = new ChartManager();
            LoadImages();
        }

        private void LoadImages()
        {
            imagesToDraw = _dataConnector.GetSchaefflerImages();
        }
         
        public void Draw(IntPtr panelHandle, PaintEventArgs e)
        {
            foreach (var image in imagesToDraw)
            {
                Bitmap resizedImage = _chartManager.ResizeImage(image, _view.DrawPanelWidth, _view.DrawPanelHeight);

                using (Graphics graphics = Graphics.FromHwnd(panelHandle))
                {
                    graphics.DrawImage(resizedImage,
                    new Rectangle(new Point(0, 0), new Size(_view.DrawPanelWidth, _view.DrawPanelHeight)));
                }
            }
        }

    }
}
