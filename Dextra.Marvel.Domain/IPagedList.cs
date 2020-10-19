using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Domain
{
    public interface IPagedList<TEntity> where TEntity : class
    {
        int Offset { get; }
        int Limit { get; }
        int Total { get; }
        int Count { get;  }

        IEnumerable<TEntity> Results { get; }
    }
}
