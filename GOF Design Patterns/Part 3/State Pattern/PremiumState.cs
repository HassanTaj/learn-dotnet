using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern {
    /// <summary>
    /// A 'ConcreteState' class
    /// 
    /// Premium indicates an interest breaking state
    /// </summary>
    class PremiumState : State {
        public PremiumState(State state) : this(state.Balance, state.Account) {

        }
        public PremiumState(double balance, Account account) {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize() {
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
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

        private void StateChangeCheck() {
            if (balance < 0.0) {
                account.State = new OverdrawState(this);
            }
            else if (balance < lowerLimit) {
                account.State = new StandardState(this);
            }
        }
    }
}
