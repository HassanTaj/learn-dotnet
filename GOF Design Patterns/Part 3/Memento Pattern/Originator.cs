using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momento_Pattern {
    class Originator {

        private String statement;

        // sets value for the statement
        public void set(String newStatement) {
            Console.WriteLine("----");
            Console.WriteLine($"From Orginiator: Current version of statement \n{newStatement}\n");
            this.statement = newStatement;
        }

        // Creates a new Memento with a new statement
        public Memento StoreInMemento() {
            Console.WriteLine("From Originator: saving to memento");
            return new Memento(statement);
        }

        // Gets the statement currently sored in memento 
        public String RestoreFromMemento(Memento memento) {
            statement = memento.GetState();
            Console.WriteLine("From Originator: Previous Saved Statement in Memento ");

            return statement;
        }
    }
}
