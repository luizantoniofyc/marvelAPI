using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class Comic
    {
        public int Id { get; set; }
        public int DigitalId { get; set; }
        public string Title { get; set; }
        public double IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string Isbn { get; set; }
        public string Upc { get; set; }
        public string DiamondCode { get; set; }
        public string Ean { get; set; }
        public string Issn { get; set; }
        public string Format { get; set; }
        public int PageCount { get; set; }
        public string ResourceUri { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public ICollection<TextObject> TextObjects { get; set; }
        public ICollection<Url> Urls { get; set; }
        public ICollection<CharacterComic> CharacterComics { get; set; }
        public ICollection<ComicSerie> ComicSeries { get; set; }
        public ICollection<ComicDate> Dates { get; set; }
        public ICollection<ComicPrice> Prices { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<ComicCreator> ComicCreators { get; set; }
        public ICollection<ComicStory> ComicStories { get; set; }
        public ICollection<ComicEvent> ComicEvents { get; set; }
    }
}
