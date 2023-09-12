//#define AsPrallel_and_ParallelQuery
//#define Cencellation_And_Exception
//#define Merge_Options
//#define Custom_Aggrigation
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_Parallel_LINQ {
    /// <summary>
    ///     Overview of this project
    /// </summary>
    ///  ---------- Topics -----------
    ///  1. AsParallel()
    ///  2. Cancellation and exceptions
    ///  3. Merge Options
    ///  4. Custom Aggregation
    ///  -------
    ///  LINQ is an awesome technology for querying data,
    ///  Uses a number of Operators,Select(),SUM(),...
    ///  By default,execution is sequential
    ///  PLINQ is TPL's Counterpart for parallel LINQ
    ///  ------------------------------
    ///  
    /// ///////////////////////////////////////////////////////

    class Program {
        static void Main(string[] args) {

            #region 04 Custom Aggrigation
#if Custom_Aggrigation

            //var sum = Enumerable.Range(1, 1000).Sum();
            //Console.WriteLine($"sum  = {sum}");

            //var sum = Enumerable.Range(1, 1000).Aggregate(0, (i, accumulator) => i + accumulator);

            var sum = ParallelEnumerable.Range(1, 1000)
                .Aggregate(
                0,
                (partialsum, i) => partialsum += i,
                (total, subtotal) => total += subtotal,
                i => i);

            Console.WriteLine($"sum  = {sum}");

#endif
            #endregion

            #region 03 Merge Options
#if Merge_Options

            var numbers = Enumerable.Range(0, 20).ToArray();

            var results = numbers.AsParallel().WithMergeOptions(ParallelMergeOptions.FullyBuffered).Select(x => {
                var result = Math.Log(x);
                Console.Write($"Produced {result}\t");
                return result;
            });

            foreach (var res in results) {
                Console.Write($"Consumed {res}\t");
            }

#endif
            #endregion

            #region 02 Cencellation_And_Exception
#if Cencellation_And_Exception

            var cts = new CancellationTokenSource();

            var items = ParallelEnumerable.Range(0, 20);

            var results = items.WithCancellation(cts.Token).Select(i => {

                double result = Math.Log(i);
                //if (result > 1) throw new InvalidOperationException();

                Console.WriteLine($"i = {i}, tid = {Task.CurrentId}");
                return result;
            });
            try {
                foreach (var c in results) {
                    if (c > 1) {
                        cts.Cancel();
                    }
                    Console.WriteLine($"resut = {c}");
                }
            }
            catch (AggregateException ae) {

                ae.Handle(e => {
                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                    return true;
                });
            }
            catch (OperationCanceledException e) {
                Console.WriteLine("cancled");
            }

#endif
            #endregion

            #region 01 AsPrallel and ParallelQuery
#if AsPrallel_and_ParallelQuery
            const int count =50;
            var items = Enumerable.Range(1, count).ToArray();
            var results = new int[count];

            // parallel loop.
            items.AsParallel().ForAll(x => {
                int newVal = x*x*x;
                Console.Write($"{newVal} ({Task.CurrentId }) ");
                results[x - 1] = newVal;
                //foreach (var item in results) {
                //    Console.WriteLine($"{item}\t");
                //}
                var cubes = items.AsParallel().AsOrdered().Select(c => x * x * x);
                foreach (var i in cubes) {
                    Console.WriteLine($"{i}\t");
                }
            });

#endif
            #endregion
        }
    }
}
