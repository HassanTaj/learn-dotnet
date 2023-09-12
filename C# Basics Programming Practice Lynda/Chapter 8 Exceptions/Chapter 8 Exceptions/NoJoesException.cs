using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8_Exceptions {
    class NoJoesException : Exception{
        public NoJoesException() 
            : base("We don't allow no Joes in here!") {
            this.HelpLink = "http://www.joemarini.com/";
        }
    } 
}
