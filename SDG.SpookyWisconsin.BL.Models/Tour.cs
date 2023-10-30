using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDG.SpookyWisconsin.BL.Models
{
    public class Tour
    {
        public Guid Id { get; set; }
        public Guid HauntedLocationId { get; set; }
        [DisplayName("Tour Name")]
        public string TourName { get; set; }
        public string Description { get; set; }
    }
}
