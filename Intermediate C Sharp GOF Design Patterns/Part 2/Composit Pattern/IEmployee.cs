using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composit_Pattern {
    /// <summary>
    /// 'IComponent' interface
    /// </summary>
    public interface IEmployee {
        int EmployeeID { get; set; }
        string Name { get; set; }
        int Rating { get; set; }
        void PerformanceSummary();
    }
}
