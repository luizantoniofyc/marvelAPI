﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain.Entities
{
    public class ComicStory
    {
        public int ComicId { get; set; }
        public int StoryId { get; set; }
        public Comic Comic { get; set; }
        public Story Story { get; set; }
    }
}
