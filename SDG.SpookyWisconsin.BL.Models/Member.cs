using System;
using System.Collections.Generic;
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
        public bool NewsLetterOpt { get; set; }
        public bool MemberOpt { get; set; }
    }
}
