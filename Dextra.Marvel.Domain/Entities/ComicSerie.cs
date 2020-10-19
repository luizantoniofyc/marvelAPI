using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class ComicSerie
    {
        public int ComicId { get; set; }
        public int SerieId { get; set; }
        public Comic Comic { get; set; }
        public Serie Serie { get; set; }
    }
}
