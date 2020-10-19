using Dextra.Marvel.Application.Models.Character;
using Dextra.Marvel.Application.Models.Creator;
using Dextra.Marvel.Application.Models.Event;
using Dextra.Marvel.Application.Models.Serie;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Comic
{
    public class ComicModel
    {
        public int Id { get; set; }
        public int DigitalId { get; set; }
        public string Title { get; set; }
        public double IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public DateTime? Modified { get; set; }
        public string Isbn { get; set; }
        public string Upc { get; set; }
        public string DiamondCode { get; set; }
        public string Ean { get; set; }
        public string Issn { get; set; }
        public string Format { get; set; }
        public int PageCount { get; set; }
        public List<TextObjectModel> TextObjects { get; set; }
        public string ResourceUri { get; set; }
        public List<UrlModel> Urls { get; set; }
        public SerieList Series { get; set; }
        public ComicList Variants { get; set; }
        public ComicList Collections { get; set; }
        public ComicList CollectedIssues { get; set; }
        public List<ComicDateModel> Dates { get; set; }
        public List<ComicPriceModel> Prices { get; set; }
        public ThumbnailModel Thumbnail { get; set; }
        public List<ImageModel> Images { get; set; }
        public CreatorList Creators { get; set; }
        public CharacterList Characters { get; set; }
        public StoryList Stories { get; set; }
        public EventList Events { get; set; }
    }
}
