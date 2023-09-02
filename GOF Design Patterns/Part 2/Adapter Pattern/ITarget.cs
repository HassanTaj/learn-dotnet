using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Pattern {
    /// <summary>
    /// 'ITarget' interface
    /// </summary>
    interface ITarget {
        List<string> GetEmployees();
    }
}
