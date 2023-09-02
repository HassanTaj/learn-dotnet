using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator_Pattern.Iterator {

    // Iterator
    public interface IIterator {
        void First(); // sets current element to the first elements
        string Next(); // advances current to next element
        bool IsDone(); // check if end of collection
        string CurrentItem(); // returns current element
    }
}
