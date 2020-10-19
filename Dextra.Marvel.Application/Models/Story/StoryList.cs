using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Story
{
    public class StoryList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<StorySummary> Items { get; set; }
    }
}
