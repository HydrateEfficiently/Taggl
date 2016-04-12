using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Identity.Models;
using Taggl.Services.Identity.Queries;

namespace Taggl.Services.Identity
{
    public interface IUserSearchService
    {
        Task<IEnumerable<UserResult>> Search(string pattern);
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

        public async Task<IEnumerable<UserResult>> Search(string pattern)
        {
            return (await _dbContext.UserRelationships
                .WherePatternMatched(pattern)
                .Where(r => IsStatusSearchable(r))
                .IncludeForUserResult()
                .ToListAsync()).Select(r => new UserResult(r.User));
        }

        #region Helpers

        private bool IsStatusSearchable(ApplicationUserRelationships userRelationships)
        {
            var resolvedStatus = _userStatusResolver.Resolve(userRelationships);
            return resolvedStatus == ResolvedUserStatus.Active ||
                resolvedStatus == ResolvedUserStatus.Deactived ||
                resolvedStatus == ResolvedUserStatus.Pending;
        }

        #endregion
    }
}
