using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator_Pattern {
    /// <summary>
    /// This code demonstrates the Mediator pattern facilitating loosely
    /// couppled communication  between different participants registering
    /// with a chatroom. The Chatroom is the centeral hub through which 
    /// all communication takes place.
    /// </summary>
    class Program {
        static void Main(string[] args) {

            ChatRoom cr = new ChatRoom();
            // create participants
            Participant eddie = new Actor("eddie");
            Participant gordo = new Actor("gordo");
            Participant lusy = new Actor("lusy");
            Participant wayne = new Actor("wayne");
            Participant cruse = new NonActor("cruse");
            // register them 
            cr.Register(eddie);
            cr.Register(gordo);
            cr.Register(lusy);
            cr.Register(wayne);
            cr.Register(cruse);

            // chatting participants
            eddie.Send("lusy","girl look at that body ahhh! haha");
            lusy.Send("eddie","aaa i work out :D :D ");
            cruse.Send("wayne", "fuck you wayne where's batman..");
            gordo.Send("cruse", "eddie and lusy are going all out nigga!!");

            // wait for the console
            Console.ReadKey();





        }
    }
}
