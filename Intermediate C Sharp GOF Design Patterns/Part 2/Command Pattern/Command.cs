using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command_Pattern {
    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    public abstract class Command {
        public abstract void Execute();
        public abstract void UnExecute();
    }
}
