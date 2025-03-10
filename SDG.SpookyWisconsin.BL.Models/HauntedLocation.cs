﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class HauntedLocation
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        public string Name { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }
    }
}
