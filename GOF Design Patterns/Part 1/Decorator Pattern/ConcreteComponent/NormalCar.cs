using Decorator_Pattern.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern.ConcreteComponent {
    // Concrete Component 
    public class NormalCar : Car {

        public NormalCar() {
            Discription = "Normal Car";
        }

        public override double GetCarPrice() {
            return 500000;
        }

        // expression bodied function
        public override string GetDescription() => Discription; 
    }
}
