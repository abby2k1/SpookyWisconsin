using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Order
    {
        /*public Guid Id { get; set; }
        public Guid CartId { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        public Guid CustomerId { get; set; }
        [DisplayName("Ordered Date")]
        public DateTime OrderDate { get; set; }
        [DisplayName("Delivered Date")]
        public DateTime DeliverDate { get; set; }*/
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        [DisplayName("Ship Date")]
        public DateTime ShipDate { get; set; }
        [DisplayName("Items")]
        public List<OrderItem>? OrderItems { get; set; }
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal SubTotal
        {
            get
            {
                if (OrderItems == null)
                { return 0; }
                //return Items.Count * ITEM_COST;
                decimal amt = 0;
                foreach (OrderItem item in OrderItems)
                {
                    amt += (item.Cost * item.Quantity);
                }
                return amt;
            }
        }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Tax { get { return SubTotal * .055m; } }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Total { get { return SubTotal + Tax; } }
        [DisplayName("Customer Full Name")]
        public string CustomerFullName { get; set; }
        public string Username { get; set; }
        [DisplayName("User Full Name")]
        public string UserFullName { get; set; }
    }
}
