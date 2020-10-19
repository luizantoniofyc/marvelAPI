using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Application.Exceptions
{
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }

        public BusinessException(string message)
            : base(message)
        {

        }

        public BusinessException(string message, string code)
            : base(message)
        {
            this.Source = code;
        }
    }
}
