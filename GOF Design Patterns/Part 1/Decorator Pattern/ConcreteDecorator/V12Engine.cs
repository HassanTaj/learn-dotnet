using Decorator_Pattern.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator_Pattern.Component;

namespace Decorator_Pattern.ConcreteDecorator {
    public class V12Engine : CarDecorator {
        public V12Engine(Car car) : base(car) {
            Discription = "V12 Engine";
        }

        public override double GetCarPrice() {
            return base.GetCarPrice() +200000;
        }

        public override string GetDescription() {
            return base.GetDescription()+$", {Discription}";
        }
    }
}