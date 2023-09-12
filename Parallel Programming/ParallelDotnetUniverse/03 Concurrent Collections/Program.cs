using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Concurrent_Collections {
    /// <summary>
    ///     Overview of this project
    /// </summary>
    ///  ---------- Topics -----------
    ///  1. ConcurrentDictionary
    ///  2. ProducerConsumer Collections
    ///     a. ConcurrentQueue
    ///     b. ConcurrentStack
    ///     c. ConcurrentBag
    ///  3. Producer-consumer Pattern
    ///     a. BlockinCollection
    ///  ------------------------------
    ///  
    /// ConcurrentCollections :
    ///     Collections wich work ok when you acces them from multiple threads.
    ///  
    /// ///////////////////////////////////////////////////////
    /// 

    class Program {
        #region 1 Conccurent Dictionary 
        //private static ConcurrentDictionary<string, string> capitals = new ConcurrentDictionary<string, string>();
        //public static void AddParis() {
        //    bool success = capitals.TryAdd("France", "Paris");
        //    string who = Task.CurrentId.HasValue ? $"Task {Task.CurrentId}" : "Main Thread";
        //    Console.WriteLine($"{who} {(success ? "Added" : "couldn't add")}");
        //}
        #endregion

        #region 5 Consumer and Producer Collection
        /// -------------------------- Consumer and Producer Collection
        /// 
        static BlockingCollection<int> messages = new BlockingCollection<int>(new ConcurrentBag<int>(),10);
        static CancellationTokenSource cts = new CancellationTokenSource();
        static Random random = new Random();
        /// 
        /// -------------------------- Consumer and Producer Collection
        #endregion
        static void Main(string[] args) {
            /// stack LIFO
            /// queue FIFO
            /// bag no ordering
            /// 
            #region 5 Consumer and Producer Collection
            /// -------------------------- Consumer and Producer Collection
            /// 
            //Task.Factory.StartNew(ProduceAndConsume, cts.Token);
            //Console.ReadKey();
            //cts.Cancel();

            /// 
            /// -------------------------- Consumer and Producer Collection
            #endregion

            #region 4 Concurrent Bag
            /// ------------------- Concurrent Bag
            /// 

            //var bag = new ConcurrentBag<int>();
            //var tasks = new List<Task>();
            //for (int i = 0; i < 10; i++) {
            //    var i1 = i;
            //    tasks.Add(Task.Factory.StartNew(() => {

            //        bag.Add(i1);
            //        Console.WriteLine($"{Task.CurrentId} has added {i1}");
            //        int res;
            //        if (bag.TryPeek(out res)) {
            //            Console.WriteLine($"{Task.CurrentId} has peeked val {res}");
            //        }
            //    }));
            //}
            //Task.WaitAll(tasks.ToArray());
            //int last;
            //if (bag.TryTake(out last)) {
            //    Console.WriteLine($"i got last {last}");
            //}
            /// 
            /// ------------------- Concurrent Bag
            #endregion

            #region 3 Concurrent Stack
            /// ----------------------- Concurrent Stack
            /// 

            //var s = new ConcurrentStack<int>();
            //s.Push(1);
            //s.Push(2);
            //s.Push(3);
            //s.Push(4);

            //int result;
            //if (s.TryPeek(out result)) {
            //    Console.WriteLine($"{result} is on top");
            //}
            //if (s.TryPop(out result)) {
            //    Console.WriteLine($"Popped {result}");
            //}

            //// pop range
            //var items = new int[5];
            //if (s.TryPopRange(items,0,5) > 0) {
            //    var text = string.Join(", ", items.Select(i => i.ToString()));
            //    Console.WriteLine($"Popped these items {text}");
            //}

            ///
            /// ----------------------- Concurrent Stack
            #endregion

            #region 2 Concurrent Queue
            ///----------------------- Concurrent Queue
            ///
            //var q = new ConcurrentQueue<int>();
            //q.Enqueue(1);
            //q.Enqueue(2);

            //// 2 <- front
            //int result;
            //if (q.TryDequeue(out result)) {
            //    Console.WriteLine($"Removed the Element {result}");
            //}
            //if (q.TryPeek(out result)) {
            //    Console.WriteLine($"Front element is {result}");
            //}
            ///
            ///----------------------- Concurrent Queue
            #endregion

            #region 1 Conccurent Dictionary 
            //Task.Factory.StartNew(AddParis).Wait();
            //AddParis();
            //capitals["Russia"] = "Leingrad";
            //capitals.AddOrUpdate("Russia", "Moscow",(k,old)=> $"{old} --> Moscow");
            //Console.WriteLine($"The Capital of Russia is  {capitals["Russia"]}");

            //capitals["Sweden"] = "Uppsala";
            //var capOfSweden = capitals.GetOrAdd("Sweden", "Stockholm");
            //Console.WriteLine($"Capital of Sweden {capitals["Sweden"]}");

            //const string toRemove = "Russia";
            //string removedWhat;
            //var didRemove = capitals.TryRemove(toRemove,out removedWhat);
            //if (didRemove) {
            //    Console.WriteLine($"We removed {removedWhat}");
            //}
            //else {
            //    Console.WriteLine($"faild to remove capital of {toRemove}");
            //}
            #endregion

        }

        #region 5 Consumer and Producer Collection
        /// -------------------------- Consumer and Producer Collection
        /// 
        //private static void ProduceAndConsume() {
        //    var producer = Task.Factory.StartNew(RunProducer);
        //    var consumer = Task.Factory.StartNew(RunConsumer);
        //    try {
        //        Task.WaitAll(new[] { producer, consumer }, cts.Token);

        //    }
        //    catch (AggregateException ae) {
        //        ae.Handle(e => true);
        //    }
        //}

        //private static void RunConsumer() {
        //    foreach (var item in messages.GetConsumingEnumerable()) {
        //        cts.Token.ThrowIfCancellationRequested();
        //        Console.WriteLine($"-{item}");
        //        Thread.Sleep(random.Next(10000));
        //    }
        //}

        //private static void RunProducer() {
        //    while (true) {
        //        cts.Token.ThrowIfCancellationRequested();
        //        int i = random.Next(100);
        //        messages.Add(i);
        //        Console.WriteLine($"+{i}\t");
        //        Thread.Sleep(random.Next(100));
        //    }
        //}
        /// 
        /// -------------------------- Consumer and Producer Collection
        #endregion
    }
}
