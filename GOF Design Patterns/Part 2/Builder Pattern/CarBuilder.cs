using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern {
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    public abstract class CarBuilder {
        protected readonly Car _car = new Car();
        public abstract void SetHorsePower();
        public abstract void SetTopSpeed();
        public abstract void SetImpressiveFeature();

        public virtual Car GetCar() {
            return _car;
        }
    }
}
