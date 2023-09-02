using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern {
    /// <summary>
    /// A 'ConceretState' class
    /// 
    /// Standard indicates a non-interest bearing state
    /// </summary>
    class StandardState : State {
        public StandardState(State state) : this(state.Balance, state.Account) {

        }
        public StandardState(double balance, Account account) {
            this.balance = balance;
            this.account = account;
            Initialize();
        }
        private void Initialize() {
            interest = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }
        public override void Deposit(double amount) {
            balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest() {
            balance += interest * balance;
            StateChangeCheck();
        }

        public override void Withdraw(double amount) {
            balance -= amount;
            StateChangeCheck();
        }

        public void StateChangeCheck() {
            if (balance < lowerLimit) {
                account.State = new OverdrawState(this);
            }
            else if (balance > upperLimit) {
                account.State = new PremiumState(this);
            }
        }
    }
}
