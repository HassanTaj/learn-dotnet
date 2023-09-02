﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method.Implimentation {
    // Creator
    interface ICreditUnionFactory {
        ISavingsAccount GetSavingsAccount(string acctNo);
    }
}
