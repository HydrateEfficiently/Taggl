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
        Task<UserResult> GetAsync();
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

        public async Task<UserResult> GetAsync()
        {
            var identity = _identityResolver.Resolve();
            var user = await _dbContext.Users.GetAsync(identity.GetId());
            return new UserResult(user);
        }
    }
}
