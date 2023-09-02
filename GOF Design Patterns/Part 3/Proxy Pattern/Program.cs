using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Pattern {
    class Program {
        static void Main(string[] args) {

            // create math proxy
            CalculateProxy proxy = new CalculateProxy();

            // do math
            Console.WriteLine("Calsulations");

            Console.WriteLine("-------------");
            Console.WriteLine(
                $"1+1={proxy.Add(1,1)}" +
                $"\n2-1={proxy.Sub(2,1)}" +
                $"\n2*1={proxy.Multiply(2,1)}" +
                $"\n4/2={proxy.Divide(4,1)}"
                );

        }
    }
}
