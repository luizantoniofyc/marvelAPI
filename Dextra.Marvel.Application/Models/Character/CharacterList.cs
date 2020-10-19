using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Character
{
    public class CharacterList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<CharacterSummary> Items { get; set; }
    }
}
