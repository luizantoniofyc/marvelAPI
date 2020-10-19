using Bogus;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class SerieInputFaker
    {
        public static Faker<SerieInput> Create()
        {
            return new Faker<SerieInput>("pt_BR")
                .RuleFor(r => r.Limit, (f, r) => 10);
        }
    }
}
