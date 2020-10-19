using Bogus;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class StoryDataContainerFaker
    {
        public static Faker<StoryDataContainer> Create()
        {
            return new Faker<StoryDataContainer>("pt_BR")
                .RuleFor(r => r.Count, 3)
                .RuleFor(r => r.Limit, (f, r) => 10)
                .RuleFor(r => r.Offset, (f, r) => 0)
                .RuleFor(r => r.Results, (f, r) => StoryModelFaker.Create().Generate(10))
                .RuleFor(r => r.Total, (f, r) => 3);
        }
    }
}
