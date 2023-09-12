//#define Parallel_invoke_for_foreach
//#define Breaking_Cancellations_and_Exceptions
//#define Thread_Local_Storage
//#define Partitioning
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Parallel_Loops {
    /// <summary>
    ///     Overview of this project
    /// </summary>
    ///  ---------- Topics -----------
    ///  1. Parallel Invoke/For/ForEach
    ///     a. Options, stepped for loop
    ///  2. Stopping, cancellation and exceptions
    ///  3. Thread Local Storage
    ///  4. Partitioning
    ///  ------------------------------
    ///  
    /// ///////////////////////////////////////////////////////

    public class Program {

        #region Breaking_Cancellations_and_Exceptions
#if Breaking_Cancellations_and_Exceptions

        private static ParallelLoopResult result;

        public static void Demo() {
            var cts = new CancellationTokenSource();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;

            result = Parallel.For(0, 20,po, (int x, ParallelLoopState state) => {
                Console.WriteLine($"{x}[{Task.CurrentId}]");
                if (x == 10) {
                    //state.Stop(); // stops the execution of the loop ASAP
                    //state.Break(); // you make a request to stop execution of iterations 
                    //throw new Exception();
                    cts.Cancel();
                }
            });
            Console.WriteLine();
            Console.WriteLine($"was the loop completed? {result.IsCompleted}");
            if (result.LowestBreakIteration.HasValue) {
                Console.WriteLine($"Lowest break iteration is {result.LowestBreakIteration}");
            }
        }
#endif
        #endregion

        #region Parallel_invoke_for_foreach
#if Parallel_invoke_for_foreach
        public static IEnumerable<int> Range(int start, int end, int step) {
            for (int i = start; i < end; i+=step) {
                yield return i;
            }
        }
#endif
        #endregion

        #region 4 Partitioning
#if Partitioning
        [Benchmark]
        public void SquareEachValue() {
            const int count = 100000;
            var values = Enumerable.Range(0, count);
            var results = new int[count];
            Parallel.ForEach(values, x => { results[x] = (int)Math.Pow(x, 2); });
        }
        [Benchmark]
        public void SquareEachValueChuncked() {
            const int count = 100000;
            var values = Enumerable.Range(0, count);
            var results = new int[count];
            var part = Partitioner.Create(0, count, 10000);
            Parallel.ForEach(part, range=> {
                for (int i = range.Item1; i < range.Item2; i++) {
                    results[i] = (int)Math.Pow(i, 2);
                }
            });
        }
#endif
        #endregion

        static void Main(string[] args) {

            #region 4 Partitioning
#if Partitioning
            var summary = BenchmarkRunner.Run<Program>();
            Console.WriteLine(summary);
            Console.ReadKey();
#endif
            #endregion

            #region 3 Thread_Local_Storage
#if Thread_Local_Storage

            //int sum = 0;
            //Parallel.For(1, 1000, x => {
            //    Interlocked.Add(ref sum, x);
            //});
            int sum = 0;
            Parallel.For(1, 1001,
                () => 0,
                (x, state, tls) => {
                    tls += x;
                    Console.WriteLine($"Task {Task.CurrentId} has sum {tls}");
                    return tls;
                },
                partialSum => {
                    Console.WriteLine($"Partial value of task {Task.CurrentId} is {partialSum}");
                    Interlocked.Add(ref sum, partialSum);
                });
            Console.WriteLine($"sum of 1..100 = {sum}");
#endif
            #endregion

            #region 2 Breaking_Cancellations_and_Exceptions
#if Breaking_Cancellations_and_Exceptions

            try {
                Demo();
            }
            catch (AggregateException ae) {
                ae.Handle(e => {
                    Console.WriteLine(e.Message);
                    return true;
                });
            }
            catch(OperationCanceledException oc) {
             
            }

#endif
            #endregion

            #region 1 Parallel_invoke_for_foreach
#if Parallel_invoke_for_foreach

            var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
            var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
            var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

            Parallel.Invoke(a, b, c);

            //Parallel.For(1, 11, i => {
            //    Console.WriteLine($"{i * i}");
            //});

            //var words = new List<string>() {
            //    "words",
            //    "what",
            //    "the",
            //    "hell",
            //};
            //Parallel.ForEach(words, w => {
            //    Console.WriteLine($"{w.Length}{Task.CurrentId}");
            //});

            //Parallel.ForEach(Range(1, 20, 3), Console.WriteLine);

            //var po = new ParallelOptions();
            
            Console.ReadKey();
#endif
            #endregion
        }
    }
}