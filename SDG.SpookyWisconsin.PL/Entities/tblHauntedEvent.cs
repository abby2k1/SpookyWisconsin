using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblHauntedEvent
    {
        public int Id { get; set; }
        public int HauntedLocationId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
