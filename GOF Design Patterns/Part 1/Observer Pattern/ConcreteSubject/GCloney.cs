using Observer_Pattern.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer_Pattern.Observer;

namespace Observer_Pattern.ConcreteSubject {
    // Concrete Subject
    public class GCloney : ICelebrity {

        private readonly List<IFan> _fans = new List<IFan>(); // collection of fans
        private string _tweet;

        public GCloney(string tweet) {
            _tweet = tweet;
        }

        public string FullName => "George Clooney";

        public string Tweet { get => _tweet; set => Notify(value); }

        public void AddFollower(IFan fan) {
            _fans.Add(fan);
        }

        public void Notify(string tweet) {
            _tweet = tweet;
            foreach (var fan in _fans) {
                fan.Update(this);
            }
        }

        public void RemoveFollower(IFan fan) {
            _fans.Remove(fan);
        }
    }
}