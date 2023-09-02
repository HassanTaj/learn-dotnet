using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterator_Pattern.Iterator;

namespace Iterator_Pattern.Aggregate {
    public class LAPaper : INewspaper {

        private string[] _reporters;
        public LAPaper() {
            _reporters = new[] {
                "Ronald Smith - LA",
                "Dandy Glover - LA",
                "Jerry Straight - LA",
                "Jerry Gay - LA",
                "Jerry Homo - LA",
            };
        }

        public IIterator CreateIterator() {
            return new LAPaperIterator(_reporters); 
        }
    }
}
