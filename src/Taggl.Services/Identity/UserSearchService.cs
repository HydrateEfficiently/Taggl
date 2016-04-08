using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Identity.Models;

namespace Taggl.Services.Identity
{
    public interface IUserSearchService
    {
        Task<IEnumerable<UserSummary>> Search(string pattern);
    }

    public class UserSearchService : IUserSearchService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserStatusResolver _userStatusResolver;

        public UserSearchService(
            ApplicationDbContext dbContext,
            IUserStatusResolver userStatusResolver)
        {
            _dbContext = dbContext;
            _userStatusResolver = userStatusResolver;
        }

        public async Task<IEnumerable<UserSummary>> Search(string pattern)
        {
            var patternLower = pattern.ToLowerInvariant();
            var matchingStatuses = await _dbContext.ApplicationUserStatuses
                .Include(s => s.ApplicationUser)
                .Where(s =>
                    s.ApplicationUser.Email.ToLowerInvariant().Contains(patternLower) ||
                    s.ApplicationUser.GetDisplayName().ToLowerInvariant().Contains(patternLower))
                .ToListAsync();

            return matchingStatuses
                .Where(s => IsStatusSearchable(s))
                .Select(s => new UserSummary(s.ApplicationUser));
        }

        #region Helpers

        private bool IsStatusSearchable(ApplicationUserStatus status)
        {
            var resolvedStatus = _userStatusResolver.Resolve(status);
            return resolvedStatus == ResolvedUserStatus.Active ||
                resolvedStatus == ResolvedUserStatus.Deactived ||
                resolvedStatus == ResolvedUserStatus.Pending;
        }

        #endregion
    }
}
