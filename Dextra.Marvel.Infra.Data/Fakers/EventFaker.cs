using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class EventFaker
    {
        public static Faker<Event> Create()
        {
            return new Faker<Event>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.End, (f, r) => f.Date.Past())
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Start, (f, r) => f.Date.Past())
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Urls, (f, r) => UrlFaker.CreateForEvent(r.Id).Generate(5))
                .RuleFor(r => r.Thumbnail, (f, r) => ThumbnailFaker.CreateForEvent(r.Id).Generate());
        }
    }
}
