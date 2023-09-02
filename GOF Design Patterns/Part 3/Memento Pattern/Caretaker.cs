using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momento_Pattern {
    class Caretaker {

        // where all mementos are saved

        List<Memento> savedStatements = new List<Memento>();

        // Adds memento to the collection
        public void AddMemento(Memento m) {
            savedStatements.Add(m);
        }

        // Gets the memento requested from the collection
        public Memento GetMemento(int index) {
            if (index > -1) {
                return savedStatements[index];
            }
            else {
                return new Memento(string.Empty);
            }
        }

    }
}
