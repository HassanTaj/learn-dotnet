using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern {
    /// <summary>
    /// The 'ConcreteBuilder' class
    /// </summary>
    public class LameCarBuilder : CarBuilder {
        public override void SetHorsePower() =>
            _car.HorsePower = 120;

        public override void SetImpressiveFeature() =>
            _car.TopSpeedMPH = 70;
        public override void SetTopSpeed() =>
            _car.MostIMpressiveFeature = "Has Air Conditioning";

    }
}