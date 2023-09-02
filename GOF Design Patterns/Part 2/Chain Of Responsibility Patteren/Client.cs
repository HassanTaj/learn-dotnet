using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_Of_Responsibility_Patteren {
    class Client {
        static void Main(string[] args) {
            // setup chain of responsibility 

            Approver ronny = new Director();
            Approver nathen = new VicePresident();
            Approver eminem = new President();


            ronny.SetSuccessor(nathen); // ronny forwards to vice president
            nathen.SetSuccessor(eminem); //  nathen forwards to eminem

            // generate and priocess purchase requessts 
            Purchase p = new Purchase(8884, 350, "Assets");
            ronny.ProcessRequest(p);
            p = new Purchase(5675, 33390.10, "Project Poison");
            ronny.ProcessRequest(p);
            p = new Purchase(5676, 144400.00, "Project BBD");
            ronny.ProcessRequest(p);

            Console.ReadLine();
        }
    }
}
