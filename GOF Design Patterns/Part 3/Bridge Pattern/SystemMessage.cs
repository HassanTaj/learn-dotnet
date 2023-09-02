using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern {
    /// <summary>
    /// The 'RefinedAbstraction' class 
    /// </summary>
    class SystemMessage : Message {

        public override void Send() {
            MessageSender.SendMessage(Subject, Body);
        }
    }
}
