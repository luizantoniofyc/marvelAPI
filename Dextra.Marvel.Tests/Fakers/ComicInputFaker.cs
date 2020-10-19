using Bogus;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class ComicInputFaker
    {
        public static Faker<ComicInput> Create()
        {
            return new Faker<ComicInput>("pt_BR")
                .RuleFor(r => r.Limit, (f, r) => 10);
        }
    }
}
