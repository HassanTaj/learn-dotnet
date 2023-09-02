using Abstract_Factory.Abstract_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory.Concrete_Products {
    // Concrete ProductA1
    public class CitiSavingsAccount : ISavingsAccount {
        public CitiSavingsAccount() {
            Console.WriteLine("Returned Citi savings account");
        }
    }
}
