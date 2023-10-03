using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblMember
    {
        public int Id { get; set; }
        public int TierId { get; set; }
        public int NewsLetterId { get; set; }
        public string NewsLetterOpt { get; set; }
        public string MemberOpt { get; set; }
    }
}
