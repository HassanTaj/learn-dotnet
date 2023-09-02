using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Implimentation {

    // concrete Product
    public class CitiSavingAcct : ISavingsAccount {
        public CitiSavingAcct() {
            Balance = 5000;
        }
    }
}
