using Bogus;
using Dextra.Marvel.Application.Models.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Tests.Fakers
{
    public static class EventModelFaker
    {
        public static Faker<EventModel> Create()
        {
            return new Faker<EventModel>("pt_BR")
                .RuleFor(r => r.Description, (f, r) => f.Lorem.Sentences(10))
                .RuleFor(r => r.End, (f, r) => f.Date.Past())
                .RuleFor(r => r.Modified, (f, r) => f.Date.Past())
                .RuleFor(r => r.ResourceUri, (f, r) => f.Random.Guid().ToString())
                .RuleFor(r => r.Start, (f, r) => f.Date.Past())
                .RuleFor(r => r.Title, (f, r) => f.Lorem.Sentences());
        }
    }
}
