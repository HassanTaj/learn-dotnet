using Abstract_Factory.Abstract_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Concrete_Products {
    // Concrete ProductB1
    public class CitiLoanAccount:ILoanAccount {
        public CitiLoanAccount() {
            Console.WriteLine("Returned Citi Loan Account");
        }
    }
}
