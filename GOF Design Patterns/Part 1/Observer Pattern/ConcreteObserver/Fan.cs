using Observer_Pattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer_Pattern.Subject;

namespace Observer_Pattern.ConcreteObserver {
    // Concrete Observer
    public class Fan : IFan {
        public void Update(ICelebrity celebrity) {
            Console.WriteLine($"Fan notified. Tweet of {celebrity.FullName} : {celebrity.Tweet}");
        } 
    }
}