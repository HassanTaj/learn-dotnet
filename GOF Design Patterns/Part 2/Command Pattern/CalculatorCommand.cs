using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Pattern {
    /// <summary>
    /// The 'ConcreteCommand class
    /// </summary>
    class CalculatorCommand : Command {

        private char _operator;
        private int _operand;
        private Calculator _calculator;

        public CalculatorCommand(Calculator calculator, char @operator, int operand) {
            this._calculator = calculator;
            this._operand = operand;
            this._operator = @operator;
        }

        public char Operator {
            set { _operator = value; }
        }

        public int Operand {
            set { _operand = value; }
        }
        // execute new command
        public override void Execute() {
            _calculator.Operation(_operator, _operand);
        }
        // un execute command
        public override void UnExecute() {
            _calculator.Operation(Undo(_operator), _operand);
        }
        // returns opposite operator for given operator
        private char Undo(char @operator) {
            switch (@operator) {
                case '+': return '-';
                case '-': return '+';
                case '*': return '/';
                case '/': return '*';

                default:
                    throw new ArgumentException("@operator");
            }
        }

    }
}
