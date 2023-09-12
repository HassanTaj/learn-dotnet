using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7_Complex_Classes {
    class abstractDrivedSubclass : myAbstractClass {
        public override int myMethod(int arg1, int arg2) {
            return arg1 + arg2;
        }
    }
}
