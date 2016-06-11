using System.Linq;

namespace WelderCalculator.Model
{
    public class BaseMaterial : Material
    {
        public string Number { get; set; }

        public BaseMaterial() : base()
        {
            Number = string.Empty;
        }
        public override void CreateBasicListOfElements()
        {
            Elements.Add(new Element(Category.OfElement.C));
            Elements.Add(new Element(Category.OfElement.Si));
            Elements.Add(new Element(Category.OfElement.Mn));
            Elements.Add(new Element(Category.OfElement.P));
            Elements.Add(new Element(Category.OfElement.S));
            Elements.Add(new Element(Category.OfElement.Cr));
            Elements.Add(new Element(Category.OfElement.Ni));
            Elements.Add(new Element(Category.OfElement.Mo));
            Elements.Add(new Element(Category.OfElement.N));
            Elements.Add(new Element(Category.OfElement.Cu));
            Elements.Add(new Element(Category.OfElement.Nb));
            Elements.Add(new Element(Category.OfElement.Ti));
            Elements.Add(new Element(Category.OfElement.V));
            Elements.Add(new Element(Category.OfElement.Al));
        }

        public override bool Equals(Material material)
        {
            var newTypeMaterial = material as BaseMaterial;

            if (this.Name != newTypeMaterial.Name)
                return false;
            if (this.Number != newTypeMaterial.Number)
                return false;
            if (this.Elements.Count != newTypeMaterial.Elements.Count)
                return false;

            foreach (var thatElement in newTypeMaterial.Elements)
            {
                var thisElement = this.Elements.First(x => x.Name == thatElement.Name);
                if (thisElement.Min != thatElement.Min || thisElement.Max != thatElement.Max || thisElement.RealValue != thatElement.RealValue)
                    return false;
            }

            return true;
        }
    }
}
