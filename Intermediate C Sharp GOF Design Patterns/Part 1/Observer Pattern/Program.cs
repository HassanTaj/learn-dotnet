using Observer_Pattern.ConcreteObserver;
using Observer_Pattern.ConcreteSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Observer_Pattern {
    class Program {
        static void Main(string[] args) {

            var gClooney = new GCloney("I love my dog");
            var tSwift = new TSwift(null);

            var firstFan = new Fan();
            var secondFan = new Fan();

            gClooney.AddFollower(firstFan);
            tSwift.AddFollower(secondFan);

            
            Thread.Sleep(500);
            gClooney.Tweet = "Em is the best rapper";
            Thread.Sleep(500);
            tSwift.Tweet = "Em just fucked me in his song";
   
            Console.Read();
        }
    }
}