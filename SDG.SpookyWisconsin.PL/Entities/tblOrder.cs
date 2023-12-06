using SGD.SpookyWisconsin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblOrder : IEntity
    {
        //Ask group
        public Guid Id { get; set; }
        public string SortField { get { return OrderDate.ToString(); } }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
    }
}
