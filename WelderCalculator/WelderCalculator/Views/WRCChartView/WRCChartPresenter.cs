using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WelderCalculator.Drawings.Chart;
using WelderCalculator.Helpers;
using WelderCalculator.Helpers.WRCHelper;
using WelderCalculator.Model;
using WelderCalculator.Repositories;
using WelderCalculator.Views.AddMaterialDatabaseView;
using WelderCalculator.Views.FastMaterialFactoryView;
using WelderCalculator.Views.MaterialDatabaseView;
using WelderCalculator.Views.SchaefflerMinimapView;

namespace WelderCalculator.Views.WRCChartView
{
    public class WRCChartPresenter
    {
        private readonly IWRCChartView _view;
        private readonly DataConnector _dataConnector;
        private IChart _chart;
        private bool _someCountingsFinished = false;

        public WRCChartPresenter(IWRCChartView view)
        {
            _view = view;
            _view.Presenter = this;
            _dataConnector = new DataConnector();
            _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                _dataConnector.GetWRC1992Images(),
                _dataConnector.GetWRC1992ChartSizingData());

            SetVisibilityCheckBoxesToTrue();
            RefreshSelectedMaterials();
        }

        public void OnPaintEvent(IntPtr panelHandle, PaintEventArgs e)
        {
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
        }

        public void OnLayerVisibilityChanged(string layerType, bool visibility)
        {
            if (!visibility)
                _chart.Layers.Remove(layerType);
            else
                _chart.Layers.Add(layerType);
        }

        private void SetVisibilityCheckBoxesToTrue()
        {
            _view.PhaseVisibleCheckBox = true;
            _view.HashVisibleCheckBox = true;
            _view.AxisVisibleCheckBox = true;
            _view.FerriteNumberVisibleCheckBox = true;
        }

