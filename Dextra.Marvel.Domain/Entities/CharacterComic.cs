using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class CharacterComic
    {
        public int CharacterId { get; set; }
        public int ComicId { get; set; }
        public Character Character { get; set; }
        public Comic Comic { get; set; }
    }
}
