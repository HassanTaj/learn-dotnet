using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Pattern {
    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    class User {
        // initilizers
        private Calculator _calculator = new Calculator();
        private List<Command> _commands = new List<Command>();
        private int _current = 0;

        public void Redo(int levels) {
            Console.WriteLine($"---- Redo {levels} levels");
            // preform redo operations
            for (int i = 0; i < levels; i++) {
                if (_current < _commands.Count - 1) {
                    Command cmd = _commands[_current++] as CalculatorCommand;
                    cmd.Execute();
                }
            }
        }
        public void Undo(int levels) {
            Console.WriteLine($"---- Undo {levels} levels");
            // preform undo operations
            for (int i = 0; i < levels; i++) {
                if (_current > 0) {
                    Command cmd = _commands[--_current] as CalculatorCommand ;
                    cmd.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand) {
            // create command operation and execute it
            Command command = new CalculatorCommand(_calculator, @operator, operand);
            command.Execute();
            // add command to undo list
            _commands.Add(command);
            _current++;
        }
    }
}
