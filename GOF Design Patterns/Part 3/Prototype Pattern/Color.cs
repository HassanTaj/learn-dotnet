using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern {
    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    class Color : ColorPrototype {

        private int _yellow;

        public int Yellow {
            get { return _yellow; }
            set { _yellow = value; }
        }
        private int _orange;

        public int Orange {
            get { return _orange; }
            set { _orange = value; }
        }
        private int _purple;

        public int Purple {
            get { return _purple; }
            set { _purple = value; }
        }


        public Color(int yellow, int orange, int purple) {
            _yellow = yellow;
            _orange = orange;
            _purple = purple;
        }


        // creat a shallow copy
        public override ColorPrototype Clone() {
            Console.WriteLine("RGB color is cloned to: {0,3},{1,3},{2,3}",_yellow,_orange,_purple);

            return this.MemberwiseClone() as ColorPrototype;
        }
    }
}
