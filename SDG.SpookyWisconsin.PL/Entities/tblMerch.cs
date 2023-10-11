using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblMerch
    {
        public Guid Id { get; set; }
        public string MerchName { get; set; }
        public int InStkQty { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
    }
}
