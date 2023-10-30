using SGD.SpookyWisconsin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblHauntedLocation : IEntity
    {
        public Guid Id { get; set; }
        public string SortField { get { return Name; } }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
