using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protobuff_T1 {
    [Serializable]
    public class MyMessage {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
