using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattren {
    class Program {
        static void Main(string[] args) {
            //var pol =new Policy();
            //var insuredName = pol.GetInsuredName();
            var insuredName = Policy.Instance.GetInsuredName();

            Console.WriteLine(insuredName);

            Console.ReadKey();
        }
    }
}
