using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class Thumbnail
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int ComicId { get; set; }
        public Comic Comic { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int SerieId { get; set; }
        public Serie Serie { get; set; }
        public int StoryId { get; set; }
        public Story Story { get; set; }
    }
}
