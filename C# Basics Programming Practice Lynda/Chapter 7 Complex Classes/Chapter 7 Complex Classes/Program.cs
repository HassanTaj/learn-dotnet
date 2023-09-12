using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_7_Complex_Classes {
    class Program {
        static void Main(string[] args) {

            /// ////////////////////////////////////
            /// 
            ///     Over Loading Methods Example
            /// 
            ///  ////////////////////////////////

            //Wine w1 = new Wine("Charles Shaw Merlot");
            //Wine w2 = new Wine("Mark Ryan Dissident", 2004);
            //Wine w3 = new Wine("Dom Perignon", 120.00m, 1994);

            //Console.WriteLine("Name > {0} ", w1.Name);
            //Console.WriteLine("Year > {0} , Name > {1}", w2.Year, w2.Name);
            //Console.WriteLine("Year > {0} , Name > {1} , Prince > {2} ", w3.Year, w3.Name, w3.price);
            ///
            /// ////////////////////////////////////

            /// ///////////////////////////////////
            /// 
            ///  OverRidding Methods Of SuperClass
            /// 
            /// /////////////////////////////////
            ///  virtual :
            ///     tells the compiler that the method can be overriden by the base classes
            /// override :
            ///     tells the compiler that this method is overriding the same named mehtod
            ///         in the base class
            /// base  : 
            ///     in the subclass, calls the base calss' method
            ///         base.myFunction();
            /// ////////////////////

            //subClass sub = new subClass();
            //sub.doSomething();

            //baseClass obj1 = new subClass();
            //obj1.doSomething();

            //baseClass baseReferance = new baseClass();
            //baseReferance.doSomething();

            /// /////////////////////////////////

            /// //////////////////////////////////
            /// 
            ///         Abstract Classes 
            ///  
            /// ////////////////////////////////

            //abstractDrivedSubclass abDrivedClass = new abstractDrivedSubclass();
            //int result = abDrivedClass.myMethod(5,6);
            //Console.WriteLine("result is = " + result);

            //myAbstractClass myabstrct = new myAbstractClass(); 
            // error can't create the instance of abstract calss

            /// 
            /// /////////////////////////////////

            //baseClass obj1 = new subClass();
            // obj1.doSomething();

            /// //////////////////////////////////
            /// 
            ///         sealed classes 
            /// 
            /// /////////////////////////////

            //mySealedClass msc = new mySealedClass();
            ///
            ///   can't be inherited but 
            /// can't be instentiated eiter
            /// /////////////////////////////

            /// /////////////////////////////////
            /// 
            ///         Structures / structs 
            /// 
            /// ///////////////////////////////
            //Point p1 = new Point(100,100);

            //Point p2 = new Point();
            //p2.x = 50;
            //p2.y = 75;

            //Console.WriteLine("x = "+p2.x +"y = "+p2.y);
            /// 
            /// ///////////////////////////////

            /// ///////////////////////////////////
            /// 
            ///         InterFaces
            /// 
            /// /////////////////////////////////
            /// 
            //InterfaceImplimentationClass ific = new InterfaceImplimentationClass();
            //ific.SayHellow();
            //ific.SayGoodBye();
            //ific.SayFuckYou();

            /// 
            /// ///////////////////////////

            Console.ReadLine(); 
        }
    }



    /// //////////////////////////////////
    /// 
    ///         sealed classes 

    /// /////////////////////////////

    //public  sealed class mySealedClass {
    //    public static string myMethod(int arg1) {
    //        return String.Format("You sent me the number {0}",arg1);
    //    }
    //}

    //class mySubClass : myExampleClass {
    // cann't be inherited because base class is sealed
    //}
}