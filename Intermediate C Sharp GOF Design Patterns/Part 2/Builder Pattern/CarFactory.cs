using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern {
    /// <summary>
    /// The 'Director' class
    /// </summary>
    public class CarFactory {
        public Car Build(CarBuilder builder) {
            builder.SetHorsePower();
            builder.SetTopSpeed();
            builder.SetImpressiveFeature();
            return builder.GetCar();
        }
    }
}
