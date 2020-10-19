using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class EventStory
    {
        public int EventId { get; set; }
        public int StoryId { get; set; }
        public Event Event { get; set; }
        public Story Story { get; set; }
    }
}
