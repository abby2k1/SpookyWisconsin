using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Cart
    {
        /*public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<Merch> Items { get; set; }
        public Guid MerchId { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Total Cost")]
        public double TotalCost { get; set; }*/
        
        public List<OrderItem> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal SubTotal
        {
            get
            {
                decimal amt = 0;
                //return Items.Count * ITEM_COST; 
                foreach (var item in Items)
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

        public Cart()
        {
            Items = new List<OrderItem>();
        }
    }
}
