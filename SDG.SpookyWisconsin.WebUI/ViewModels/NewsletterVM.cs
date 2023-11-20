using SDG.SpookyWisconsin.BL.Models;

namespace SDG.SpookyWisconsin.WebUI.ViewModels
{
    public class NewsletterVM
    {
        public BL.Models.NewsLetter NewsLetter { get; set; }
        public List<HauntedEvent> HauntedEvents { get; set; }

        public IFormFile File { get; set; }
    }
}
