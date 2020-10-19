using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class Story
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; set; }
        public string Type { get; set; }
        public DateTime Modified { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public ICollection<CharacterStory> CharacterStories { get; set; }
        public ICollection<ComicStory> ComicStories { get; set; }
        public ICollection<EventStory> EventStories { get; set; }
        public ICollection<SerieStory> SerieStories { get; set; }
        public ICollection<StoryCreator> StoryCreators { get; set; }
    }
}
