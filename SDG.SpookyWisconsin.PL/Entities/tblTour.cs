using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.PL.Entities
{
    public partial class tblTour
    {
        public int Id { get; set; }
        public int HauntedLocationId { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
    }
}
