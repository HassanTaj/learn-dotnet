using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern {
    /// <summary>
    /// A 'ConceretState' class
    ///  Overdrawn indicates that account is overdrawn
    /// </summary>
    class OverdrawState : State {
        private double _serviceFee;

        public OverdrawState(State state) {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }
        private void Initialize() {
            // should come from datasource
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            _serviceFee = 15.00;
        }
        public override void Deposit(double amount) {
            balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest() {
           // no interests is paid
        }

        public override void Withdraw(double amount) {
            amount = amount - _serviceFee;
            Console.WriteLine("No Funds avaiable for withdrawal!");

            // disable withdrawn functionality
        }

        private void StateChangeCheck() {
            if (balance > upperLimit) {
                account.State = new StandardState(this);
            }
        }

    }
}
