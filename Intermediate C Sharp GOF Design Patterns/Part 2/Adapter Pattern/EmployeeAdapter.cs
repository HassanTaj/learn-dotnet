using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Pattern {
    /// <summary>
    /// 'Adapter' class
    /// </summary>
    public class EmployeeAdapter : ThirdPartyEmployee, ITarget {
        public List<string> GetEmployees() {
            return GetEmployeeList();
        }
    }
}
