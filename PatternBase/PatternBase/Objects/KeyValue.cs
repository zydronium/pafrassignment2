﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Objects
{
    class KeyValue
    {
        public string key { get; set; }
        public string value { get; set; }

        public override string ToString()
        {
            return key + "-" + value;
        }
    }
}
