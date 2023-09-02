
using Factory_Method.Implimentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method {
    class Program {
        static void Main(string[] args) {
            var factory = new SavingsAcctFactory() as ICreditUnionFactory;

            //ISavingsAccount acct = new CitiSavingAcct();

            var account = factory.GetSavingsAccount("CITI-123");
            var nationalacct = factory.GetSavingsAccount("NATIONAL-123");
            //var citiacct = factory.GetSavingsAccount("CITI-123");
            Console.WriteLine($"{account.Balance}");
            //Console.WriteLine($"my citi balance is  {citiacct.Balance} and national balance is {nationalacct.Balance}");

            Console.ReadKey();
        }
    }
}
