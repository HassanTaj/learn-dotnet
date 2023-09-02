using Abstract_Factory.Abstract_Products;
using Abstract_Factory.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory {
    class Program {
        static void Main(string[] args) {

            List<string> acctnos = new List<string> {
                "CITI-123",
                "NATIONAL-456",
                "CHASE-222",
            };
            for (int i = 0; i < acctnos.Count; i++) {
                ICreditUnionFactory anAbstractFactory =
                    CreditUnionFactoryProvider.GetCreditUnionFactory(acctnos[i]);
                if (anAbstractFactory ==null) {
                    Console.WriteLine($"Sorry this credit union w/ account number {acctnos[i]} is invalid");
                }
                else {
                    ILoanAccount loan = anAbstractFactory.CreateLoanAccount();
                    ISavingsAccount savings = anAbstractFactory.CreateSavingsAccount();
                }
            }

            Console.ReadKey();
        }
    }
}