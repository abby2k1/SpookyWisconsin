using SDG.SpookyWisconsin.BL.Models;

namespace SDG.SpookyWisconsin.WebUI.ViewModels
{
    public class HauntedLocationVM
    {
        public BL.Models.HauntedLocation HauntedLocation { get; set; }
        
        public List<Address> Addresses  { get; set; }

        public IFormFile File { get; set; }
    }
}
