using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelderCalculator.Model;

namespace WelderCalculator.Repositories.Model
{
    public class AdditiveMaterial : Material
    {
        public string NominalCompositionName { get { return Name; } set { Name = value; } }

        public string AlloyTypeName { get; set; }

        public AdditiveMaterial() : base()
        {
            NominalCompositionName = string.Empty;
            AlloyTypeName = string.Empty;
        }

        public override bool Equals(Material material)
        {
            var newTypeMaterial = material as AdditiveMaterial;
            if (this.NominalCompositionName != newTypeMaterial.NominalCompositionName)
                return false;
            if (this.AlloyTypeName != newTypeMaterial.AlloyTypeName)
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
            //ZMIENIC 
        }
    }
}
