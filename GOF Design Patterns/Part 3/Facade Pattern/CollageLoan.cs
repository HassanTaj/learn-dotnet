using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern {
    class CollageLoan {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        public bool IsEligible(Student stud, int amount) {

            Console.WriteLine($"{stud.Name} applies for {{0:C}}", amount);
            bool eligible = true;

            // Verify creditworthyness of applicant
            if (!_bank.HasSufficientSavings(stud, amount)) {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(stud)) {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(stud)) {
                eligible = false;
            }
            return eligible;
        }
    }
}
