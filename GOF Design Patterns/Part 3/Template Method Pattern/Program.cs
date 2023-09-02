using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method_Pattern {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("---- Document Reader - PDF Doc -----");
            DocumentReader documentReader = new PDFDocument();
            documentReader.OpenDocument();

            Console.WriteLine();
            Console.WriteLine("---- Document Reader - RTF Doc -----");
            DocumentReader rtfdocumentReader = new RTFDocument();
            rtfdocumentReader.OpenDocument();

        }
    }
}