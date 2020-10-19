using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Creator;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Serie;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Story
{
    public class StoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; set; }
        public string Type { get; set; }
        public DateTime Modified { get; set; }
        public ThumbnailModel Thumbnail { get; set; }
        public ComicList Comics { get; set; }
        public SerieList Series { get; set; }
        public EventList Events { get; set; }
        public CharacterList Characters { get; set; }
        public CreatorList Creators { get; set; }
        public ComicSummary OriginalIssue { get; set; }
        public EventSummary Previous { get; set; }
    }
}
