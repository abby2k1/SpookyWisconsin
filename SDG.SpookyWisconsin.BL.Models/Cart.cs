using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<Merch> Items { get; set; }
        public Guid MerchId { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Total Cost")]
        public double TotalCost { get; set; }
    }
}
