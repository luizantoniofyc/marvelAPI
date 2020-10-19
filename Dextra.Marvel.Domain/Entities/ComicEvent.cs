using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class ComicEvent
    {
        public int ComicId { get; set; }
        public int EventId { get; set; }
        public Comic Comic { get; set; }
        public Event Event { get; set; }
    }
}
