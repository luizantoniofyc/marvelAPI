﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message)
             : base(message)
        {

        }
    }
}
