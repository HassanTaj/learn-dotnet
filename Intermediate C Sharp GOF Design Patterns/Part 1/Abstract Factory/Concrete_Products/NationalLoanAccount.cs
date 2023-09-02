using Abstract_Factory.Abstract_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Concrete_Products {
    // Concrete Product A2
    public class NationalLoanAccount : ILoanAccount {
        public NationalLoanAccount() {
            Console.WriteLine("Returned National Loan Account");
        }
    }
}
