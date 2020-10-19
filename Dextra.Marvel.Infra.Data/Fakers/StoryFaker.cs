using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class StoryFaker
    {
        public static Faker<Story> Create()
        {
            return new Faker<Story>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.Thumbnail, (f, r) => ThumbnailFaker.CreateForStory(r.Id).Generate());
        }
    }
}
