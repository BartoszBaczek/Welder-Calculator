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

        public List<Layer> GetActive()
        {
            return _activeLayers;
        }

        public void Remove(string layerType)
        {
            _activeLayers.RemoveAll(l => l.Type == layerType);
        }

        public void Add(string layerType)
        {
            _activeLayers.Add(_allLayers.First(l => l.Type == layerType));
        }
    }
}
