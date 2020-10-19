using Bogus;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class StoryModelFaker
    {
        public static Faker<StoryModel> Create()
        {
            return new Faker<StoryModel>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }
    }
}
