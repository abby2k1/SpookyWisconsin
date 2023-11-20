using SDG.SpookyWisconsin.BL.Models;

namespace SDG.SpookyWisconsin.WebUI.ViewModels
{
    public class TourVM
    {
        public BL.Models.Tour Tour { get; set; }
        public List<HauntedLocation> HauntedLocations { get; set; }

        public IFormFile File { get; set; }
    }
}
