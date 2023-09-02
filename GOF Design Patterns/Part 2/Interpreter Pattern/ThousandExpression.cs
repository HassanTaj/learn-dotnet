using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Pattern {
    class ThousandExpression : Expression {
        /// <summary>
        /// A ' TerminalExpression' class
        ///  <remark>
        ///   Thousands checks for the Roman Numeral M
        ///  </remark>
        /// </summary>
        /// <returns></returns>
        public override string Five() {
            return " ";
        }

        public override string Four() {
            return " ";
        }

        public override int Multiplier() {
            return 1000;
        }

        public override string Nine() {
            return " ";
        }

        public override string One() {
            return "M";
        }
    }
}
