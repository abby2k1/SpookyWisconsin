using SGD.SpookyWisconsin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblTier : IEntity
    {
        public Guid Id { get; set; }
        public string SortField { get { return TierName; } }
        public string TierName { get; set; }
        public int TierLevel { get; set; }
    }
}
