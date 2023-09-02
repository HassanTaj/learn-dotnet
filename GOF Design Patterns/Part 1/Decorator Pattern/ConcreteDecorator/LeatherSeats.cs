using Decorator_Pattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator_Pattern.Component;

namespace Decorator_Pattern.ConcreteDecorator {
    public class LeatherSeats :CarDecorator {
  
        public LeatherSeats(Car car) : base(car) {
            Discription = "Leather Seats";
        }
        public override string GetDescription() =>
            $"{_car.GetDescription()}, {Discription}";
        public override double GetCarPrice() =>
              _car.GetCarPrice() + 3000;

    }
}