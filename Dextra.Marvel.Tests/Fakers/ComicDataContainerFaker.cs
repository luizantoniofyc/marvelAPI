using Bogus;
using Dextra.Marvel.Application.Models.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class ComicDataContainerFaker
    {
        public static Faker<ComicDataContainer> Create()
        {
            return new Faker<ComicDataContainer>("pt_BR")
                .RuleFor(r => r.Count, 3)
                .RuleFor(r => r.Limit, (f, r) => 10)
                .RuleFor(r => r.Offset, (f, r) => 0)
                .RuleFor(r => r.Results, (f, r) => ComicModelFaker.Create().Generate(10))
                .RuleFor(r => r.Total, (f, r) => 3);
        }
    }
}
