using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class Program
    {
        enum names
        {
            HASSAN,HUSAIN,HUSNAIN
        }
        static void Main(string[] args)
        {

            //////////////////////////////////////////////////////////////////////////
            ////////////////         Chapter 3 program  flow          ///////////////
            ////////////////////////////////////////////////////////////////////////

            /*
            //////////////////////////////////////////////////////////////////
            ///////// using break and continue
            /////////////////////////////////////////////////////////////////
            // loops vid

            foreach (var val in Enum.GetValues(typeof(names)))
            {
                if(val.ToString().ToLower().Equals("husain"))
                {
                    // get all the fucking data i need yeahhhh the fuckin syntaxxxx
                    Console.WriteLine("we'll continuet from here -> {0}  <-  this value",val);
                    continue;
                }else if (val.ToString().ToLower().Equals("husnain"))
                {
                    Console.WriteLine("we'll break here cause end of the list is the string > "+val);

                }
            }

            //works fine
                    */






            /*
           //////////////////////////////////////////////////////////////////
           /// how to get values from an enum in C#
           /////////////////////////////////////////////////////////////////
            foreach (var val in Enum.GetValues(typeof(names)))
            {

                Console.WriteLine("my name is : " + val);
            }
            */

            // Console.WriteLine("my name is : "+names.HASSAN);

            /*

        // why does it always give string ???
        Console.Write("Enter any Object please : ");
            Object o = Console.ReadLine();

            if(o is int)
            {
                Console.Write("Enter obj is a int ");

            }
            else if (o is string)
            {
                Console.Write("entered obj is a string");

            }
            */


            Console.ReadLine();

        }
    }

}
