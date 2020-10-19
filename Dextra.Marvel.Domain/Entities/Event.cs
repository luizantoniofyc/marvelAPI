using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public ICollection<Url> Urls { get; set; }
        public ICollection<CharacterEvent> CharacterEvents { get; set; }
        public ICollection<ComicEvent> ComicEvents { get; set; }
        public ICollection<EventCreator> EventCreators { get; set; }
        public ICollection<EventSerie> EventSeries { get; set; }
        public ICollection<EventStory> EventStories { get; set; }
    }
}
