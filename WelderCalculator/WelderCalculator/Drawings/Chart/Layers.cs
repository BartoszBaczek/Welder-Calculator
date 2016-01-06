using System.Collections.Generic;
using System.Linq;
using WelderCalculator.Drawings.SchaefflerChartView;

namespace WelderCalculator.Drawings.Chart
{
    public class Layers
    {
        private List<Layer> chartLayers;

        public Layers(List<Layer> layers)
        {
            chartLayers = layers;
        }

        public Layer Get(LayerType type)
        {
            return chartLayers.First(l => l.Type == type);
        }

        public List<Layer> GetAll()
        {
            return chartLayers;
        }

        public void Remove(LayerType type)
        {
            chartLayers.RemoveAll(l => l.Type == type);
        }

        public void Add(Layer layer)
        {
            chartLayers.Add(layer);
        }

        
    }
}
