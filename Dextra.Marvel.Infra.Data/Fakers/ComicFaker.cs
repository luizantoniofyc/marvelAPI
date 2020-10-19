using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class ComicFaker
    {
        public static Faker<Comic> Create()
        {
            return new Faker<Comic>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.DiamondCode, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.DigitalId, (f, r) => f.IndexFaker)
                .RuleFor(r => r.Ean, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.Format, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.Isbn, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.Issn, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.IssueNumber, (f, r) => f.Random.Double())
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.PageCount, (f, r) => f.Random.Int())
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Upc, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.VariantDescription, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Dates, (f, r) => ComicDateFaker.Create(r.Id).Generate(3))
                .RuleFor(r => r.Prices, (f, r) => ComicPriceFaker.Create(r.Id).Generate(3))
                .RuleFor(r => r.Images, (f, r) => ImageFaker.Create(r.Id).Generate(3))
                .RuleFor(r => r.Urls, (f, r) => UrlFaker.CreateForComic(r.Id).Generate(5))
                .RuleFor(r => r.Thumbnail, (f, r) => ThumbnailFaker.CreateForComic(r.Id).Generate())
                .RuleFor(r => r.TextObjects, (f, r) => TextObjectFaker.Create(r.Id).Generate(3));
        }
    }
}
