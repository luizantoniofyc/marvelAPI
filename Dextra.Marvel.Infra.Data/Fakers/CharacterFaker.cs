using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class CharacterFaker
    {
        public static Faker<Character> Create()
        {
            return new Faker<Character>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.Name, (f, r) => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Urls, (f, r) => UrlFaker.CreateForCharacter(r.Id).Generate(5))
                .RuleFor(r => r.Thumbnail, (f, r) => ThumbnailFaker.CreateForCharacter(r.Id).Generate());
        }
    }
}
