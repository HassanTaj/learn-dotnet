using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4_Variables
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            //////////////////////////////////////////////////////////////
            /////////  string for directory paths
            /////////////////////////////////////////////////////////////
            // c# got a new way to representing directories 
            string myDirectory = "C:\\mydir\\somefile.someextension";
            // in c#
            // the @ symbol means i want my string as it is written and it tells compiler 
            // that the back slashes aren't excape siquences so we can get things as such 
            string mydirectry = @"C:\mydir\somefile.someextension";
            */

            // strings are imutable means can't be changed once created

// Chars and Strings

            char myChar = 'a';
            string myString = "  This is a message with a \n newline and spaces in it.  ";
    
            // Do some character tests
            Console.WriteLine("Calling char.IsUpper: {0}", char.IsUpper(myChar));
            Console.WriteLine("Calling char.IsDigit: {0}", char.IsDigit(myChar));
            Console.WriteLine("Calling char.IsLetter: {0}", char.IsLetter(myChar));
            Console.WriteLine("Calling char.IsPunctuation: {0}", char.IsPunctuation(myChar));
            Console.WriteLine("Calling char.IsWhiteSpace: {0}", char.IsWhiteSpace(myChar));
            Console.WriteLine("Calling char.ToUpper: {0}", char.ToUpper(myChar));
            Console.WriteLine("Calling char.ToLower: {0}", char.ToLower(myChar));
            Console.WriteLine();

            // do some string tests
            Console.WriteLine("Calling string.Trim: {0}", myString.Trim());
            Console.WriteLine("Calling string.ToUpper: {0}", myString.ToUpper());
            Console.WriteLine("Calling string.ToLower: {0}", myString.ToLower());
            Console.WriteLine("Calling string.IndexOf: {0}", myString.IndexOf("a"));
            Console.WriteLine("Calling string.LastIndexOf: {0}", myString.LastIndexOf("and"));
            //  Variable Scope

            for (int i = 0; i < 10; i++)
            {
                int var1 = 20;
                Console.WriteLine("The value of var1 at pass {0} is {1} ", i, var1);
            }

            //Console.WriteLine("{0}", var1);

// Type Conversion

            int i1 = 10;
            short x = 5;
            float f = 20.0f;

            i1 = x;

            x = (short)i1;

            f = i1; // it is ok because its an implisit cast

            i1 = (int) f; // will give error because its explisit casting and is from float to int and is needed because datat might get lost

            Console.ReadLine();
        }
    }
}
