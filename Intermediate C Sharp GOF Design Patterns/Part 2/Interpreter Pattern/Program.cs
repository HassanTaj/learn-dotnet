using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Pattern {
    /// <summary>
    /// The 'Interpreter pattern'
    /// </summary>
    class Program {
        static void Main(string[] args) {
            string roman = "MMXVII";
            Context context = new Context(roman);

            // build the 'parse tree'
            List<Expression> tree = new List<Expression>() {
                new ThousandExpression(),
                new HundredExpression(),
                new TenExpression(),
                new OneExpression(),
            };

            // interpret
            foreach (var exp in tree) {
                exp.Interpret(context);
            }

            Console.WriteLine($"{roman} = {context.Output}");

        }
    }
}