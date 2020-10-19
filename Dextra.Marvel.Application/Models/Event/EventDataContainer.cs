using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Event
{
    public class EventDataContainer
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<EventModel> Results { get; set; }
    }
}
