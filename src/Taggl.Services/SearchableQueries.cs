using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework;
using Taggl.Framework.Models;

namespace Taggl.Services
{
    public static class SearchableQueries
    {
        public static IQueryable<TResult> WherePatternMatched<TResult>(
            this IQueryable<ISearchableName> queryable,
            ISearchableNameFormatter shiftTypeFormatter,
            string pattern) where TResult : ISearchable
        {
            string patternNormalized = shiftTypeFormatter.NormalizeName(pattern);
            return queryable
                .Where(s => s.NameNormalized.Contains(patternNormalized))
                .Cast<TResult>();
        }

        public static IQueryable<TResult> WhereSearchable<TResult>(
            this IQueryable<ISearchable> queryable) where TResult : ISearchable
        {
            return queryable
                .Where(s => s.IsSearchable)
                .Cast<TResult>();
        }

        public static async Task<TResult> GetMatchAsync<TResult>(
            this IQueryable<TResult> queryable,
            ISearchableName searchableName) where TResult : ISearchableName 
        {
            return await queryable
                .Where(s => s.NameNormalized == searchableName.NameNormalized)
                .FirstOrDefaultAsync();
        }
    }
}
