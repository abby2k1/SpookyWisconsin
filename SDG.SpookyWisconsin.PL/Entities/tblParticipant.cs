using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblParticipant
    {
        public int Id { get; set; }
        public int HauntedEventId { get; set; }
        public int CustomerId { get; set; }
    }
}
