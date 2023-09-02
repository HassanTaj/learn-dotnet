using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern {
    class Program {
        static void Main(string[] args) {

            ColorController colorController = new ColorController();

            // Initialize with standard colors
            colorController["yellow"] = new Color(255, 255, 0);
            colorController["orange"] = new Color(255, 128, 0);
            colorController["purple"] = new Color(128, 0, 255);

            // User adds personalized colors
            colorController["fuck"] = new Color(255, 54, 0);
            colorController["tasty"] = new Color(255, 153, 51);
            colorController["rainy"] = new Color(100, 123, 1);

            // User clones selected colors
            Color c1 = colorController["yellow"].Clone() as Color;
            Color c2 = colorController["orange"].Clone() as Color;
            Color c3 = colorController["rainy"].Clone() as Color;

            Console.ReadKey();
        }
    }
}