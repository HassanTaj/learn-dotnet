using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8_Exceptions {
    class Program {

        /// <summary>
        ///   Creating Custom exceptions 
        /// </summary>
        /// <returns></returns>
        static string GetName() {
            string s = Console.ReadLine();
            if (s.Equals("Joe"))
                throw new NoJoesException();

            return s;  
        }

        /// <summary>
        ///  Re throwing exception example
        /// </summary>
        static void DoSomeMath() {
            int x = 10, y = 0;
            int result;

            try {
                result = x / y;
                Console.WriteLine("Result is {0}",result);
            }
            catch {
                Console.WriteLine("Error in DoSomeMath()");
                
                throw new ArithmeticException(); // this is throwing a new exception 
               

                //throw; // this is called re throw
            }
        }
       // /////////////////////////////////////////
        static void Main(string[] args) { 
            Console.WriteLine("\t\t\t  Exceptions  ");  



            /// /////////////////////////////////
            ///  custom exceptions
            /// ///////////////////////////////

            //string theName;

            //try {
            //    theName = GetName();
            //    Console.WriteLine("Hello {0}",theName);
            //}
            //catch (NoJoesException nje) {
            //    Console.WriteLine(nje.Message);
            //    Console.WriteLine("For help, visit: {0}",nje.HelpLink);
            //}
            //finally {
            //    Console.WriteLine("Have a nice day!");
            //}

            /// ///////////////////////////////////
            ///      Throwing exceptions  and rethrowing exceptions
            /// ////////////////////////////////// 

            int x = 10;
            int y = 0;

            try {

                DoSomeMath();
                // throwing simple exception
                //Console.WriteLine("try shit ");
                //int result = x / y;
                //Console.WriteLine("result is = " + result);

            }
            catch {
                Console.WriteLine("hmm, there was an error in there be carefull bitch ");
            }

            // from thowing exceptions
            //catch (Exception ex) {

            //   Console.WriteLine("catch shit made  --> " + ex.Message);


            //}
            finally {
                Console.WriteLine("finally always runs ");
            }
            
            Console.ReadLine();
        }
    }
}