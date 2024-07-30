using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Datapoint.Compass.Middleware
{
    internal static class QueryableExtensions
    {
        internal static Task<TSource> FirstAsync<TSource>(this IQueryable<TSource> queryable, CancellationToken ct)
        {
            try
            {
                return EntityFrameworkQueryableExtensions.FirstAsync(queryable, ct);
            }
            catch (Exception e)
            {
                throw new BusinessException("Entity was not found.", e);
            }
        }
    }
}
