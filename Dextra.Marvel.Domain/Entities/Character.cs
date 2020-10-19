using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string ResourceUri { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public ICollection<Url> Urls { get; set; }
        public ICollection<CharacterComic> CharacterComics { get; set; }
        public ICollection<CharacterEvent> CharacterEvents { get; set; }
        public ICollection<CharacterSerie> CharacterSeries { get; set; }
        public ICollection<CharacterStory> CharacterStories { get; set; }
    }
}
