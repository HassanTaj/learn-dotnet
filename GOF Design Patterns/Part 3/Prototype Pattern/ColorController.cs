﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern {
    /// <summary>
    /// The 'PrototypeManager' class
    /// </summary>
    class ColorController {
        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key] { 
            get{ return _colors[key]; }
            set { _colors.Add(key, value); }
        }

    }
}
