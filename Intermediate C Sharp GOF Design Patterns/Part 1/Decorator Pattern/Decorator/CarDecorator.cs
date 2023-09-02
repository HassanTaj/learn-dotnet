using Decorator_Pattern.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern.Decorator {
    public class CarDecorator : Car {
        protected Car _car;
        public CarDecorator(Car car) {
            _car = car;
        }
        // using expression bodied functions
        public override double GetCarPrice() =>
            _car.GetCarPrice();
        public override string GetDescription() =>
            _car.GetDescription();
    }
}
