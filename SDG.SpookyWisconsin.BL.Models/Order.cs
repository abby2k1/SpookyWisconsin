using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        public Guid CustomerId { get; set; }
        [DisplayName("Ordered Date")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Delivered Date")]
        public DateTime DeliverDate { get; set; }
    }
}
