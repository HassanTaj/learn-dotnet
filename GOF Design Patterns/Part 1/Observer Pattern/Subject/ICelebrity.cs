using Observer_Pattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern.Subject {
    
    // Subject 
    public interface ICelebrity {
        string FullName { get; }
        string Tweet { get; set; }
        // attach observer
        void AddFollower(IFan fan);
        // detach observer
        void RemoveFollower(IFan fan);
        // notify
        void Notify(string tweet);

    }
}