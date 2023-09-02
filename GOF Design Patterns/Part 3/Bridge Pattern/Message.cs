using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern {
    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    abstract class Message {

        public IMessengeSender MessageSender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        // Method 
        public abstract void Send();
    }
}
