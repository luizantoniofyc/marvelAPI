using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Comic
{
    public class ComicDataWrapper
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public ComicDataContainer Data { get; set; }
        public string Etag { get; set; }
    }
}
