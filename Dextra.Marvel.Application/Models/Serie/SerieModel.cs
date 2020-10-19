using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Creator;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Serie
{
    public class SerieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceUri { get; set; }
        public List<UrlModel> Urls { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Rating { get; set; }
        public DateTime Modified { get; set; }
        public ThumbnailModel Thumbnail { get; set; }
        public ComicList Comics { get; set; }
        public StoryList Stories { get; set; }
        public SerieList Series { get; set; }
        public EventList Events { get; set; }
        public CharacterList Characters { get; set; }
        public CreatorList Creators { get; set; }
        public SerieSummary Next { get; set; }
        public SerieSummary Previous { get; set; }
    }
}
