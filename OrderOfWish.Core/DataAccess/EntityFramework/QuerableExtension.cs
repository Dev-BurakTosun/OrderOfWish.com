using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace OrderOfWish.Core.DataAccess.EntityFramework
{
    public static class QuerableExtension
    {
        public static IQueryable<T> MyInclude<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T: class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (a, b) => a.Include(b));
            }
            return query;
        }
    }
}
