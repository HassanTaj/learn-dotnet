using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_5_Custom_Classes_and_Objects
{
    class MyClass
    {

        // defining a class

        int myInteger;
        string myMessage;
        public static int myStaticInt = 100;

        public int myFunction()
        {
            return myInteger;
        }

        public MyClass()
        {
            myInteger = 50;
            myMessage = "This is a string";
        }

    }
}
