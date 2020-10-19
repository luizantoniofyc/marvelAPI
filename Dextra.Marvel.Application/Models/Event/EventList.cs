using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Event
{
    public class EventList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<EventSummary> Items { get; set; }
    }
}
