using SDG.SpookyWisconsin.BL.Models;
namespace SDG.SpookyWisconsin.WebUI.ViewModels
{
    public class HauntedEventVM
    {
        public BL.Models.HauntedEvent HauntedEvent { get; set; }
        public List<HauntedLocation> HauntedLocations { get; set; }
        public List<ParticipantVM> Participants { get; set; }

        public IFormFile File { get; set; }
    }
}
