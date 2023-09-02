using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Pattern {
    /// <summary>
    /// The  'ConcreteVisitor' class
    /// </summary>
    class VacationVisitor : IVisitor {
        public void Visit(Element element) {
            Employee employee = element as Employee;

            // provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine($"{employee.GetType().Name} {employee.Name}'s new vacation days: {employee.VacationDays}");

        }
    }
}
