using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{

    public static class TextObjectFaker
    {
        public static Faker<TextObject> Create(int comicId)
        {
            return new Faker<TextObject>("pt_BR")
                .RuleFor(r => r.Language, (f, r) => f.Lorem.Word())
                .RuleFor(r => r.Text, (f, r) => f.Lorem.Sentence())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }
    }
}
