using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Pattern {
    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Account {

        private State _state;
        private string _owner;


        public Account(string owner) {
            this._owner = owner;
            this._state = new StandardState(0.0, this);
        }

        public double Balance { get => this._state.Balance; }

        public State State { get => this._state; set=> this._state = value; }

        public void Deposit(double amount) {
            this._state.Deposit(amount);
            Console.WriteLine("Deposited {0:C} ---",amount);
            Console.WriteLine("Balance = {0:C}", this.Balance);
            Console.WriteLine("States = {0:C}", this.State.GetType().Name);
            Console.WriteLine("");

        }
        public void WithDraw(double amount) {
            this._state.Withdraw(amount);
            Console.WriteLine("Withdraw {0:C} ---", amount);
            Console.WriteLine("Balance = {0:C}", this.Balance);
            Console.WriteLine("States = {0:C}", this.State.GetType().Name);
            Console.WriteLine("");
        }

        public void PayInterest() {
            this._state.PayInterest();
            Console.WriteLine("Interest Paid");
            Console.WriteLine("Balance = {0:C}", this.Balance);
            Console.WriteLine("States = {0:C}", this.State.GetType().Name);
            Console.WriteLine("");

        }

    }
}
