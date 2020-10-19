using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class CharacterSerie
    {
        public int CharacterId { get; set; }
        public int SerieId { get; set; }
        public Character Character { get; set; }
        public Serie Serie { get; set; }
    }
}
