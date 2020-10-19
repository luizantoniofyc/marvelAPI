using Bogus;
using Dextra.Marvel.Application.Models.Story;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public class StoryDataWrapperFaker
    {
        public static Faker<StoryDataWrapper> Create()
        {
            return new Faker<StoryDataWrapper>("pt_BR")
                .RuleFor(r => r.AttributionHTML, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.AttributionText, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Code, (f, r) => 200)
                .RuleFor(r => r.Copyright, (f, r) => f.Commerce.ProductName())
                .RuleFor(r => r.Etag, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Status, (f, r) => "Success");
        }
    }
}
