using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Merch
    {
        public Guid Id { get; set; }
        [DisplayName("Merch Name")]
        public string MerchName { get; set; }
        [DisplayName("In Stock")]
        public int InStkQty { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }

    }
}
