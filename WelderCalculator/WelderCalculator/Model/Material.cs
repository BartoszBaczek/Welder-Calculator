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
            Elements = new List<Element>();
        }

        public void CreateBasicListOfElements()
        {
            Elements.Add(new Element(Category.OfElement.C));
            Elements.Add(new Element(Category.OfElement.Si));
            Elements.Add(new Element(Category.OfElement.Mn));
            Elements.Add(new Element(Category.OfElement.P));
            Elements.Add(new Element(Category.OfElement.S));
            Elements.Add(new Element(Category.OfElement.N));
            Elements.Add(new Element(Category.OfElement.Cr));
            Elements.Add(new Element(Category.OfElement.Mo));
            Elements.Add(new Element(Category.OfElement.Nb));
            Elements.Add(new Element(Category.OfElement.Nb));
            Elements.Add(new Element(Category.OfElement.Ni));
            Elements.Add(new Element(Category.OfElement.Ti));
            Elements.Add(new Element(Category.OfElement.Al));
            Elements.Add(new Element(Category.OfElement.V));
            Elements.Add(new Element(Category.OfElement.Cu));

        }

        public Element GetElement(Category.OfElement requestedElement)
        {
            var singleElement = this.Elements.First(x => x.Name == requestedElement);
            return singleElement;
        }
    }
}
