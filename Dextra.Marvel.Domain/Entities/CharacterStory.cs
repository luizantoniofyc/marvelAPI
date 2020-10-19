using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class CharacterStory
    {
        public int CharacterId { get; set; }
        public int StoryId { get; set; }
        public Character Character { get; set; }
        public Story Story { get; set; }
    }
}
