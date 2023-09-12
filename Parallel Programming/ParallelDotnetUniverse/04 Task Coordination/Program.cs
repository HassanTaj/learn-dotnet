//#define Continuations
//#define Child_Tasks
//#define Barrier
//#define CountdownEvent
//#define ManualResetSlim_And_AutoResetEvent
//#define SemaphoreSlim
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Task_Coordination {
    /// <summary>
    ///     Overview of this project
    /// </summary>
    ///  ---------- Topics -----------
    ///  1. Continuations
    ///  2. Child Tasks
    ///  3. More Synchronization primitives!s
    ///     a. Barrier
    ///     b. CountdownEvent
    ///     c. ManualResetEventSlim/AutoResetEvent
    ///     d. SemaphoreSlim
    ///  ------------------------------
    ///  
    /// ///////////////////////////////////////////////////////

    class Program {
        #region 3 Barrier 
#if Barrier
        static Barrier barrier = new Barrier(2,b => {
            Console.WriteLine($"Phasee {b.CurrentPhaseNumber} is finished.");
            //b.ParticipantCount
            //b.ParticipantsRemaining
            //b.AddParticipant()
            //b.AddParticipants()
        });
        public static void Water() {
            Console.WriteLine("Putting the kettle on (takes a bit longer)");
            Thread.Sleep(2000);
            barrier.SignalAndWait();
            Console.WriteLine("Pouring water into cup");
            Thread.Sleep(2000);
            barrier.SignalAndWait();
            Console.WriteLine("Putting the cattle away");
        }
        public static void Cup() {
            Console.WriteLine("Finding the nicest cup of tea (fast)");
            barrier.SignalAndWait();
            Console.WriteLine("Adding tea.");
            barrier.SignalAndWait();
            Console.WriteLine("Adding sugar");
        }


#endif
        #endregion

        #region 4 CountdownEvent
#if CountdownEvent
        private static int taskCount = 5;
        static CountdownEvent cte = new CountdownEvent(taskCount);
        static Random random = new Random();
#endif
        #endregion

        static void Main(string[] args) {

            #region 6 SemaphoreSlim
#if SemaphoreSlim
            var semaphore = new SemaphoreSlim(initialCount:2,maxCount:10);
            for (int i = 0; i < 20; i++) {
                Task.Factory.StartNew(() => {
                    Console.WriteLine($"Entering task {Task.CurrentId}");
                    semaphore.Wait(); // releaseCount --;
                    Console.WriteLine($"Processing task {Task.CurrentId}");

                });
            }

            while (semaphore.CurrentCount <=2) {
                Console.WriteLine($"Seamaphore count :{semaphore.CurrentCount}");
                Console.ReadKey();
                semaphore.Release(2); // releasecount +=2
            }
#endif
            #endregion

            #region 5 ManualResetSlim_And_AutoResetEvent
#if ManualResetSlim_And_AutoResetEvent

            var evt = new ManualResetEventSlim();

            Task.Factory.StartNew(() => {
                Console.WriteLine("Boiling water");
                evt.Set();
            });
            var makeTea = Task.Factory.StartNew(() => {
                Console.WriteLine($"waiting for water..");
                evt.Wait();
                Console.WriteLine("here is your tea");
                var ok = evt.Wait(1000);
                if (ok) {
                    Console.WriteLine("enjoy your tea");
                }
                else {
                    Console.WriteLine("no tea for you");
                }
            });

            var aevt = new AutoResetEvent(false);
            Task.Factory.StartNew(() => {
                Console.WriteLine("Boiling water");
                aevt.Set(); //  true
            });
            var makeTea2 = Task.Factory.StartNew(() => {
                Console.WriteLine($"waiting for water..");
                aevt.WaitOne(); // false
                Console.WriteLine("here is your tea");
                var ok = aevt.WaitOne(1000);
                if (ok) {
                    Console.WriteLine("enjoy your tea");
                }
                else {
                    Console.WriteLine("no tea for you");
                }
            });

            makeTea2.Wait();
            makeTea.Wait();
#endif
            #endregion

            #region 4 CountdownEvent
#if CountdownEvent
            /// signalAndWait()
            //for (int i = 0; i < taskCount; i++) {
            //    Task.Factory.StartNew(() => {
            //        Console.WriteLine($"Entering task {Task.CurrentId}");
            //        Thread.Sleep(random.Next(3000));
            //        cte.Signal();
            //        Console.WriteLine($"Exiting task {Task.CurrentId}");
            //    });
            //}
            //var finalTask = Task.Factory.StartNew(() => {
            //    Console.WriteLine($"Waiting for other tasks to complete in {Task.CurrentId}");
            //    cte.Wait();
            //});
            //finalTask.Wait();
#endif
            #endregion

            #region 3 Barrier 
#if Barrier

            var water = Task.Factory.StartNew(Water);
            var cup = Task.Factory.StartNew(Cup);
            var tea = Task.Factory.ContinueWhenAll(new[] { water, cup }, tasks => {

                Console.WriteLine("Enjoyed your cup of tea.");
            });
            tea.Wait();

#endif
            #endregion

            #region 2 Child Tasks
#if Child_Tasks

            var parent = new Task(() => {
                /// there child here is called detached
                /// it means that there is no differance between this task being the child taks or 
                /// a task somewhere else so it really doesn't matter to the scheduler
                /// //
                var child = new Task(() => {
                    Console.WriteLine("Child taks starting");
                    Thread.Sleep(3000);
                    Console.WriteLine("Child taks finishing");
                    throw new DivideByZeroException();
                },TaskCreationOptions.AttachedToParent);

                var completionHandler = child.ContinueWith(t => {
                    Console.WriteLine($"Horray, task {t.Id}'s state is {t.Status}");
                },TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion);

                var failHandler = child.ContinueWith(t => {
                    Console.WriteLine($"Fuck, task {t.Id}'s state is {t.Status}");
                }, TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnFaulted);

                child.Start();
            });
            parent.Start();
            try {
                parent.Wait();
            }
            catch (AggregateException ae) {

                ae.Handle(e => true);
            }

#endif
            #endregion

            #region 1 Continuations
#if Continuations

            //var task = Task.Factory.StartNew(() => {
            //    Console.WriteLine("Boiling water");
            //});

            //var task2 = task.ContinueWith(t => {
            //    Console.WriteLine($"Completed {t.Id}, Pour water into the cup");
            //});
            //task2.Wait();


            var t = Task.Factory.StartNew(() => "Task 1");
            var t2 = Task.Factory.StartNew(() => "Task 2");

            //var t3 = Task.Factory.ContinueWhenAll(new[] { t, t2 }, tasks => {
            //    Console.WriteLine("Tasks completed");
            //    foreach (var task in tasks) {
            //        Console.WriteLine($"- {t.Result}");
            //    }
            //    Console.WriteLine("All Done.");
            //});
            //var t3 = Task.Factory.ContinueWhenAny(new[] { t, t2 }, ts => {
            //    Console.WriteLine("Tasks completed");
            //        Console.WriteLine($"- {ts.Result}");
            //    Console.WriteLine("All Done.");
            //});

            //t3.Wait();

#endif
            #endregion

        }
    }
}
