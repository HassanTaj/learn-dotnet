//#define DEBUGCODE
//#define JOE 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_10_Advanced_Csharp {


    #region Deligets are defined here

    public delegate int numberFunction(int x);

    #endregion

    #region Event handler deleget
    public delegate void myEventHandler(string y);
    #endregion
    class Program {

        #region This is the main function
        static void Main(string[] args) {


            /// ///////////////////////////////////////////
            ///      Event Handler
            /// ///////////////////////////////////////
            /// 

            //EventExample myEvt = new EventExample();

            //myEvt.valueChanged += new myEventHandler(myEvt_valueChanged);

            //string str;
            //do {
            //    str = Console.ReadLine();
            //    if (!str.Equals("exit"))
            //        myEvt.Val = str;

            //} while (!str.Equals("exit"));
            
            /// //////////////////////////////////////////////

            /// ///////////////////////////////////////////
            ///      Delegate
            /// ///////////////////////////////////////
            /// delegates are more like call back
            /// functions in other languages

            //numberFunction f = Square;
            //Console.WriteLine("result of the delegate is {0}", f(5));

            //// now change the delgate
            //f = Cube;
            //Console.WriteLine("result of the delegate is {0}", f(5));

            /// /////////////////////////////////////////////////

            /// ///////////////////////////////////////////
            ///     Preprocessor Directives 
            /// ///////////////////////////////////////
            /// #define   -- define symbol
            /// #undef    --  undefine symbol
            /// 
            /// # if
            /// #else
            ///             use logic to see if a symbol is defined
            /// #elif            
            /// #endif
            /// 
            ///             used for documentation of code
            /// #region
            /// #endregion
            ///        
            ///  in C# we don't use preprocessor directives to make constants like in C++
            ///  we use Const keyword in c# 
            ///  we use preprocessor directives just to effect the compilation of the code
            ///  
            /// 


            //#if DEBUGCODE

            //            /// these #if #else #endif are checking to see if a symbol is defined
            //            /// forexample here its the symbol 'DEBUGCODE'
            //            Console.WriteLine("This is only in debug code");
            //#else
            //            /// the compiler will compeletely ignore the code in this block
            //            Console.WriteLine("This only gets written out in non-debug code");
            //#endif

            //#if JOE
            //            // if the symbol joe is defined this shitty block will be executed 
            //            Console.WriteLine("Joe was here!");
            //            Console.WriteLine("Let's fuck em up");
            //#endif

            /// //////////////////////////////////////////////////////////////


            /// /////////////////////////////////////////////
            ///        Optional and Named Parameers 
            /// ///////////////////////////////////////////
            /// Opetional parameters 
            ///   means setting defautl values for parameters

            /// optional call 

            //myOptionalParamFunction(); // value of a and be will be defaults a=0  and b=1;
            //myOptionalParamFunction(10); // a is 10, b is default
            //myOptionalParamFunction(20, 10);// a=20 and b=10

            //myOptionalParamFunction(15);
            //myOptionalParamFunction(10, 2.71828d);
            //myOptionalParamFunction(10, 2.71828d, "a different string");
            // myOptionalParamFunc(10, "a different string");

            // Now do both
            //myOptionalParamFunction(10, param3: "named and optional in same call!");

            /// named call

            //myNamedParameFunction(stateName: "Washington", zipCode: 98121, cityName: "Seattle");
            //myNamedParameFunction(cityName: "San Francisco", zipCode: 94109, stateName: "California");
            //myNamedParameFunction(zipCode: 94109, cityName: "New York", stateName: "New York");


            //myNamedParameFunction(b: 5, a: 3);
            //myNamedParameFunction(5, b: 3); // a=5 and b=3
            //myNamedParameFunction(3, 7);


            /// ////////////////////////////////////////////////////

            /// /////////////////////////////////////////////
            ///        FUnction Parameter MOdifiers 
            /// ///////////////////////////////////////////
            ///  ref  causes a paremeter to be passed by referance
            ///  out  allows a return value to be passed back via a parameter

            //int x = 10;
            // int res = myFunction(ref x);  // x will now be 20 

            //Console.WriteLine("the shit of ref is > {0}", res);


            //double a = 9.0, theSquare, theSqrt;
            //SqurAndRoot(a, out theSquare, out theSqrt);
            //Console.WriteLine("the square of {0} is {1} and swuare root is {2}",a,theSquare , theSqrt) ;

            /// /////////////////////////////////////////////////


            /// //////////////////////////////////////
            ///     Variable and unknown prameters
            /// ///////////////////////////////
            /// 

            //int result;
            //result = addNumbers(10, 10, 10, 10, 10);
            //Console.WriteLine("after adding 5 numbers : "+ result);

            //result = addNumbers(10, 10, 10, 10, 10,10, 10, 10, 10, 10);
            //Console.WriteLine("after adding 10 numbers : " + result);


            /// /////////////////////////////////////


            Console.ReadLine();
        }
        #endregion

         #region EventHandlers Example Functions
        static void myEvt_valueChanged(string newValue) {

            Console.WriteLine("The value changed to {0}", newValue);

        }
        #endregion

        #region Delegate Example functions
        static int Square(int num) {
            return num * num;
        }

        static int Cube(int num) {
            return num * num * num;
        }
        #endregion

        #region Static excercise functions
        /// //////////////////////////////////////////
        ///     Opetional  and named parameters 
        /// ////////////////////////////////////
        /// 

        static void myOptionalParamFunction(int param1, double param2 = 3.14159d, string param3 = "placeholder string") {
            Console.WriteLine("Called with: \n\tparam1 {0}, \n\tparam2 {1}, \n\tparam3 {2}", param1, param2, param3);
        }

        static void myNamedParameFunction(string cityName, string stateName, int zipCode) {
            Console.WriteLine("Arguments passed: \n\tcityName is {0}, \n\tstateName is {1}, \n\tzipCode is {2}",
                        cityName, stateName, zipCode);
        }



        /// //////////////////////////////////////
        ///    FUnction Parameter MOdifiers 
        /// ///////////////////////////////

        //static int myFunction(ref int param1) {
        //    int res;
        //    res = param1 + 10;
        //    return res;
        //} 

        //static void SqurAndRoot(double numer , out double sq , out double sqrt) {
        //    sq = numer * numer;
        //    sqrt = Math.Sqrt(numer);
        //}


        /// //////////////////////////////////////
        ///     Variable and unknown prameters
        /// ///////////////////////////////
        static int addNumbers(params int[] nums) {
            int total = 0;

            foreach(int number in nums) {
                total += number;
            }
            return total;
        }
        #endregion
    }
}
