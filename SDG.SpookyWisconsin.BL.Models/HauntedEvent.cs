using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class HauntedEvent
    {
        public Guid Id { get; set; }

        public Guid HauntedLocationId { get; set; }
        [DisplayName("Haunted Event Location")]
        public string LocationName { get; set; } //Haunted Location Name
        public Guid ParticipantId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        [DisplayName ("Image")]
        public string ImagePath { get; set; }
    }
}
