using SGD.SpookyWisconsin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblUser : IEntity
    {
        public Guid Id { get; set; }
        public string SortField { get { return Username; } }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
