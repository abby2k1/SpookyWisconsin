﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Tier
    {
        public Guid Id { get; set; }
        public string TierName { get; set; }
        public int TierLevel { get; set; }
    }
}
