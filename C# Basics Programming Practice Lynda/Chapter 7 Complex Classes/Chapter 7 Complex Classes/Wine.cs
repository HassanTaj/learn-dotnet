using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7_Complex_Classes {

        /// <summary>
        ///                          Overloading Methods 
        ///                in this method there are constructor methods
        /// </summary>
    class Wine {
        public int Year;
        public string Name;
        public decimal price;

        public Wine(string s) {
            Name = s;
        }
        public Wine(string s, int y) {
            Name = s;
            Year = y;
        }
        public Wine(string s, decimal p, int y) {
            Name = s;
            price = p;
            Year = y;
        }
    }
}
