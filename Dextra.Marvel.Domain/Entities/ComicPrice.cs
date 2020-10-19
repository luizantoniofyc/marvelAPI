using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class ComicPrice
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
        public int ComicId { get; set; }
        public Comic Comic { get; set; }
    }
}
