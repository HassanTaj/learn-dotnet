using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator_Pattern {
    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    class ChatRoom : AbstractChatroom {

        private Dictionary<string, Participant> _participants =
            new Dictionary<string, Participant>();

        public override void Register(Participant participant) {
            if (!_participants.ContainsValue(participant)) {
                _participants[participant.Name] = participant;
            }
            participant.ChatRoom = this;
        }

        public override void Send(string from, string to, string message) {
            Participant participant = _participants[to];
            if (participant!=null) {
                participant.Recieve(from, message);
            }
        }
    }
}
