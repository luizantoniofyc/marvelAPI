using Bogus;
using Dextra.Marvel.Application.Models.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class EventDataContainerFaker
    {
        public static Faker<EventDataContainer> Create()
        {
            return new Faker<EventDataContainer>("pt_BR")
                .RuleFor(r => r.Count, 3)
                .RuleFor(r => r.Limit, (f, r) => 10)
                .RuleFor(r => r.Offset, (f, r) => 0)
                .RuleFor(r => r.Results, (f, r) => EventModelFaker.Create().Generate(10))
                .RuleFor(r => r.Total, (f, r) => 3);
        }
    }
}
