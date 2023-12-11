using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public Guid TierId { get; set; }

        public Guid NewsLetterId { get; set; }
        [DisplayName("Tier")]
        public string Tier { get; set; }
        [DisplayName("News Letter Opt")]
        public string NewsLetterOpt { get; set; }
        [DisplayName("Membership Opt")]
        public string MemberOpt { get; set; }
    }
}
