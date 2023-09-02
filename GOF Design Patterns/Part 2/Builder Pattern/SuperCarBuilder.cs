using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern {
    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    public class SuperCarBuilder : CarBuilder {
        public override void SetHorsePower() {
            _car.HorsePower = 1640;
        }

        public override void SetImpressiveFeature() {
            _car.MostIMpressiveFeature = "Can Fly";
        }

        public override void SetTopSpeed() {
            _car.TopSpeedMPH = 600;
        }
    }
}
