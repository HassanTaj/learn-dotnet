using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern {
    class Program {
        static void Main(string[] args) {
            IMessengeSender text = new TextSender();
            IMessengeSender webSender = new WebServiceSender();

            Message message = new SystemMessage {
                Subject = "A message",
                Body = "Hi there, Please accept this message."
            };

            message.Send(); // send text message
            message.MessageSender = webSender;
            message.Send(); // send message from web service

            Console.ReadKey();
        }
    }
}
