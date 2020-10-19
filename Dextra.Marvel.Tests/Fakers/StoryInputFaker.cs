using Bogus;
using Dextra.Marvel.Application.Models.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class StoryInputFaker
    {
        public static Faker<StoryInput> Create()
        {
            return new Faker<StoryInput>("pt_BR")
                .RuleFor(r => r.Limit, (f, r) => 10);
        }
    }
}
