using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_Pattern {
    class Program {
        static void Main(string[] args) {
            
            CollageLoan collageLoan = new CollageLoan();
            // Evaluate loan elegibility
            Student student = new Student { Name = "Hunter Sky" };
            bool isEligible = collageLoan.IsEligible(student, 75000);

            string elg = isEligible ? "Apprived" : "Rejected";
            Console.WriteLine($"\n{student.Name} has been {elg}");




            Console.ReadKey();
        }
    }
}