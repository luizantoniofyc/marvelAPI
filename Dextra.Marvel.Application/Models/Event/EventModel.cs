using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Creator;
using Dextra.Marvel.Application.Models.Serie;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Event
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; set; }
        public List<UrlModel> Urls { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ThumbnailModel Thumbnail { get; set; }
        public ComicList Comics { get; set; }
        public StoryList Stories { get; set; }
        public SerieList Series { get; set; }
        public CharacterList Characters { get; set; }
        public CreatorList Creators { get; set; }
        public EventSummary Next { get; set; }
        public EventSummary Previous { get; set; }
    }
}
