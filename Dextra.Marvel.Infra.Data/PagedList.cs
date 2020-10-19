using Dextra.Marvel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dextra.Marvel.Infra.Data
{
    public class PagedList<TEntity> : IPagedList<TEntity> where TEntity : class
    {
        public PagedList(int offset, int limit, int total, int count, IEnumerable<TEntity> results)
        {
            Offset = offset;
            Limit = limit;
            Total = total;
            Count = count;
            Results = results;
        }

        public int Offset { get; private set; }
        public int Limit { get; private set; }
        public int Total { get; private set; }
        public int Count { get; private set; }
        public IEnumerable<TEntity> Results { get; private set; }
    }
}
