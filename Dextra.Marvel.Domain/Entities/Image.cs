using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public int ComicId { get; set; }
        public Comic Comic { get; set; }
    }
}
