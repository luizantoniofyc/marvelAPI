﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Models.Serie
{
    public class SerieDataContainer
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<SerieModel> Results { get; set; }
    }
}
