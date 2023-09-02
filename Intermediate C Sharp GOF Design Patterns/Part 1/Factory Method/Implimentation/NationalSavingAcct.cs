using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Implimentation {

    // concrete product
    public class NationalSavingAcct : ISavingsAccount {
        public NationalSavingAcct() {
            Balance = 2000;
        }
    }
}
