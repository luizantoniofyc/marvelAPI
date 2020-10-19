using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class ComicPriceFaker
    {
        public static Faker<ComicPrice> Create(int comicId)
        {
            return new Faker<ComicPrice>("pt_BR")
                .RuleFor(r => r.ComicId, (f, r) => comicId)
                .RuleFor(r => r.Price, (f, r) => f.Random.Float())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }
    }
}
