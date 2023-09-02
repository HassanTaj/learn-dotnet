using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Pattern {
    /// <summary>
    /// The 'Receiever' class
    /// </summary>
    class Calculator {
        private int _curr = 0;
        public void Operation(char @operator,int operand) {
            switch (@operator) {
                case '+': _curr += operand; break;
                case '-': _curr -= operand; break;
                case '*': _curr *= operand; break;
                case '/': _curr /= operand; break;
            }
            Console.WriteLine($"Current value = {_curr} (following {@operator} {operand})");
        }
    }
}
