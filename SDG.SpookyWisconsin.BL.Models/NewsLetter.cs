using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class NewsLetter
    {
        public Guid Id { get; set; }
        public Guid HauntedEventId { get; set; }
        [DisplayName("Haunted Event")]
        public string HauntedEventName { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
    }
}
