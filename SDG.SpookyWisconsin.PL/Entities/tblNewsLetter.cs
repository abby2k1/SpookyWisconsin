using SGD.SpookyWisconsin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblNewsLetter : IEntity
    {
        public Guid Id { get; set; }
        public string SortField { get { return Date.ToString(); } }
        public Guid HauntedEventId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
