using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblMember
    {
        public Guid Id { get; set; }
        public Guid TierId { get; set; }
        public Guid NewsLetterId { get; set; }
        public string NewsLetterOpt { get; set; }
        public string MemberOpt { get; set; }
    }
}
