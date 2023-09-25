﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class NewsLetter
    {
        public Guid Id { get; set; }
        public Guid HauntedEventId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
