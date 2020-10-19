using Bogus;
using Dextra.Marvel.Application.Models.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class CharacterDataWrapperFaker
    {
        public static Faker<CharacterDataWrapper> Create()
        {
            return new Faker<CharacterDataWrapper>("pt_BR")
                .RuleFor(r => r.AttributionHTML, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.AttributionText, (f, r) => f.Lorem.Sentences())
                .RuleFor(r => r.Code, (f, r) => 200)
                .RuleFor(r => r.Copyright, (f, r) => f.Commerce.ProductName())
                .RuleFor(r => r.Etag, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Status, (f, r) => "Success");
        }
    }
}
