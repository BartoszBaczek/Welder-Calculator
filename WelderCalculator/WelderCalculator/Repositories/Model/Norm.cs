 using System;
 using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WelderCalculator.Model
{
    public abstract class Norm
    {
        public string Name { get; set; }

        public Guid GuidNumber { get; set; }

        protected Norm()
        {
            Name = string.Empty;
            GuidNumber = Guid.NewGuid();
        }
    }
}
