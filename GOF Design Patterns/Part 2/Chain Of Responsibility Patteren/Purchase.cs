using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility_Patteren {
    class Purchase {

        private int _number;
        private double _amount;
        private string _purpose;

        // constructor 
        public Purchase(int number, double amount, string purpose) {
            this._number = number;
            this._amount = amount;
            this._purpose = purpose;
        }

        public int Number {
            get { return _number; }
            set { _number = value; }
        }

        public double Amount {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Purpose {
            get { return _purpose; }
            set { _purpose = value; }
        }

      
    }
}
