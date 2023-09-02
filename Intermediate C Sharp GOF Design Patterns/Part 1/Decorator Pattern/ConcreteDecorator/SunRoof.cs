using Decorator_Pattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator_Pattern.Component;

namespace Decorator_Pattern.ConcreteDecorator {
    public class SunRoof : CarDecorator {
        public SunRoof(Car car) : base(car) {
            Discription = "SunRoof";
        }
        public override double GetCarPrice() {
            return base.GetCarPrice() + 30000;
        }

        public override string GetDescription() {
            return base.GetDescription() + $", {Discription}";
        }
    }
}