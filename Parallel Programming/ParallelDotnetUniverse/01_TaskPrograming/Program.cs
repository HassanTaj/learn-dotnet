using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_TaskPrograming {
    /// <summary>
    /// Overview of this project
    /// </summary>
    ///  ---------- Topics -----------
    ///  1. Creating and starting tasks
    ///  2. canceling tasks
    ///  3. Waiting for time to pass
    ///  4. waiting for tasks
    ///  5. Exception handling
    ///  ------------------------------
    ///  
    /// ///////////////////////////////

    class Program {
        public static void Write(char c) {
            int i = 1000;
            while (i-- > 0) {
                Console.Write(c);
            }
        }
        public static void Write(object o) {
            for (int i = 0; i < 1000; i++) {
                Console.Write(o.ToString());
            }
        }
        public static int TextLength(object o) {
            Console.WriteLine($"\n task with id {Task.CurrentId} processing object {o}...");
            return o.ToString().Length;
        }
        public static void ExceptionTest() {
            var t = Task.Factory.StartNew(() => {
                throw new InvalidOperationException("Can't do this!") { Source = "t" };
            });

            var t2 = Task.Factory.StartNew(() => {
                throw new AccessViolationException("Can't access this!") { Source = "t2" };
            });
            try {

                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae) {
                ae.Handle(e => {
                    if (e is InvalidOperationException) {
                        Console.WriteLine("invalid operatopn!");
                        return true;
                    }
                    else
                        return false;

                });
                //foreach (var e in ae.InnerExceptions)
                //    Console.WriteLine($"Exception {e.GetType()} from {e.Source}");
            }
        }
        static void Main(string[] args) {

            #region Notes...
            /// /////////////////////////////
            /// 
            /// 1. what is a task 
            /// >
            /// a task is just an abstraction its the .net's way of grouping
            /// a unitof work together and telling the scheduler that this unit of work 
            /// can be executed on a seperate thread
            /// 
            /// 
            /// 
            /// 
            /// /////////////////////////////
            #endregion

            #region Creating And Starting tasks...
            /// ------------ Creating and Starting Tasks
            /// 
            // method 1
            //Task.Factory.StartNew(() => Write('.'));
            //// method 2
            //var t = new Task(() => Write('?'));
            //t.Start();
            //Write('-');

            //--------- lets customize to provide arguments into the lambda

            //Task t = new Task(Write, "fuck this shit");
            //t.Start();
            //Task.Factory.StartNew(Write, 123);

            //---------- returning values form a function
            //string text1 = "fuckthis shit aosdflkajdsf", text2 = "wtf wtf";
            //var t = new Task<int>(TextLength,text1);
            //t.Start();
            //Task<int> t2 = Task.Factory.StartNew(TextLength,text2);

            //Console.WriteLine($"Length of Text 1 {text1} is {t.Result}");
            //Console.WriteLine($"Length of Text 1 {text2} is {t2.Result}");
            /// 
            /// ------------ Creating and Starting Tasks
            #endregion

            #region Canceling Tasks
            /// -------------  Canceling Tasks
            /// 

            //var cts = new CancellationTokenSource();
            //var token = cts.Token;
            //token.Register(() => {
            //    Console.WriteLine("Cancelation has be requested");
            //});

            //var t = new Task(() => {
            //    int i = 0;
            //    while (true) {
            //        //if (token.IsCancellationRequested)
            //        //    throw new OperationCanceledException();
            //        ////break;
            //        //else
            //        //    Console.WriteLine($"{i++}");
            //        // or 

            //        token.ThrowIfCancellationRequested();
            //        Console.WriteLine($"{i++}");
            //    }
            //}, token);
            //t.Start();

            //Task.Factory.StartNew(() => {
            //    token.WaitHandle.WaitOne();
            //    Console.WriteLine("wait handle has been realeased, cancelation was requested");
            //});
            //Console.ReadKey();
            //cts.Cancel();


            // composite cancellation
            //var planned = new CancellationTokenSource();
            //var preventative  = new CancellationTokenSource();
            //var emergency = new CancellationTokenSource();

            //var paranoid = CancellationTokenSource.CreateLinkedTokenSource(
            //    planned.Token, preventative.Token, emergency.Token);

            //Task.Factory.StartNew(() => {
            //    int i = 0;
            //    while (true) {
            //        paranoid.Token.ThrowIfCancellationRequested();
            //        Console.WriteLine($"{i++}\t");
            //        Thread.Sleep(1000);
            //    }
            //},paranoid.Token);

            //Console.ReadKey();
            //emergency.Cancel();
            /// 
            /// -------------  Canceling Tasks


            #endregion

            #region Waiting For Time To Pass
            /// -------------------- Waiting for TTime To Pass
            /// 

            //var cts = new CancellationTokenSource();
            //var token = cts.Token;
            //var t = new Task(() => {
            //    /// Thread.Sleep()
            //    /// this pauses thread of execution 
            //    /// but it's not just that, it doesn't just pause the thread of execution 
            //    /// but also tells the scheduler that we don't need the processor any more.
            //    /// so the scheduler can execute another task
            //    //Thread.Sleep(5000); 
            //    /// 

            //    /// spinwait also is used to pause the thread 
            //    /// but there is a different rule here, that you don't give up your place in the 
            //    /// execution task, the scheduler won't get any other task going while your task is 
            //    /// spinning you will waist cpu cycles but don't give up your place in the execution queue
            //    /// 
            //    /// 
            //    //Thread.SpinWait(3);
            //    //SpinWait.SpinUntil(() => {
            //    //});

            //    /// another way is with cancelatio tokken

            //    Console.WriteLine("press any key to disarm shit boom, you have 5 seconds");
            //    var cancled = token.WaitHandle.WaitOne(5000);
            //    Console.WriteLine(cancled? "shit boom disarmed":"booommb shit");
            //},token);
            //t.Start();
            //Console.ReadKey();
            //cts.Cancel();
            /// 
            /// -------------------- Waiting for Time To Pass
            #endregion

            #region Waiting For Tasks
            /// -------------- Waiting for Tasks
            /// 
            //var cts = new CancellationTokenSource();
            //var token = cts.Token;
            //var t = new Task(() => {
            //    Console.WriteLine("I take 5 seconds");
            //    for (int i = 0; i < 5; i++) {
            //        token.ThrowIfCancellationRequested();
            //        Thread.Sleep(1000);
            //    }
            //    Console.WriteLine("i'm done.");
            //}, token);
            //t.Start();

            //// to see the exception thrown
            ////Console.ReadKey();
            ////cts.Cancel();

            //Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);
            ////t.Wait(token);
            ////Task.WaitAll(t, t2); // waits for all to complete
            ////Task.WaitAny(t, t2); // waits for any taks to complete
            ////Task.WaitAny(new[] { t, t2 }, 4000); // if you want it ti wait for 4seconds
            //Task.WaitAny(new[] { t, t2 }, 4000, token); // if you provide it a token then it will throw an exception
            //Console.WriteLine($"Task t status is {t.Status}");
            //Console.WriteLine($"Task t2 status is {t2.Status}");

            //Console.WriteLine("Fuckadi FUck fuck ");
            /// 
            /// -------------- Waiting for Tasks
            #endregion

            #region Exception Handling
            /// ----------- Exception Handling
            /// 
            //try {
            //    ExceptionTest();
            //}
            //catch (AggregateException ae) {
            //    foreach (var e in ae.InnerExceptions) {
            //        Console.WriteLine($"handled else where {e.GetType()}");
            //    }
            //}
            /// 
            /// ----------- Exception Handling
            #endregion

            Console.WriteLine("Main Program done.");
            Console.ReadKey();
        }
    }
}
