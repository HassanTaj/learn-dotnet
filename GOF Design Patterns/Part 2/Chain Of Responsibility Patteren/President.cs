using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility_Patteren {
    /// <summary>
    /// yet another 'Concrete handler'
    /// </summary>
    class President : Approver {
        public override void ProcessRequest(Purchase purchase) {
            if (purchase.Amount < 100000.0) {
                Console.WriteLine($"{this.GetType().Name} Approved request # {purchase.Number}");
            }
            else {
                Console.WriteLine($"Request# {purchase.Number} requires an executive meeting!");
            }
        }
    }
}
