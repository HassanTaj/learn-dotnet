using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_Data_Sharing_and_Synchronization {
    /// <summary>
    ///     Overview of this project
    /// </summary>
    ///  ---------- Topics -----------
    ///  1. Critical sections
    ///  2. Interlocked Operations
    ///  3. Spin locking and Lock Recursion
    ///  4. Mutex
    ///  5. Reader-writer Locks
    ///  ------------------------------
    ///  
    ///  Atomicity : 
    ///     An operation is atomic if it cannot be interrupted
    ///     meaning it can't be seperated into different parts
    ///     such that between the execution of part of application or another 
    ///     some other thread comes in and does something. so an operation is 
    ///     atomic if it can't fundamentally be interupted. by someting else 
    ///     e.g 
    ///         x =1; is atomic 
    ///         x++ is not atomic because it does x+1 >temp; temp>x
    ///         vulnerable to race condition
    ///         
    ///  Atomic Operations :  
    ///     refferance assignments, reads and writes to value 
    ///     types 32bits,64bit reads/writes on a 64bit system
    ///  
    /// ///////////////////////////////////////////////////////
    /// 

    #region 4 Mutex
    public class BankAccount {
        private int balance;
        public int Balance {
            get { return balance; }
            set { balance = value; }
        }
        public void Deposit(int amount) {
            balance += amount;
        }
        public void Withdraw(int amount) {
            balance -= amount;
        }
        public void Transfer(BankAccount where, int amount) {
            balance -= amount;
            where.Balance += amount;
        }
    }
    #endregion

    #region 3 Spin Locking
    //public class BankAccount {
    //    // +=
    //    // op1: temp <- get_Balance() + amount;
    //    // op2: set_Balance(temp) - amount;
    //    //
    //    private int balance;
    //    public int Balance {
    //        get { return balance; }
    //        set { balance = value; }
    //    }
    //    public void Deposit(int amount) {
    //        balance += amount;
    //    }
    //    public void Withdraw(int amount) {
    //        balance -= amount;
    //    }
    //}
    #endregion

    #region 2 InterLocked Operations
    //public class BankAccount {
    //    // +=
    //    // op1: temp <- get_Balance() + amount;
    //    // op2: set_Balance(temp) - amount;
    //    //
    //    private int balance;
    //    public int Balance {
    //        get { return balance; }
    //        set { balance = value; }
    //    }
    //    public void Deposit(int amount) {
    //        Interlocked.Add(ref balance, amount);
    //        // some other functionality of interloc class
    //        //Interlocked.Increment(); +=1
    //        //Interlocked.Decrement(); -=1
    //        //Interlocked.MemoryBarrier();
    //        //Thread.MemoryBarrier();

    //        // what is memorybarrier?
    //        /// the problem with concurrent code is that sometimes 
    //        /// the cpu can re-order the instructions which are written 
    //        /// as you write them forexample
    //        ///     you wrote 3 things
    //        ///     1
    //        ///     2
    //        ///     Thread.MemoryBarrier();
    //        ///     3
    //        ///     
    //        /// now you would expect this to run as 1,2,3 
    //        /// where as the cpu can execute them as 3,1,2
    //        /// so here what the memorybarrier does is that it tells the cpu
    //        /// that the instructions that appear before the memory barrier can't be executed in the 
    //        /// block after the memory barrier 
    //        /// thats something that is also tied to the volatile keyword
    //        /// 
    //        /// -------------------------
    //        ///  InterLocked has two methods
    //        ///  1. exchange
    //        ///         this basically sets the value
    //        ///  2. compareexchange
    //        ///         this basically compairs the two values for equality
    //        ///         and if the are equal then it replaces the first value
    //        /// 
    //        ///  //////////////////////////////////////////////////////


    //    }
    //    public void Withdraw(int amount) {
    //        Interlocked.Add(ref balance, -amount);
    //    }
    //}
    #endregion

    #region 1 Critical Section Problem
    //public class BankAccount {
    //    // +=
    //    // op1: temp <- get_Balance() + amount;
    //    // op2: set_Balance(temp) - amount;
    //    //
    //    public object padlock = new object();
    //    public int Balance { get; private set; }
    //    public void Deposit(int amount) {
    //        lock (padlock) {
    //            Balance += amount;
    //        }
    //    }
    //    public void Withdraw(int amount) {
    //        lock (padlock) {
    //            Balance -= amount;
    //        }
    //    }
    //}
    #endregion

    class Program {
        #region 5 Reader Writer Lock
        //static ReaderWriterLockSlim padlock = new ReaderWriterLockSlim();
        //static ReaderWriterLockSlim padlock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        //static Random random = new Random();
        #endregion

        static void Main(string[] args) {

            #region 5 Reader Writer Lock
            /// ----------------- Reader Writer Lock
            /// 

            //int x = 0;
            //var tasks = new List<Task>();
            //for (int i = 0; i < 10; i++) {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        //padlock.EnterReadLock();
            //        //padlock.EnterReadLock();

            //        padlock.EnterUpgradeableReadLock();

            //        if (i % 2 == 0) {
            //            padlock.EnterWriteLock();
            //            x = 123;
            //            padlock.ExitWriteLock();
            //        }

            //        Console.WriteLine($"Entered read lock, x = {x}.");
            //        Thread.Sleep(5000);

            //        padlock.ExitUpgradeableReadLock();
            //        //padlock.ExitReadLock();
            //        //padlock.ExitReadLock();
            //        Console.WriteLine($"Exited read lock, x = {x}.");

            //    }));
            //}

            //try {

            //    Task.WaitAll(tasks.ToArray());
            //}
            //catch (AggregateException ae) {
            //    ae.Handle(e => {
            //        Console.WriteLine(e);
            //        return true;
            //    });
            //}

            //while (true) {
            //    Console.ReadKey();
            //    padlock.EnterWriteLock();
            //    Console.WriteLine($"Write lock aquired. ");
            //    int newVal = random.Next(10);
            //    x = newVal;
            //    Console.WriteLine($"Set x = {x}");
            //    padlock.ExitWriteLock();
            //    Console.WriteLine("write lock released.");
            //}
            /// 
            /// ----------------- Reader Writer Lock
            #endregion

            #region 4 Mutex
            /// ------------ Mutex
            /// 
            ///  A mutex is a type of a wait handle. a wait handle is the base class for a number of 
            ///  synchronization primitives such as reset events, 
            ///  
            /// Idea of mutex is that it controlls the access to a peticular area of code
            /// so its similar to a lock but with a certain few changes
            ///  

            //var tasks = new List<Task>();
            //var ba = new BankAccount();
            //var ba2 = new BankAccount();

            //Mutex mutex = new Mutex();
            //Mutex mutex2 = new Mutex();

            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            bool haveLock = mutex.WaitOne();
            //            try {

            //                ba.Deposit(1);
            //            }
            //            finally {
            //                if (haveLock) {
            //                    mutex.ReleaseMutex();
            //                }
            //            }
            //        }
            //    }));
            //});
            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            bool haveLock = mutex2.WaitOne();
            //            try {

            //                ba2.Deposit(1);
            //            }
            //            finally {
            //                if (haveLock) {
            //                    mutex2.ReleaseMutex();
            //                }
            //            }
            //        }
            //    }));
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int j = 0; j < 1000; j++) {
            //            bool haveLock = Mutex.WaitAll(new[] { mutex, mutex2 });
            //            try {
            //                ba.Transfer(ba2, 1);
            //            }
            //            finally {
            //                if (haveLock) {
            //                    mutex.ReleaseMutex();
            //                    mutex2.ReleaseMutex();
            //                }
            //            }
            //        }
            //    }));
            //});

            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine($"Final Balance  ba  : {ba.Balance}");
            //Console.WriteLine($"Final Balance  ba2  :{ba2.Balance}");


            // Globla Mutex

            //const string appName = "FuckApp";
            //Mutex mutex;
            //try {
            //    mutex = Mutex.OpenExisting(appName);
            //    Console.WriteLine($"sorry app is already running {appName}");
            //}
            //catch (WaitHandleCannotBeOpenedException ex) {
            //    Console.WriteLine(" we can run the program just fine");
            //    mutex = new Mutex(false, appName);
            //}
            //Console.ReadKey();
            //mutex.ReleaseMutex();
            /// 
            /// ------------ Mutex
            #endregion

            #region 3 Spin Locking
            /// ------------------  Spin locking
            /// 
            //var tasks = new List<Task>();
            //var ba = new BankAccount();
            //SpinLock sl = new SpinLock();
            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            bool lockTaken = false;
            //            try {
            //                sl.Enter(ref lockTaken);
            //                ba.Deposit(100);
            //            }
            //            catch (Exception ex) {
            //                Console.WriteLine(ex.Message);
            //            }
            //            finally {
            //                if (lockTaken) sl.Exit();
            //            }
            //        }
            //    }));
            //});
            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            bool lockTaken = false;
            //            try {
            //                sl.Enter(ref lockTaken);
            //                ba.Withdraw(100);
            //            }
            //            catch (Exception ex) {
            //                Console.WriteLine(ex.Message);
            //            }
            //            finally {
            //                if (lockTaken) sl.Exit();
            //            }
            //        }
            //    }));
            //});

            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine($"Final Balance {ba.Balance}");

            // eg 2
            //LockRecursion(5);

            /// 
            /// ------------------  Spin locking
            #endregion

            #region 2 Interlocked Operations
            /// -----   Interlocked Operations
            /// 
            //var tasks = new List<Task>();
            //var ba = new BankAccount();
            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            ba.Deposit(100);
            //        }
            //    }));
            //});
            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            ba.Withdraw(100);
            //        }
            //    }));
            //});

            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine($"Final Balance {ba.Balance}");

            /// 
            /// -----  Interlocked Operations
            #endregion

            #region 1 Cretical Section Problem 
            /// -----   Critical Sections
            /// 
            //var tasks = new List<Task>();
            //var ba = new BankAccount();
            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            ba.Deposit(100);
            //        }
            //    }));
            //});
            //Enumerable.Range(0, 10).ToList().ForEach(x => {
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int i = 0; i < 1000; i++) {
            //            ba.Withdraw(100);
            //        }
            //    }));
            //});

            //Task.WaitAll(tasks.ToArray());
            //Console.WriteLine($"Final Balance {ba.Balance}");

            /// 
            /// -----   Critical Sections
            #endregion

            Console.ReadKey();
        }

        #region 3 Spin Locking
        //static SpinLock sl = new SpinLock(true);

        //public static void LockRecursion(int x) {
        //    bool lockTaken = false;
        //    try {
        //        sl.Enter(ref  lockTaken);
        //    }
        //    catch (LockRecursionException ex) {
        //        Console.WriteLine($"Exception : {ex}");
        //    }
        //    finally {
        //        if (lockTaken) {
        //            Console.WriteLine($"Took a look, x = {x}");
        //            LockRecursion(x - 1);
        //            sl.Exit();
        //        }
        //        else {
        //            Console.WriteLine($"failed to take a lock, x = {x}");
        //        }
        //    }
        //}
        #endregion
    }
}
