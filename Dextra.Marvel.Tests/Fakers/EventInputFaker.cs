using Bogus;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class EventInputFaker
    {
        public static Faker<EventInput> Create()
        {
            return new Faker<EventInput>("pt_BR")
                .RuleFor(r => r.Limit, (f, r) => 10);
        }
    }
}
