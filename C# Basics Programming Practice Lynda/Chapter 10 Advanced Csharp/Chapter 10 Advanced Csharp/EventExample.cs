using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_10_Advanced_Csharp {
	
    class EventExample {


        public event myEventHandler valueChanged;

        public string Val {
            set {
                this.theValue = value;
                this.valueChanged(theValue);
            }
         }

    }
}
