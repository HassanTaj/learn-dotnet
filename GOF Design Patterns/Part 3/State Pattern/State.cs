using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern {
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    abstract class State {
        protected Account account;
        protected double balance;

        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;

        public Account Account {
            get =>account;
            set => account=value;
        }
        public double Balance {
            get => balance;
            set => balance = value;
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }
}