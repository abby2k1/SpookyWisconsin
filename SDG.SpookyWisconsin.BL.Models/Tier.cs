using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Tier
    {
        public Guid Id { get; set; }
        [DisplayName("Tier")]
        public string TierName { get; set; }
        [DisplayName("Tier Level")]
        public int TierLevel { get; set; }
    }
}
