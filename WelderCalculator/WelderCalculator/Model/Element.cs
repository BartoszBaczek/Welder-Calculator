using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace WelderCalculator.Model
{   
    public class Element
    {
        public Type.OfElement Name { get; set; }

        public string FullName { get; set; }

        public double? Min { get; set; }            //value must be 0 - 100%

        public double? Max { get; set; }            //value must be 0 - 100%

        public double? RealValue { get; set; }      //value must be 0 - 100%

        public Element(Type.OfElement name)
        {
            Name = name;
            switch (name)
            {
                case Type.OfElement.C :
                    FullName = "Węgiel";
                    break;
                case Type.OfElement.Si :
                    FullName = "Krzem";
                    break;
                case Type.OfElement.Mn :
                    FullName = "Mangan";
                    break;
                case Type.OfElement.P :
                    FullName = "Potas";
                    break;
                case Type.OfElement.S :
                    FullName = "Siarka";
                    break;
                case Type.OfElement.N :
                    FullName = "Azot";
                    break;
                case Type.OfElement.Cr :
                    FullName = "Chrom";
                    break;
                case Type.OfElement.Mo :
                    FullName = "Molibden";
                    break;
                case Type.OfElement.Nb :
                    FullName = "Nb";
                    break;
                case Type.OfElement.Ni :
                    FullName = "Nikiel";
                    break;
                case Type.OfElement.Ti :
                    FullName = "Tytan";
                    break;
                case Type.OfElement.Al :
                    FullName = "Aluminium";
                    break;
                case Type.OfElement.V :
                    FullName = "Wanad";
                    break;
                case Type.OfElement.Cu :
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
