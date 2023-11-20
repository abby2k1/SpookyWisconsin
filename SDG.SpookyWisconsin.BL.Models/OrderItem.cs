using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid MerchId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        [DisplayName("Product")]
        public string ProductName { get; set; }
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
    }
}