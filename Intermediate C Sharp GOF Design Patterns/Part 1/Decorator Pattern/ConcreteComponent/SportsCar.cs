using Decorator_Pattern.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern.ConcreteComponent {
    public class SportsCar : Car {
        public SportsCar() {
            Discription = "Sports Car";
        }
        public override double GetCarPrice() => 4000000;
        public override string GetDescription() => Discription;
    }
}