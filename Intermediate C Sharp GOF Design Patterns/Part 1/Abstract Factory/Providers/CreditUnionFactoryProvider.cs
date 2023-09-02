using Abstract_Factory.Concrete_Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Providers {
    public class CreditUnionFactoryProvider {
        public static ICreditUnionFactory GetCreditUnionFactory(string acctNo) {
            if (acctNo.Contains("CITI")) {
                return new CitiCreditUnionFactory();
            }
            else if (acctNo.Contains("NATIONAL")) {
                return new NationalCreditUnionFactory();
            }
            else
                return null;
        }
    }
}
