using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Pattern {
    /// <summary>
    /// The  'ConcreteVisitor' class
    /// </summary>
    class IncomeVisitor : IVisitor {
        public void Visit(Element element) {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine($"{employee.GetType().Name} {employee.Name}'s new income: {{0:C}}",employee.Income);
        }
    }
}
