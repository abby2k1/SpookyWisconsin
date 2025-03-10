﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Guid UserId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public Guid AddressId { get; set; }
        public string Address {  get; set; }
        public string Email { get; set; }
    }
}
