using Bogus;
using Dextra.Marvel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Fakers
{
    public static class ImageFaker
    {
        public static Faker<Image> Create(int comicId)
        {
            return new Faker<Image>("pt_BR")
                .RuleFor(r => r.ComicId, (f, r) => comicId)
                .RuleFor(r => r.Extension, (f, r) => f.System.FileExt())
                .RuleFor(r => r.Path, (f, r) => f.Image.PicsumUrl());
        }
    }
}
