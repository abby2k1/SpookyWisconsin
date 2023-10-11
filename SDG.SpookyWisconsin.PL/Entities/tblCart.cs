using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblCart
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid MerchId { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get; set; }
    }
}
