using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern {
    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    class TextSender : IMessengeSender {
        public void SendMessage(string subject, string body) {
            string messageType = "Text";
            Console.WriteLine($"{messageType}");
            Console.WriteLine($"--------------------");
            Console.WriteLine($"Subject : {subject} From {messageType}\nBody: {body}");
        }
    }
}
