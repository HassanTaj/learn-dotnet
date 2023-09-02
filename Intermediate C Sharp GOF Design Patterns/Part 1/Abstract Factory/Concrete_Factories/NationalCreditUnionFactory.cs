using Abstract_Factory.Abstract_Products;
using Abstract_Factory.Concrete_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Concrete_Factories {

    // Concrete Factory 2
    public class NationalCreditUnionFactory : ICreditUnionFactory {
        public override ILoanAccount CreateLoanAccount() {
            NationalLoanAccount obj = new NationalLoanAccount();
            return obj;
        }
         
        public override ISavingsAccount CreateSavingsAccount() {
            NationalSavingsAccount obj = new NationalSavingsAccount();
            return obj;
        }
    }
}
