using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Utility;

namespace Taggl.Services.Identity.Queries
{
    public static class ApplicationUserRelationshipsQueries
    {
        public static IQueryable<ApplicationUserRelationships> IncludeAll(
            this IQueryable<ApplicationUserRelationships> queryable)
        {
            return queryable
                .Include(r => r.User)
                .Include(r => r.Professional)
                .Include(r => r.Status);
        }

        public static IQueryable<ApplicationUserRelationships> IncludeForUserResult(
            this IQueryable<ApplicationUserRelationships> queryable)
        {
            return queryable
                .Include(r => r.User)
                .Include(r => r.Status);
        }

        public static IQueryable<ApplicationUserRelationships> WherePatternMatched(
            this IQueryable<ApplicationUserRelationships> queryable,
            string pattern)
        {
            var lookupNormalizer = ServiceLocator.Current.GetRequiredService<ILookupNormalizer>();
            string patternNormalized = lookupNormalizer.Normalize(pattern);
            return queryable.Where(r =>
                r.User.NormalizedEmail == patternNormalized ||
                lookupNormalizer.Normalize(r.User.GetDisplayName()) == patternNormalized);
        }

        public static async Task<ApplicationUserStatus> GetStatusAsync(
            this IQueryable<ApplicationUserRelationships> queryable,
            string userId)
        {
            return await queryable
                .Where(r => r.UserId == userId)
                .Select(r => r.Status)
                .FirstAsync();
        }
    }
}
