using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composit_Pattern {
    /// <summary>
    /// 'Leaf' class- will be leaf node in tree structure
    /// </summary>
    public class Employee : IEmployee {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public void PerformanceSummary() {
            Console.WriteLine($"\n Preformance summary of employee: {Name} is {Rating} out of 5");
        }
    }
}
