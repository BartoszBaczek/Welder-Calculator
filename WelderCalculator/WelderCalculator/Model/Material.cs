using System;
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

        public double? CEq 
        {
            get
            {
                double? cReal = GetElement(Category.OfElement.C).RealValue;
                double? mnReal = GetElement(Category.OfElement.Mn).RealValue;
                double? crReal = GetElement(Category.OfElement.Cr).RealValue;
                double? vReal = GetElement(Category.OfElement.V).RealValue;
                double? moReal = GetElement(Category.OfElement.Mo).RealValue;
                double? niReal = GetElement(Category.OfElement.Ni).RealValue;
                double? cuReal = GetElement(Category.OfElement.Cu).RealValue;

                double? carbonEquivalent = cReal +
                                           mnReal/6.0 +
                                           (crReal + vReal + moReal)/5.0 +
                                           (niReal + cuReal)/15.0;

                return carbonEquivalent;
            }
        }

        public double? NiEq
        {
            get
            {
                double? niReal = GetElement(Category.OfElement.Ni).RealValue;
                double? cReal = GetElement(Category.OfElement.C).RealValue;
                double? nReal = GetElement(Category.OfElement.N).RealValue;
                double? mnReal = GetElement(Category.OfElement.Mn).RealValue;

                double? nickielEquivalent = niReal +
                                            (cReal + nReal)*30.0 +
                                            mnReal*0.5;

                return nickielEquivalent;
            }
        }

        public double? CrEq
        {
            get
            {
                double? crReal = GetElement(Category.OfElement.Cr).RealValue;
                double? moReal = GetElement(Category.OfElement.Mo).RealValue;
                double? siReal = GetElement(Category.OfElement.Si).RealValue;
                double? nbReal = GetElement(Category.OfElement.Nb).RealValue;
                double? tiReal = GetElement(Category.OfElement.Ti).RealValue;

                double? chromeEquivalent = crReal +
                                           moReal +
                                           siReal*1.5 +
                                           nbReal*0.5 +
                                           tiReal*2;

                return chromeEquivalent;
            }
        }

        public Guid GuidNumber { get; set; }

        public Material()
        {
            Name = string.Empty;
            Number = string.Empty;
            Elements = new List<Element>();
            GuidNumber = Guid.NewGuid();
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

        public bool Equals(Material material)
        {
            if (this.Name != material.Name)
                return false;
            if (this.Number != material.Number)
                return false;

            foreach (var thatElement in material.Elements)
            {
                var thisElement = this.Elements.First(x => x.Name == thatElement.Name);
                if (thisElement.Min != thatElement.Min || thisElement.Max != thatElement.Max || thisElement.RealValue != thatElement.RealValue)
                    return false;
            }

            return true;
        }
    }
}
