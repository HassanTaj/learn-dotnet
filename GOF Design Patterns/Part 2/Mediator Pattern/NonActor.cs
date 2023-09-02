using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator_Pattern {
    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class NonActor : Participant {
        public NonActor(string name) : base(name) {
        }
        public override void Recieve(string from, string message) {
            Console.WriteLine("To a non-Actor: ");
            base.Recieve(from, message);
        }
    }
}
