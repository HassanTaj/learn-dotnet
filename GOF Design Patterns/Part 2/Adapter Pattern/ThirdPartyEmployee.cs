using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Pattern {
    /// <summary>
    /// 'Adaptee' class
    /// </summary>
    public class ThirdPartyEmployee {

        public List<string> GetEmployeeList() {
            List<string> EmployeeList = new List<string> {
                "Peter",
                "Parker",
                "Paul",
                "Jin",
            };
            return EmployeeList;
        }
    }
}
