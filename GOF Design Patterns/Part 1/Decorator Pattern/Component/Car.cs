using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern.Component {
    // Component
    public abstract class Car {
        public string Discription { get; set; }
        public abstract string GetDescription();
        public abstract double GetCarPrice();
    }
}