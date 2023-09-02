using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Pattern {
    class Program {
        static void Main(string[] args) {

            SortedList studentRecord = new SortedList();

            studentRecord.Add("Ronny");
            studentRecord.Add("Bobby");
            studentRecord.Add("Kate");
            studentRecord.Add("Mike");
            studentRecord.Add("Taison");
            studentRecord.Add("Walls");
            studentRecord.Add("Allen");


            studentRecord.SetSortStrategy(new QuickSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new ShellSort());
            studentRecord.Sort();

            studentRecord.SetSortStrategy(new MergeSort());
            studentRecord.Sort();

            Console.ReadKey();
        }
    }
}