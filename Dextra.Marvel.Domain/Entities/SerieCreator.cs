using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class SerieCreator
    {
        public int SerieId { get; set; }
        public int CreatorId { get; set; }
        public Serie Serie { get; set; }
        public Creator Creator { get; set; }
    }
}
