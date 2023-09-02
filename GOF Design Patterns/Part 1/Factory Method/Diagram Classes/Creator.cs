using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Diagram_Classes {
    abstract class Creator {

        public Product Product { get; set; }

        public abstract Product FactoryMethod();

        public Creator() {
            Product = FactoryMethod();
        }

    }
}
