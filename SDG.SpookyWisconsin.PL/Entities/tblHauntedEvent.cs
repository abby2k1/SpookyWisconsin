using SGD.SpookyWisconsin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblHauntedEvent : IEntity
    {
        public Guid Id { get; set; }
        public string SortField { get { return Date.ToString(); } }
        public Guid HauntedLocationId { get; set; }
        public Guid ParticipantId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
