using Bogus;
using Dextra.Marvel.Application.Models.Serie;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class SerieDataContainerFaker
    {
        public static Faker<SerieDataContainer> Create()
        {
            return new Faker<SerieDataContainer>("pt_BR")
                .RuleFor(r => r.Count, 3)
                .RuleFor(r => r.Limit, (f, r) => 10)
                .RuleFor(r => r.Offset, (f, r) => 0)
                .RuleFor(r => r.Results, (f, r) => SerieModelFaker.Create().Generate(10))
                .RuleFor(r => r.Total, (f, r) => 3);
        }
    }
}
