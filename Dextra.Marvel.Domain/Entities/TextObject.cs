using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class TextObject
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }
}
