﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schools_api_core.Configuration
{
    public class EmailClass
    {
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
