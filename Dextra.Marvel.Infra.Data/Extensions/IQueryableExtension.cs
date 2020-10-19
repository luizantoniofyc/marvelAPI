using Dextra.Marvel.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Infra.Data.Extensions
{
    public static class IQueryableExtension
    {
        public static async Task<IPagedList<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> query, int offset, int limit) where TEntity : class
        {
            var count = query.Count();
            var items = await query.Skip(offset).Take(limit).ToArrayAsync();
            return new PagedList<TEntity>(offset, limit, count, count, items);
        }
    }
}
