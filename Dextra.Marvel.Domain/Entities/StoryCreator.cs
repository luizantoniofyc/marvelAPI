using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class StoryCreator
    {
        public int StoryId { get; set; }
        public int CreatorId { get; set; }
        public Story Story { get; set; }
        public Creator Creator { get; set; }
    }
}
