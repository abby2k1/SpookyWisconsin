using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblHauntedLocation
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
    }
}
