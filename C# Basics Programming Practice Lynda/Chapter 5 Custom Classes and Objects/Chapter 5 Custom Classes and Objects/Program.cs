using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_5_Custom_Classes_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            // defining a class lec

            ///////////////////////////////
            // lees test 
            //////////////////////////

            //Console.Write("Enter name : ");
            //string entereName = Console.ReadLine();

            //Console.Write("Enter age :");
            //int enterAge = int.Parse(Console.ReadLine());

            //Console.Write("are you fucked or not yes/no : ");
            //string isfuckedInp = Console.ReadLine();

            //bool inpFuck = isFucked(isfuckedInp);

            //Person person = new Person(entereName, enterAge, inpFuck);

            //Console.WriteLine("------------------------------------------------------------\n" +
            //                 "Name is : {0} \nAge is : {1} \nIf is fucked is : {2}" +
            //    " \n------------------------------------------------------------", person.nameshit, person.ageshit, person.isFuckedF);


            //////////////////////////
            //// my class
            //////////////////////////

            //MyClass myC = new MyClass();
            //Console.WriteLine("Calling myFunction: {0}", myC.myFunction());
            //Console.WriteLine("Using a static member: {0}", MyClass.myStaticInt);


            //////////////////////////////////
            // access modifiers in c#
            ////////////////////////////////

            // this wine shit he only does is to sho us that we can't see the protected or provate fields
            //Wine w1 = new Wine("Mark Ryan Dissident", 52.00m);
            //Wine w2 = new Wine("DeLille Chaleur Estate", 75.00m);
            //w1.Description = "Dark and brooding";
            //Console.Write(w1.Description);


            /////////////////
            // c# does automatic set n get
            /////////////////////////
            /// like 
            /// there are readonly and write only properties, if you only create a set then its write only and if you create 
            /// only get its  a readonly function or some shit
            //Person p = new Person();
            //p.nameshit = " the name that targerts the set function";
            //Console.Write("\nname is retured by automaticly returned value by auto get shit\n"+p.nameshit);
            //////////////

            ///////////////
            /// properties from wine class
            ////////////////////////////////////
            //// Create some new Wine objects
            //Wine w1 = new Wine(2003, "Chateau Ste. Michelle Merlot", "Seven Hills", 23.50m);
            //Wine w2 = new Wine(2005, "Mark Ryan Dissident", "Ciel du Cheval", 40.00m);

            //// Write out the property values
            //// Note that in these cases we are using the property getters
            //Console.WriteLine("Wine 1: {0}, {1}", w1.MenuDescription, w1.Price);
            //Console.WriteLine("Wine 2: {0}, {1}", w2.MenuDescription, w2.Price);
            //Console.WriteLine();

            //// change the wholesale price of one of the wines using the setter
            //w2.Price = 45.0m;

            //// write out the wine description, note how the retail price automatically changes
            //Console.WriteLine("Wine 2: {0}, {1}", w2.MenuDescription, w2.Price);

            //////////////////
            /// difference between value type and refferance type in c#
            /////////////////////////
            /// so Value types are 
            /// int, long , float ,decimal,short,char,byte,bool,struct
            /// refferance types are 
            /// class, array , delegate , interface
            /// ///////////////////////////////////////
            ///        differance between them 
            /// ///////////////////////////////////////
            /// the only differance between them is  how they are handdled 
            /// 
            // value types
            //var i = 10;


            //testFunc1(i);
            //Console.WriteLine("var i's value is {0} ", i);
            //Console.WriteLine();
            /// the output is arg1 = 20 and when we come out from the function the i again = 10 
            /// this is because when we pass value to arg1 it is passed as a copy so there is no harm done to original value

            // refferance type 
            //Point p = new Point();
            //p.x = 10;
            //p.y = 10;
            //Console.WriteLine("value before calling function \t\t\t\t\t p.x is {0}", p.x);
            //testFunc2(p);
            //Console.WriteLine("value  after exiting function \t\t\t\t\t p.x is {0}", p.x);

            Console.ReadLine();
        }

        /// ////////////////////////////////
        /// lees shit method
        /// //////////////////////////////
        /// 
        //public static bool isFucked(string isfuckedInp)
        //{
        //    bool isfucked = false;

        //    if (isfuckedInp.ToLower().Equals("yes"))
        //    {
        //        isfucked = true;
        //    }
        //    else if (isfuckedInp.ToLower().Equals("no"))
        //    {
        //        isfucked = false;
        //    }
        //    return isfucked;
        //}
        /////////////////////////////////////

        /// //////////////////////////////////////
        ///                                         value type and refferance types
        /// /////////////////////////////////////
        ///         functions from lecs

        static void testFunc1(int arg1)
        {
            arg1 += 10;
            Console.WriteLine("testFunc1 ( arg1 +10 is {0} )", arg1);
        }

        static void testFunc2(Point pt)
        {
            Console.WriteLine("value resieved as argument and before addition >\t\t pt.x is {0}", pt.x);
            pt.x += 10;
            Console.WriteLine("value after addition and before exiting the function scope >\t pt.x is {0}", pt.x);
        }
        /// ///////////////////////////////////////////////////
    }
                                         // in c# we can define a class anywhere just like C++ 
    }
