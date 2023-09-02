using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composit_Pattern {
    /// <summary>
    /// 'Composite' class- will be branch node in tree structure
    /// </summary>
    public class Supervisor:IEmployee {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public List<IEmployee> ListSubordinates = new List<IEmployee>();

        public void PerformanceSummary() {
            Console.WriteLine($"\n Preformance summary of employee: {Name} is {Rating} out of 5");
        }

        public void AddSubordinate(IEmployee employee) {
            ListSubordinates.Add(employee);
        }     
    }
}