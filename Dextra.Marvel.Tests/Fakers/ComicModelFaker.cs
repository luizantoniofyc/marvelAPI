using Bogus;
using Dextra.Marvel.Application.Models.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class ComicModelFaker
    {
        public static Faker<ComicModel> Create()
        {
            return new Faker<ComicModel>("pt_BR")
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
                .RuleFor(r => r.VariantDescription, (f, r) => f.Lorem.Sentences());
        }
    }
}
