using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Command_Pattern {
    /// <summary>
    /// This code demonstrates the command pattern used in a simple calculator
    /// with unlimited number of undo's and redo's. Note that in c# the word 
    /// 'operator' is a keyword. Prefixing it with '@' allows using it as n identifier.
    /// </summary>
    
    /// <summary>
    /// Command Degsine pattern
    /// </summary>
    class Client {

        static void Main(string[] args) {
            // create user and let them compute

            User user = new User();

            // letem press calcultor buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // undo all commands
            user.Undo(4);

            // redo all commands
            user.Redo(2);

            // wait for user 
            Console.ReadKey();
        }
    }
}
