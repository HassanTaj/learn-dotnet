using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern {
    class Program {
        static void Main(string[] args) {

            var stopWatch = Stopwatch.StartNew();

            var superBuilder = new SuperCarBuilder();
            var lameBuilder = new LameCarBuilder();

            var factory = new CarFactory();
            var builders = new List<CarBuilder> {
                               superBuilder,
                                lameBuilder,
            };

            foreach (var b in builders) {
                var c = factory.Build(b);
                Console.WriteLine($"The Car Requested By {b.GetType().Name} :\n" +
                    $"\nHorse Power : {c.HorsePower}" +
                    $"\nImpressive Feature : {c.MostIMpressiveFeature}" +
                    $"\nTop Speed : {c.TopSpeedMPH} mph");
                Console.WriteLine($"Time Taken : {stopWatch.ElapsedMilliseconds} ms");
            }
            Console.WriteLine($"Total Time Taken : {stopWatch.ElapsedMilliseconds} ms");
        }
    }
}