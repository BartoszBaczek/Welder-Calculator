using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace WelderCalculator.Model
{   
    public class Element
    {
        public Category.OfElement Name { get; set; }

        public string FullName { get; set; }

        public double? Min { get; set; }            //value must be 0 - 100%

        public double? Max { get; set; }            //value must be 0 - 100%

        private double? _realValue;
        public double? RealValue 
        { 
            get
            {
                if (_realValue.HasValue)
                    return _realValue;
                else
                    return Min/2.0 + Max/2.0;
            }
            set { _realValue = value; }
        }

        public Element(Category.OfElement name)
        {
            Name = name;
            switch (name)
            {
                case Category.OfElement.C :
                    FullName = "Węgiel";
                    break;
                case Category.OfElement.Si :
                    FullName = "Krzem";
                    break;
                case Category.OfElement.Mn :
                    FullName = "Mangan";
                    break;
                case Category.OfElement.P :
                    FullName = "Potas";
                    break;
                case Category.OfElement.S :
                    FullName = "Siarka";
                    break;
                case Category.OfElement.N :
                    FullName = "Azot";
                    break;
                case Category.OfElement.Cr :
                    FullName = "Chrom";
                    break;
                case Category.OfElement.Mo :
                    FullName = "Molibden";
                    break;
                case Category.OfElement.Nb :
                    FullName = "Nb";
                    break;
                case Category.OfElement.Ni :
                    FullName = "Nikiel";
                    break;
                case Category.OfElement.Ti :
                    FullName = "Tytan";
                    break;
                case Category.OfElement.Al :
                    FullName = "Aluminium";
                    break;
                case Category.OfElement.V :
                    FullName = "Wanad";
                    break;
                case Category.OfElement.Cu :
                    FullName = "Cu";
                    break;
                default :
                    new InvalidOperationException("Element's type is not implemented");
                    break;
            }
            Max = null;
            Min = null;
            RealValue = null;
        }
    }
}
