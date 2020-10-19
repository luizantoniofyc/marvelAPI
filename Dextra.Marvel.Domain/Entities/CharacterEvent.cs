using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class CharacterEvent
    {
        public int CharacterId { get; set; }
        public int EventId { get; set; }
        public Character Character { get; set; }
        public Event Event { get; set; }
    }
}
