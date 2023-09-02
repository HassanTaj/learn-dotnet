using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility_Patteren {
    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    class Director : Approver {
        public override void ProcessRequest(Purchase purchase) {
            if (purchase.Amount < 10000.0) {
                Console.WriteLine($"{this.GetType().Name} Approved request # {purchase.Number}");
            }
            else if (successor != null) {
                successor.ProcessRequest(purchase); 
            }
        }
    }
}
