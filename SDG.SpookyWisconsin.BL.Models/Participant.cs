using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Participant
    {
        public Guid Id { get; set; }
        public Guid HauntedEventId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
