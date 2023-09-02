using Abstract_Factory.Abstract_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Concrete_Products {
    // Concrete Product B2
    public class NationalSavingsAccount : ISavingsAccount {
        public NationalSavingsAccount() {
            Console.WriteLine("Returned National Savings Account");
        }
    }
}
