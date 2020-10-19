using Dextra.Marvel.Application.Models.Comic;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Serie;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Character
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string ResourceURI { get; set; }
        public List<UrlModel> Urls { get; set; }
        public ThumbnailModel Thumbnail { get; set; }
        public ComicList Comics { get; set; }
        public StoryList Stories { get; set; }
        public EventList Events { get; set; }
        public SerieList Series { get; set; }
    }
}
