using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblCustomer
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Guid AddressId { get; set; }
        public string Email { get; set; }
    }
}
