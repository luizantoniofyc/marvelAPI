using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class SerieFaker
    {
        public static Faker<Serie> Create()
        {
            return new Faker<Serie>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.EndYear, (f, r) => f.Date.Past().Year)
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.Rating, (f, r) => f.Lorem.Sentence())
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.StartYear, (f, r) => f.Date.Past().Year)
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Urls, (f, r) => UrlFaker.CreateForSerie(r.Id).Generate(5))
                .RuleFor(r => r.Thumbnail, (f, r) => ThumbnailFaker.CreateForSerie(r.Id).Generate());
        }
    }
}
