using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7_Complex_Classes {
    public struct Point {

        private int xCoord;
        private int yCoord;

        public Point(int x,int y) {
            xCoord = x;
            yCoord = y;
        }

        public int x {
            get { return xCoord; }
            set { xCoord = value; }
        }

        public int y {
            get { return xCoord; }
            set { xCoord = value; }
        }
    }
}
