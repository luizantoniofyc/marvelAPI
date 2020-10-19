using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class EventSerie
    {
        public int EventId { get; set; }
        public int SerieId { get; set; }
        public Event Event { get; set; }
        public Serie Serie { get; set; }
    }
}
