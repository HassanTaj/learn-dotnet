using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator_Pattern {
    /// <summary>
    /// The 'AbstractCollegue' class
    /// </summary>
    class Participant {
        private ChatRoom _chatRoom;
        private string _name;

        public Participant(string name) {
            this._name = name;
        }

        // gets participant name
        
        public string Name {
            get { return _name; }
        }
        // gets chatroom
        public ChatRoom ChatRoom {
            set { _chatRoom = value; }
            get { return _chatRoom; }
        }

        // sends message to given participant
        public void Send (string to, string message) {
            _chatRoom.Send(_name, to, message);
        }

        // recieves message from given participant
        public virtual void Recieve(string from, string message) {
            Console.WriteLine($"{from} to {Name} : {message}");
        }
    }
}
