using SGD.SpookyWisconsin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblTour : IEntity
    {
        public Guid Id { get; set; }
        public string SortField { get { return TourName; } }
        public Guid HauntedLocationId { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
    }
}
