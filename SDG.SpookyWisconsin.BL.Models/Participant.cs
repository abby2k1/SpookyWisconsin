using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Participant
    {
        public Guid Id { get; set; }
        [DisplayName("Haunted Event")]
        public string HauntedEventName { get; set; }
        public Guid HauntedEventId { get; set; }
        [DisplayName("Customer")]
        public string CustomerName { get; set; }
        public Guid CustomerId { get; set; }
    }
}
