using Bogus;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class CharacterInputFaker
    {
        public static Faker<CharacterInput> Create()
        {
            return new Faker<CharacterInput>("pt_BR")
                .RuleFor(r => r.Limit, (f, r) => 10);
        }
    }
}
