using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity;
using Taggl.Services.Identity.Models;
using Taggl.Services.Identity.Queries;

namespace Taggl.Services.Administrator
{
    public interface IAdministrationService
    {
        Task<IEnumerable<UserResult>> ListPendingUsersAsync();

        Task ApproveUserAsync(string userId);
    }

    public class AdministrationService : IAdministrationService
    {
        private readonly IIdentityResolver _identityResolver;
        private readonly ApplicationDbContext _dbContext;

        public AdministrationService(
            ApplicationDbContext dbContext,
            IIdentityResolver identityResolver)
        {
            _dbContext = dbContext;
            _identityResolver = identityResolver;
        }

        public async Task<IEnumerable<UserResult>> ListPendingUsersAsync()
        {
            return (await _dbContext.UserRelationships.IncludeAll()
                .Where(r => !r.Status.Approved.HasValue)
                .Select(r => r.User)
                .ToListAsync()).Select(u => new UserResult(u));
        }

        public async Task ApproveUserAsync(string userId)
        {
            var status = await _dbContext.UserRelationships.GetStatusAsync(userId);
            status.Approved = DateTime.UtcNow;
            status.ApprovedById = _identityResolver.Resolve().GetId();
            await _dbContext.SaveChangesAsync();
        }
    }
}
