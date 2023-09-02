using Decorator_Pattern.Component;
using Decorator_Pattern.ConcreteComponent;
using Decorator_Pattern.ConcreteDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator_Pattern {
    class Program {
        static void Main(string[] args) {
            //Car car = new NormalCar();
            Car car = new SportsCar();
            //car = new LeatherSeats(car);
            //car = new V12Engine(car);
            //car = new SunRoof(car);

            Console.WriteLine($"Discription : {car.GetDescription()}\n" +
                $"Price : {car.GetCarPrice():C2}");

            Console.ReadKey();
        }
    }
}