using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator_Pattern.Iterator;

namespace Iterator_Pattern.Aggregate {
    public class NYPaper : INewspaper{
        private List<string> _reporters;
        public NYPaper() {
            _reporters = new List<string> {
                "John Mesh - NY",
                "Susanna Mesh - NY",
                "Paul Randy - NY",
                "Kim Rows - NY",
                "Kim Fields - NY",
            };
        }

        public IIterator CreateIterator() {
            return new NYPaperIterator(_reporters);
        }
    }
}
