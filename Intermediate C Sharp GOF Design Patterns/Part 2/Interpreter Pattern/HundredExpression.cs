using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter_Pattern {
    /// <summary>
    /// A 'TerminalExpression'class
    /// <remakrk>
    ///  Hundered checks c, cd, d or cm
    /// </remakrk>
    /// </summary>
    class HundredExpression : Expression {
        public override string Five() {
            return "D";
        }

        public override string Four() {
            return "CD";
        }

        public override int Multiplier() {
            return 100;
        }

        public override string Nine() {
            return "CM";
        }

        public override string One() {
            return "C";
        }
    }
}