using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Pattern {
    /// <summary>
    /// A 'TerminalExpression'class
    /// <remakrk>
    ///  One checks for I,II,III,IV,V,VI VII,VIII,IX
    /// </remakrk>
    /// </summary>
    class OneExpression : Expression {
        public override string Five() {
            return "V";
        }

        public override string Four() {
            return "IV";
        }

        public override int Multiplier() {
            return 1;
        }

        public override string Nine() {
            return "IX";
        }

        public override string One() {
            return "I";
        }
    }
}
