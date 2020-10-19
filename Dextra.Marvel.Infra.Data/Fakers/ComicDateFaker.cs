using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class ComicDateFaker
    {
        public static Faker<ComicDate> Create(int comicId)
        {
            return new Faker<ComicDate>("pt_BR")
                .RuleFor(r => r.ComicId, (f, r) => comicId)
                .RuleFor(r => r.Date, (f, r) => f.Date.Past())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }
    }
}
