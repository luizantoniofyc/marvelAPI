using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class SerieStory
    {
        public int SerieId { get; set; }
        public int StoryId { get; set; }
        public Serie Serie { get; set; }
        public Story Story { get; set; }
    }
}
