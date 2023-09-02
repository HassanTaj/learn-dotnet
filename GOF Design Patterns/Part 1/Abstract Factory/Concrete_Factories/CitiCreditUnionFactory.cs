using Abstract_Factory.Abstract_Products;
using Abstract_Factory.Concrete_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Concrete_Factories {
    // Concrete Factory 1
    public class CitiCreditUnionFactory : ICreditUnionFactory {
        public override ILoanAccount CreateLoanAccount() {
            CitiLoanAccount obj = new CitiLoanAccount();
            return obj;
        }

        public override ISavingsAccount CreateSavingsAccount() {
            CitiSavingsAccount obj = new CitiSavingsAccount();
            return obj;
        }
    }
}