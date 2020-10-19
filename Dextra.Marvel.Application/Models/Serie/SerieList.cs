using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Serie
{
    public class SerieList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<SerieSummary> Items { get; set; }
    }
}
