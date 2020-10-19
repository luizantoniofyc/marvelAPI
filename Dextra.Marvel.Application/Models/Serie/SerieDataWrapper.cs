using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Serie
{
    public class SerieDataWrapper
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public SerieDataContainer Data { get; set; }
        public string Etag { get; set; }
    }
}
