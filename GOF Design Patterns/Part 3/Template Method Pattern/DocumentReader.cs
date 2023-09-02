using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Method_Pattern {
    /// <summary>
    /// 'AbstractCLass' abstract class
    /// </summary>
    abstract class DocumentReader {

        // default steps
        public void LoadFile() {
            Console.WriteLine("Document File Loaded");
        }

        // steps that will be overidden by subclass
        public abstract void InterpretDocumentFormat();

        // default step
        public void Open() {
            Console.WriteLine("File Opened");
        }

        // 'Template Method'
        public void OpenDocument() {
            this.LoadFile();
            this.InterpretDocumentFormat();
            this.Open();
        }

    }
}
