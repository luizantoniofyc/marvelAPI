using Bogus;
using Dextra.Marvel.Application.Models.Serie;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class SerieModelFaker
    {
        public static Faker<SerieModel> Create()
        {
            return new Faker<SerieModel>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.EndYear, (f, r) => f.Date.Past().Year)
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.Rating, (f, r) => f.Lorem.Sentence())
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.StartYear, (f, r) => f.Date.Past().Year)
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences());
        }
    }
}
