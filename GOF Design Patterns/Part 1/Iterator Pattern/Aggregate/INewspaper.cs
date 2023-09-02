using Iterator_Pattern.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator_Pattern.Aggregate {
    // Aggregate
    public interface INewspaper {
        IIterator CreateIterator();
    }
}
