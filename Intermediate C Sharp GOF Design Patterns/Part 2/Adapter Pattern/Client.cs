using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Pattern {
    /// <summary>
    /// 'Client' class
    /// </summary>
    class Client {
        static void Main(string[] args) {

            Console.WriteLine($"Employee list form 3rd party org system.");
            Console.WriteLine($"----------------------------------------");

            // Client will use Itarget interface to call functionality of
            // Adaptee class i.e. ThirdPartyEmployee

            ITarget adapter = new EmployeeAdapter();
            foreach (var employee in adapter.GetEmployees()) {
                Console.WriteLine($"Employee Name : {employee}");
            }

            Console.ReadKey();
        }
    }
}