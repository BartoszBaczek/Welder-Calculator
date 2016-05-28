using System;
using System.Collections.Generic;
using System.Linq;

namespace WelderCalculator.Model
{
    public abstract class Material
    {
        public string Name { get; set; }

        public Guid GuidNumber { get; set; }

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
                                           mnReal / 6.0 +
                                           (crReal + vReal + moReal) / 5.0 +
                                           (niReal + cuReal) / 15.0;

                return carbonEquivalent;
            }
        }

        public double? NiEqSchaeffler
        {
            get
            {
                double? niReal = GetElement(Category.OfElement.Ni).RealValue;
                double? cReal = GetElement(Category.OfElement.C).RealValue;
                double? nReal = GetElement(Category.OfElement.N).RealValue;
                double? mnReal = GetElement(Category.OfElement.Mn).RealValue;

                double? nickielEquivalent = niReal +
                                            (cReal + nReal) * 30.0 +
                                            mnReal * 0.5;

                return nickielEquivalent;
            }
        }

        public double? CrEqSchaeffler
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
                                           siReal * 1.5 +
                                           nbReal * 0.5 +
                                           tiReal * 2;

                return chromeEquivalent;
            }
        }


        protected Material()
        {
            Name = string.Empty;
            Elements = new List<Element>();
            GuidNumber = Guid.NewGuid();
        }


        public Element GetElement(Category.OfElement requestedElement)
        {
            var singleElement = this.Elements.First(x => x.Name == requestedElement);
            return singleElement;
        }

        public abstract bool Equals(Material material);
        public abstract void CreateBasicListOfElements();

    }
}
