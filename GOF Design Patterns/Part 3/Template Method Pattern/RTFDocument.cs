using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method_Pattern {
    /// <summary>
    /// 'ConcreteClass' concrete class
    /// </summary>
    class RTFDocument : DocumentReader {
        public override void InterpretDocumentFormat() {
            Console.WriteLine("Document file is Processed with RTF interpreter");
        }
    }
}
