using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composit_Pattern {
    class Program {
        /// <summary>
        /// 'Client'
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {

            Employee ricky = new Employee { EmployeeID = 1, Name = "Ricky", Rating = 3 };
            Employee mike = new Employee { EmployeeID = 2, Name = "mike", Rating = 4 };
            Employee vike = new Employee { EmployeeID = 3, Name = "vike", Rating = 4 };
            Employee liky = new Employee { EmployeeID = 4, Name = "liky", Rating = 4 };

            Supervisor ronny = new Supervisor { EmployeeID=7,Name="Ronny",Rating=3};
            Supervisor bob = new Supervisor { EmployeeID = 8, Name = "bob", Rating = 3 };

            ronny.AddSubordinate(ricky);
            ronny.AddSubordinate(vike);
            ronny.AddSubordinate(mike);

            bob.AddSubordinate(liky);

            Console.WriteLine($"\n--------------Employee can see their Performance Summary ---------");

            ricky.PerformanceSummary();

            Console.WriteLine($"\n--------------Supervisors can also see their Subordinates Performance Summary ---------");

            Console.WriteLine("\n subordinates performance record");
            foreach (var emp in ronny.ListSubordinates) {
                emp.PerformanceSummary();
            }
        }
    }
}