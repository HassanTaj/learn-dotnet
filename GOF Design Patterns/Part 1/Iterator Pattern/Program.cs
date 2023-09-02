using Iterator_Pattern.Aggregate;
using Iterator_Pattern.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator_Pattern {
    class Program {
        static void Main(string[] args) {
            INewspaper nyt = new NYPaper();
            INewspaper lat = new LAPaper();

            IIterator nyitterator = nyt.CreateIterator();
            IIterator lapIterator = lat.CreateIterator();

            Console.WriteLine("--------------- NyPaper");
            PrintReporters(nyitterator);
            Console.WriteLine("--------------- LaPaper");
            PrintReporters(lapIterator);

            Console.ReadLine();

        }

        static void PrintReporters(IIterator iterator) {
            iterator.First();
            while (!iterator.IsDone()) {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}