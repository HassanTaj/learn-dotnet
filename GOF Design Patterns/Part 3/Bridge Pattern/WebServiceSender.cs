using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern {
    class WebServiceSender : IMessengeSender {
        /// <summary>
        /// The 'ConcreteImplementor' class
        /// </summary>
        public void SendMessage(string subject, string body) {
            string messageType = "Web Service";
            Console.WriteLine($"{messageType}");
            Console.WriteLine($"--------------------");
            Console.WriteLine($"Subject : {subject} From {messageType}\nBody: {body}");
        }
    }
}
