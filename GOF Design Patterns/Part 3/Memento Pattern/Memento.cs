using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momento_Pattern {
    class Memento {
        // The statement stored in memento object
        private String statement;

        // Save a new statement String to the momento object
        public Memento(String statementSave) {
            statement = statementSave;
        }

        // Return the value stored in statement
        public String GetState() {
            return statement;
        }
    }
}
