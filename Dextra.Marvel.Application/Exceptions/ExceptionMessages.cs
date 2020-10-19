using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Exceptions
{
    public static class ExceptionMessages
    {
        public const string BN001 = "Limit greater than 100.";
        public const string BN002 = "Limit invalid or below 1.";
        public const string BN003 = "Invalid or unrecognized parameter.";
        public const string BN004 = "Empty parameter.";
        public const string BN005 = "Invalid or unrecognized ordering parameter.";
        public const string BN006 = "Too many values sent to a multi-value list filter.";
        public const string BN007 = "Invalid value passed to filter.";
        public const string BN008 = "NotFound.";
    }
}
