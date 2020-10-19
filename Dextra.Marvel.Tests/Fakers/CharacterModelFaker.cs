using Bogus;
using Dextra.Marvel.Application.Models.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class CharacterModelFaker
    {
        public static Faker<CharacterModel> Create()
        {
            return new Faker<CharacterModel>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.Name, (f, r) => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(r => r.ResourceURI, (f, r) => f.Random.Guid().ToString());
        }
    }
}
