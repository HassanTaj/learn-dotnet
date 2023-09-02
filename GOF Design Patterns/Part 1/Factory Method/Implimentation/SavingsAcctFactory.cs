using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Implimentation {

    // concrete Creator
    public class SavingsAcctFactory : ICreditUnionFactory  {
        public ISavingsAccount GetSavingsAccount(string acctNo) {
            if (acctNo.Contains("CITI")) {
                return new CitiSavingAcct();
            }
            else if (acctNo.Contains("NATIONAL")) {
                return new NationalSavingAcct();
            }
            else {
                throw new ArgumentException("Invalid Account Number");
            }

        }
    }
}
