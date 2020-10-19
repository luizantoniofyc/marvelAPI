using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Creator
{
    public class CreatorList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<CreatorSummary> Items { get; set; }
    }
}
