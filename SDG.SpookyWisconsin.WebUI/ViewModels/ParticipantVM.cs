using SDG.SpookyWisconsin.BL.Models;

namespace SDG.SpookyWisconsin.WebUI.ViewModels
{
    public class ParticipantVM
    {
        public BL.Models.Participant Participant { get; set; }
        public List<HauntedEvent> HauntedEvents { get; set; }

        public IFormFile File { get; set; }
    }
}
