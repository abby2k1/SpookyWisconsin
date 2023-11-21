using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
