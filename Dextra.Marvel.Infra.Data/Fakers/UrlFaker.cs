using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class UrlFaker
    {
        public static Faker<Url> CreateForCharacter(int characterId)
        {
            return new Faker<Url>("pt_BR")
                .RuleFor(r => r.CharacterId, (f, r) => characterId)
                .RuleFor(r => r.FullUrl, (f, r) => f.Internet.Url())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }

        public static Faker<Url> CreateForComic(int comicId)
        {
            return new Faker<Url>("pt_BR")
                .RuleFor(r => r.ComicId, (f, r) => comicId)
                .RuleFor(r => r.FullUrl, (f, r) => f.Internet.Url())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }

        public static Faker<Url> CreateForEvent(int eventId)
        {
            return new Faker<Url>("pt_BR")
                .RuleFor(r => r.EventId, (f, r) => eventId)
                .RuleFor(r => r.FullUrl, (f, r) => f.Internet.Url())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }

        public static Faker<Url> CreateForSerie(int serieId)
        {
            return new Faker<Url>("pt_BR")
                .RuleFor(r => r.SerieId, (f, r) => serieId)
                .RuleFor(r => r.FullUrl, (f, r) => f.Internet.Url())
                .RuleFor(r => r.Type, (f, r) => f.Lorem.Word());
        }
    }
}
