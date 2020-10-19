using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class ComicCreator
    {
        public int ComicId { get; set; }
        public int CreatorId { get; set; }
        public Comic Comic { get; set; }
        public Creator Creator { get; set; }
    }
}
