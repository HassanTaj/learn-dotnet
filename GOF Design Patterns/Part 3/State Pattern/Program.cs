using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern {
    class Program {
        static void Main(string[] args) {

            // Open a new account
            Account account = new Account("Lee Haisen");

            // Apply transactions
            account.Deposit(490.0);
            account.Deposit(390.0);
            account.Deposit(540.0);
            account.PayInterest();


            // withdraw 
            account.WithDraw(2200.0);
            account.WithDraw(1300.0);

            Console.ReadKey();
        }
    }
}