using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelderCalculator.Model
{
    public class FormComboBox
    {
        public FormComboBox(List<string> avalibleElements, int currentIndex)
        {
            AvalibleElements = avalibleElements;
            CurrentIndex = currentIndex;
        }

        public List<string> AvalibleElements;
        public int CurrentIndex;
    }
}
