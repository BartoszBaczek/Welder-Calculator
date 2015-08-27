using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

namespace WelderCalculator.Model
{
    public class Material
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public List<Element> Elements { get; set; }

        public double? CEq { get { return 0; }}             //TODO dokonczyc

        public double? NiEq { get { return 0; } }           //TODO dokonczyc

        public double? CeEq { get { return 0; } }           //TODO dokonczyc

        public Material()
        {
            Name = string.Empty;
            Number = string.Empty;
            Elements = new List<Element>()
            {
                new Element(Type.OfElement.C),
                new Element(Type.OfElement.Si),
                new Element(Type.OfElement.Mn),
                new Element(Type.OfElement.P),
                new Element(Type.OfElement.S),
                new Element(Type.OfElement.N),
                new Element(Type.OfElement.Cr),
                new Element(Type.OfElement.Mo),
                new Element(Type.OfElement.Nb),
                new Element(Type.OfElement.Nb),
                new Element(Type.OfElement.Ni),
                new Element(Type.OfElement.Ti),
                new Element(Type.OfElement.Al),
                new Element(Type.OfElement.V),
                new Element(Type.OfElement.Cu)
            };
        }

        public Element GetElement(Type.OfElement requestedElement)
        {
            var singleElement = this.Elements.First(x => x.Name == requestedElement);
            return singleElement;
        }
    }
}
