﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternBase.Model
{
    abstract class Component
    {
        public string name;
        public string description;

        public string getName()
        {
            return name;
        }

        public void setName(string nm)
        {
            name = nm;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string desc)
        {
            description = desc;
        }
    }
}