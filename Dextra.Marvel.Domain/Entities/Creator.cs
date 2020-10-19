using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class Creator
    {
        public int Id { get; set; }
        public string ResourceUri { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public ICollection<ComicCreator> ComicCreators { get; set; }
        public ICollection<EventCreator> EventCreators { get; set; }
        public ICollection<SerieCreator> SerieCreators { get; set; }
        public ICollection<StoryCreator> StoryCreators { get; set; }
    }
}
