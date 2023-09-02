using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Pattern {
    /// <summary>
    /// A 'TerminalExpression'class
    /// <remakrk>
    ///  Ten checks for X, XL, L and XC
    /// </remakrk>
    /// </summary>
    class TenExpression : Expression {
        public override string Five() {
            return "L";
        }

        public override string Four() {
            return "XL";
        }

        public override int Multiplier() {
            return 10;
        }

        public override string Nine() {
            return "XC";
        }

        public override string One() {
            return "X";
        }
    }
}
