using System.Collections.Generic;
using System.Linq;

namespace WelderCalculator.Drawings.Chart
{
    public class Layers
    {
        private readonly List<Layer> _activeLayers;
        private readonly List<Layer> _allLayers;

        public Layers(List<Layer> layers)
        {
            _allLayers = new List<Layer>();
            foreach (var layer in layers)
            {
                _allLayers.Add(layer);
            }

            _activeLayers = layers;
        }

        public Layer Get(LayerType type)
        {
            return _activeLayers.First(l => l.Type == type);
        }

        public List<Layer> GetActive()
        {
            return _activeLayers;
        }

        public void Remove(LayerType type)
        {
            _activeLayers.RemoveAll(l => l.Type == type);
        }

        public void Add(LayerType type)
        {
            _activeLayers.Add(_allLayers.First(l => l.Type == type));
        }
    }
}
