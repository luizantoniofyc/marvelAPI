using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class CreatorFaker
    {
        public static Faker<Creator> Create()
        {
            return new Faker<Creator>("pt_BR")
                .RuleFor(r => r.Name, (f, r) => f.Name.FullName(Bogus.DataSets.Name.Gender.Female))
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Role, (f, r) => f.Lorem.Word());
        }
    }
}
