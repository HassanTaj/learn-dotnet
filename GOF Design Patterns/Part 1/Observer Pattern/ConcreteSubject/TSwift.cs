using Observer_Pattern.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer_Pattern.Observer;

namespace Observer_Pattern.ConcreteSubject {
    public class TSwift : ICelebrity {
        private readonly List<IFan> _fans = new List<IFan>();
        private string _tweet;



        public TSwift(string tweet) {
            _tweet = tweet;
        }



        public string FullName => "Tailor Swift";

        public string Tweet { get => _tweet; set => Notify(_tweet); }

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