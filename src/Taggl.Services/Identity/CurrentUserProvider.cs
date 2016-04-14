using Microsoft.AspNet.Identity;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Identity.Queries;

namespace Taggl.Services.Identity
{
    public interface ICurrentUserProvider
    {
        Task<ApplicationUser> GetApplicationUserAsync();

        Task<UserResult> GetUserResultAsync();
    }

    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IIdentityResolver _identityResolver;
        private readonly ApplicationDbContext _dbContext;

        public CurrentUserProvider(
            IIdentityResolver identityResolver,
            ApplicationDbContext dbContext)
        {
            _identityResolver = identityResolver;
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetApplicationUserAsync()
        {
            var identity = _identityResolver.Resolve();
            return await _dbContext.ApplicationUserRelationships.GetUserAsync(identity.GetId());
        }

        public async Task<UserResult> GetUserResultAsync()
        {
            return new UserResult(await GetApplicationUserAsync());
        }
    }
}
