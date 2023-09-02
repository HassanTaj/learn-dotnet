using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Diagram_Classes { 
    class ConcreteCreator : Creator {

        // returns a new concrete product
        public override Product FactoryMethod() {
            return new ConcreteProduct();
        }
    }
}