        public void OnFastMaterialButtonClicked()
        {
            var fastMaterialForm = new FastMaterialFactoryForm();
            fastMaterialForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        public void OnFirstBaseMaterialButtonClicked()
        {
            var materialDatabaseForm = new MaterialDatabaseForm(BaseMaterialDatabaseAccesibility.PartialForFirstMaterial);
            materialDatabaseForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        public void OnSecondBaseMaterialButtonClicked()
        {
            var materialDatabaseForm = new MaterialDatabaseForm(BaseMaterialDatabaseAccesibility.PartialForSecondMaterial);
            materialDatabaseForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        public void OnAdditionalMaterialButtonClicked()
        {
            var addMaterialDatabaseForm = new AddMaterialDatabaseForm(AdditiveMaterialDatabaseAccesibility.Partial);
            addMaterialDatabaseForm.ShowDialog();
            RefreshSelectedMaterials();
        }

        private void RefreshSelectedMaterials()
        {
            BaseMaterial firstBaseMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            _view.FirstBaseMaterialTextBox = firstBaseMaterial.Name;

            BaseMaterial secondBaseMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            _view.SecondBaseMaterialTextBox = secondBaseMaterial.Name;

            AdditiveMaterial additiveMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
            if (additiveMaterial != null)
                _view.AdditionalMaterialTextBox = additiveMaterial.Name;
        }

        public void OnShowMinimapButtonClicked()
        {
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (_view.AdditionalMaterialQuantity > 0 &&
                                                                                    _view.AdditionalMaterialQuantity < 100);
            if ((!(_view.AdditionalMaterialQuantity.HasValue &&
                additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
                                ||
                !_someCountingsFinished)
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100.\nUpewnij się że przeprowadzono obliczenia.");
                return;
            }

            var schaefflerDeLongMinimapForm = new SchaefflerMinimapForm(MinimapCombination.SchaefflerWRC1992, _view.AdditionalMaterialQuantity.Value, false);
            schaefflerDeLongMinimapForm.ShowDialog();
        }

        public void OnCountButtonClicked()
        {
            double? additionalMaterialQuantity = _view.AdditionalMaterialQuantity;
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (additionalMaterialQuantity > 0 &&
                                                                                    additionalMaterialQuantity < 100);
            if (!(additionalMaterialQuantity.HasValue && additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100");
                return;
            }

            CountPointsAndLinesPositionAndDraw();

            _someCountingsFinished = true;
        }

        private void CountPointsAndLinesPositionAndDraw()
        {
            double? additionalMaterialQuantity = _view.AdditionalMaterialQuantity;

            var firstMaterial = _dataConnector.GetFirstBasisMarerialForSchaeffler();
            PointF pointForFirstMaterial = new PointF((float)firstMaterial.CrEqWRC1992, (float)firstMaterial.NiEqWRC1992);

            var secondMaterial = _dataConnector.GetSecondBasisMarerialForSchaeffler();
            PointF pointForSecondMaterial = new PointF((float)secondMaterial.CrEqWRC1992, (float)secondMaterial.NiEqWRC1992);

            var addMaterial = _dataConnector.GetAdditionalMaterialForSchaeffler();
            PointF pointForAddMaterial = new PointF((float)addMaterial.CrEqWRC1992, (float)addMaterial.NiEqWRC1992);

            PointF pointInTheMiddleOfLine = GeometryHelper.GetPointInTheMiddle(pointForFirstMaterial, pointForSecondMaterial);

            PointF pointInTheMiddleOfLineWithTranslation = GeometryHelper.GetPointInTheMiddleWithTranslation((double)additionalMaterialQuantity / 100.0d, pointInTheMiddleOfLine, pointForAddMaterial);
            DrawCountedPointsAndLines(pointForFirstMaterial, pointForSecondMaterial, pointForAddMaterial, pointInTheMiddleOfLine, pointInTheMiddleOfLineWithTranslation);
            PrintNewMaterialDataForPoint(pointInTheMiddleOfLineWithTranslation);
        }

        private void DrawCountedPointsAndLines(PointF pointForFirstMaterial, PointF pointForSecondMaterial, PointF pointForAddMaterial, PointF pointInTheMiddleOfLine, PointF pointInTheMiddleOfLineWithTranslation)
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

        private void PrintNewMaterialDataForPoint(PointF newMaterialPoint)
        {
            var wrcChartHelper = new WrcChartHelper();
            //      var schaefflerMicrophaseHelper = new SchaefflerMicrophaseHelper();
            //      SchaefflerMicrophase newMaterialMicrophase = schaefflerMicrophaseHelper.GetMicrophaseForPoint(newMaterialPoint);
            // 
            //      switch (newMaterialMicrophase)
            //      {
            //          case SchaefflerMicrophase.FM:
            //              _view.NewMaterialMicrophaseTextBox = "Ferrytyczno - martenzytyczna";
            //              break;
            //          case SchaefflerMicrophase.M:
            //              _view.NewMaterialMicrophaseTextBox = "Martenzytyczna";
            //              break;
            //          case SchaefflerMicrophase.AM:
            //              _view.NewMaterialMicrophaseTextBox = "Austenityczno - martenzytyczna";
            //              break;
            //          case SchaefflerMicrophase.A:
            //              _view.NewMaterialMicrophaseTextBox = "Austenityczna";
            //              break;
            //          case SchaefflerMicrophase.MF:
            //              _view.NewMaterialMicrophaseTextBox = "Martenzytyczno - ferrytyczna";
            //              break;
            //          case SchaefflerMicrophase.AMF:
            //              _view.NewMaterialMicrophaseTextBox = "Austeniticzno - martenzytyczno - ferrytyczna";
            //              break;
            //          case SchaefflerMicrophase.AF:
            //              _view.NewMaterialMicrophaseTextBox = "Austenityczno - ferrytyczna";
            //              break;
            //          case SchaefflerMicrophase.F:
            //              _view.NewMaterialMicrophaseTextBox = "Ferrytyczna";
            //              break;
            //          case SchaefflerMicrophase.Unknown:
            //              _view.NewMaterialMicrophaseTextBox = "Poza wykresem";
            //              break;
            //      }

            WrcFerriteQuantity newMaterialFerriteQuantity = wrcChartHelper.GetWrcFerriteQuantityForPoint(newMaterialPoint);
       
            if (newMaterialFerriteQuantity == WrcFerriteQuantity.Unknown)
                _view.NewMaterialFerriteNumberTextBox = "Nieznana";
            else
            {
                switch (newMaterialFerriteQuantity)
                {
                    case WrcFerriteQuantity._0to4:
                        _view.NewMaterialFerriteNumberTextBox= "0 - 4";
                        break;
                    case WrcFerriteQuantity._4to8:
                        _view.NewMaterialFerriteNumberTextBox = "4 - 8";
                        break;
                    case WrcFerriteQuantity._8to12:
                        _view.NewMaterialFerriteNumberTextBox = "8 - 12";
                        break;
                    case WrcFerriteQuantity._12to16:
                        _view.NewMaterialFerriteNumberTextBox = "12 - 16";
                        break;
                    case WrcFerriteQuantity._16to20:
                        _view.NewMaterialFerriteNumberTextBox = "16 - 20";
                        break;
                    case WrcFerriteQuantity._20to24:
                        _view.NewMaterialFerriteNumberTextBox = "20 - 24";
                        break;
                    case WrcFerriteQuantity._24to28:
                        _view.NewMaterialFerriteNumberTextBox = "24 - 28";
                        break;
                    case WrcFerriteQuantity._28to35:
                        _view.NewMaterialFerriteNumberTextBox = "28 - 35";
                        break;
                    case WrcFerriteQuantity._35to55:
                        _view.NewMaterialFerriteNumberTextBox = "35 - 55";
                        break;
                    case WrcFerriteQuantity._55to75:
                        _view.NewMaterialFerriteNumberTextBox = "55 - 75";
                        break;
                    case WrcFerriteQuantity._75to95:
                        _view.NewMaterialFerriteNumberTextBox = "75 - 95";
                        break;
                    case WrcFerriteQuantity._95to100:
                        _view.NewMaterialFerriteNumberTextBox = "95 - 100";
                        break;
                }
       
            }
        }

        public void OnSaveToPDFButtonClicked()
        {
            double? additionalMaterialQuantity = _view.AdditionalMaterialQuantity;
            bool additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100 = (additionalMaterialQuantity > 0 &&
                                                                                    additionalMaterialQuantity < 100);
            if ((!(additionalMaterialQuantity.HasValue && additionalMaterialQuantityIsGreaterThanZeroAndSmallerThanOne100))
                ||
                !_someCountingsFinished)
            {
                MessageBox.Show("Ilość materiału dodatkowego nie jest liczba z zakresu od 0 od 100.\nUpewnij się że przeprowadzono obliczenia.");
                return;
            }

            int widthForA4 = (int)((float)_view.DrawPanelWidth * 0.6);
            int heightForA4 = (int)((float)_view.DrawPanelHeight * 0.6);

            Bitmap bitmap = new Bitmap(widthForA4, heightForA4);

            _chart = new Chart(Graphics.FromImage(bitmap),
                _dataConnector.GetWRC1992Images(),
                _dataConnector.GetWRC1992ChartSizingData());
            _chart.ResizeTo(widthForA4, heightForA4);
            _chart.Draw();
            CountPointsAndLinesPositionAndDraw();


            _dataConnector.SaveMainChartForPDF(bitmap);


            _chart = new Chart(Graphics.FromHwnd(_view.DrawPanelCanvas),
                _dataConnector.GetWRC1992Images(),
                _dataConnector.GetWRC1992ChartSizingData());
            _chart.ResizeTo(_view.DrawPanelWidth, _view.DrawPanelHeight);
            _chart.Draw();
            CountPointsAndLinesPositionAndDraw();

            var schaefflerDeLongMinimapForm = new SchaefflerMinimapForm(MinimapCombination.SchaefflerWRC1992, _view.AdditionalMaterialQuantity.Value, true);
        }
    }
}
