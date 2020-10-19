using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Comic
{
    public class ComicList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<ComicSummary> Items { get; set; }
    }
}
