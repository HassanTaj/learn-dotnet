﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern {
    /// <summary>
    /// The 'Bridge/Implementor' interface 
    /// </summary>
    interface IMessengeSender {
        void SendMessage(string subject, string body);
    }
}
