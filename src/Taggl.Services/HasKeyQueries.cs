using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models;

namespace Taggl.Services
{
    public static class HasKeyQueries
    {
        public static IQueryable<TResult> Find<TResult, TKey>(
            this IQueryable<TResult> queryable,
            TKey id) where TResult : HasKey<TKey>
        {
            return queryable
                .Where(i => i.Id.Equals(id))
                .Cast<TResult>();
        }

    }
}
