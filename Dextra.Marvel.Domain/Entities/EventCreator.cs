using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class EventCreator
    {
        public int EventId { get; set; }
        public int CreatorId { get; set; }
        public Event Event { get; set; }
        public Creator Creator { get; set; }
    }
}
