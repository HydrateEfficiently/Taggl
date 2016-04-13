using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Identity.Models;
using Taggl.Services.Utility;

namespace Taggl.Services.Identity.Queries
{
    public static class ApplicationUserRelationshipsQueries
    {
        public static IQueryable<ApplicationUserRelationships> QueryByUser(
            this IQueryable<ApplicationUserRelationships> queryable,
            string userId)
        {
            return queryable.Where(r => r.UserId == userId);
        }

        public static IQueryable<ApplicationUserRelationships> IncludeAll(
            this IQueryable<ApplicationUserRelationships> queryable)
        {
            return queryable
                .Include(r => r.User)
                .Include(r => r.Professionality)
                .Include(r => r.Status);
        }

        public static IQueryable<ApplicationUserRelationships> WhereUserPatternMatched(
            this IQueryable<ApplicationUserRelationships> queryable,
            ILookupNormalizer lookupNormalizer,
            string pattern)
        {
            string patternNormalized = lookupNormalizer.Normalize(pattern);
            return queryable.Where(r =>
                r.User.NormalizedEmail == patternNormalized ||
                lookupNormalizer.Normalize(r.User.GetDisplayName()) == patternNormalized);
        }

        public static IQueryable<ApplicationUserRelationships> WhereUserSearchable(
            this IQueryable<ApplicationUserRelationships> queryable,
            IUserStatusResolver userStatusResolver)
        {
            return queryable.Where(r => IsUserSearchable(r, userStatusResolver));
        }

        #region Helpers

        private static bool IsUserSearchable(
            ApplicationUserRelationships userRelationships,
            IUserStatusResolver userStatusResolver)
        {
            var resolvedStatus = userStatusResolver.Resolve(userRelationships);
            return resolvedStatus == ResolvedUserStatus.Active ||
                resolvedStatus == ResolvedUserStatus.Deactived ||
                resolvedStatus == ResolvedUserStatus.Pending;
        }

        #endregion
    }
}
