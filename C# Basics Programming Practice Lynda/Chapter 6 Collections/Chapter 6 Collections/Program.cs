using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_6_Collections {
    class Program {
        static void Main(string[] args) {
            ///  Collections in C#
            /// arrays
            /// arraylist
            /// list
            /// stacks
            /// queue
            /// dictionaries
            /// 

       //  Arrays
            Console.WriteLine("\n------------- Arrays --------------\n");
            int[] manyValues = { 1, 18, 745, 34, 16, 94, 73, 4, 17, 200 };
           
            Console.WriteLine("The fourth number is {0}", manyValues[3]);

            // sorted values
            //Array.Sort(manyValues);
            // reversed values
            // Array.Reverse(manyValues);
            Console.WriteLine(" length of array is > " + manyValues.GetLength(0));
            Console.WriteLine(" length of array is > " + manyValues.Length);
            foreach (int i in manyValues) {
                Console.WriteLine("{0}",i);
            }

            
            string[] myStrings = { "Joe", "Marini", "Teaches", "C#" };
            for (int i = 0; i < 4; i++) {
                Console.WriteLine("{0}", myStrings[i]);
            }
           
            int[] otherValues = manyValues;
            otherValues[3] = 0;
            Console.WriteLine("The fourth number is {0}", manyValues[3]);

            Array.Sort(manyValues);
            Console.WriteLine("The fourth number is {0}", manyValues[3]);

     // ArrayLists
            Console.WriteLine("\n------------- ArrayList --------------\n");
            ArrayList myAL = new ArrayList();
            myAL.Add("one");
            myAL.Add(2);
            myAL.Add("three");
            myAL.Add(4);
            myAL.Insert(0, 1.25f);

            foreach (object o in myAL) {
                if (o is int) {
                    Console.WriteLine("{0}", o);
                }
                else if(o is string) {
                    Console.WriteLine("{0}", o);
                }
            }
            
      // Stacks

            Console.WriteLine("\n------------- Stack --------------\n");
            Stack myStack = new Stack();
            myStack.Push("item 1");
            myStack.Push("item 2");
            myStack.Push("item 3");
            Console.WriteLine("{0} Items on the stack", myStack.Count);

            // Have a peek at the top item
            Console.WriteLine("{0} < peek at top", myStack.Peek());

            myStack.Pop(); // pops "item 3" off the top
            // now "item 2" is the top item
            Console.WriteLine("{0}", myStack.Peek());

            myStack.Clear(); // get rid of everything
            Console.WriteLine("{0} Items on the stack", myStack.Count);
            
     //  Queues

            Console.WriteLine("\n------------- Queues --------------\n");
            Queue myQ = new Queue();
            myQ.Enqueue("item 1");
            myQ.Enqueue("item 2");
            myQ.Enqueue("item 3");
            myQ.Enqueue("item 4");

            Console.WriteLine("There are {0} items in the Queue", myQ.Count);

            while (myQ.Count > 0){

                string str = (string) myQ.Dequeue();
                Console.WriteLine("Dequeueing object {0}", str);
            }
            
     //  Dictionaries

            Console.WriteLine("\n------------- Dictionaries --------------\n");
            Hashtable myHT = new Hashtable();
            myHT.Add("SFO", "San Francisco Airport");
            myHT.Add("SEA", "Seattle Tacoma Airport");
            myHT["IAD"] = "Washington Dulles Airport";

            Console.WriteLine("Value for key {0} is {1}", "SEA", myHT["SEA"]);

            Console.WriteLine("There are {0} items", myHT.Count);
            //myHT.Remove("SFO");
            if (myHT.ContainsKey("SFO")){
                Console.WriteLine("Value for key {0} is {1}", "SFO", myHT["SFO"]);
            }

            Console.ReadLine();
        }
    }
}