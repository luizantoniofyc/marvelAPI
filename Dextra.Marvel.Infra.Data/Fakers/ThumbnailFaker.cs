using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class ThumbnailFaker
    {
        public static Faker<Thumbnail> CreateForCharacter(int characterId)
        {
            return new Faker<Thumbnail>("pt_BR")
                .RuleFor(r => r.CharacterId, (f, r) => characterId)
                .RuleFor(r => r.Extension, (f, r) => f.System.FileExt())
                .RuleFor(r => r.Path, (f, r) => f.Image.PicsumUrl());
        }

        public static Faker<Thumbnail> CreateForComic(int comicId)
        {
            return new Faker<Thumbnail>("pt_BR")
                .RuleFor(r => r.ComicId, (f, r) => comicId)
                .RuleFor(r => r.Extension, (f, r) => f.System.FileExt())
                .RuleFor(r => r.Path, (f, r) => f.Image.PicsumUrl());
        }

        public static Faker<Thumbnail> CreateForEvent(int eventId)
        {
            return new Faker<Thumbnail>("pt_BR")
                .RuleFor(r => r.EventId, (f, r) => eventId)
                .RuleFor(r => r.Extension, (f, r) => f.System.FileExt())
                .RuleFor(r => r.Path, (f, r) => f.Image.PicsumUrl());
        }

        public static Faker<Thumbnail> CreateForSerie(int serieId)
        {
            return new Faker<Thumbnail>("pt_BR")
                .RuleFor(r => r.SerieId, (f, r) => serieId)
                .RuleFor(r => r.Extension, (f, r) => f.System.FileExt())
                .RuleFor(r => r.Path, (f, r) => f.Image.PicsumUrl());
        }

        public static Faker<Thumbnail> CreateForStory(int storyId)
        {
            return new Faker<Thumbnail>("pt_BR")
                .RuleFor(r => r.StoryId, (f, r) => storyId)
                .RuleFor(r => r.Extension, (f, r) => f.System.FileExt())
                .RuleFor(r => r.Path, (f, r) => f.Image.PicsumUrl());
        }
    }
}
