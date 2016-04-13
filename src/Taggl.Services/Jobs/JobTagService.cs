using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Jobs;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Jobs.Models;
using Taggl.Services.Jobs.Queries;

namespace Taggl.Services.Jobs
{
    public interface IJobTagService
    {
        Task<JobTag> CreateAsync(JobTagCreate create);
    }

    public class JobTagService : IJobTagService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityResolver _identityResolver;
        private readonly UserManager<ApplicationUser> _userManager;

        public JobTagService(
            ApplicationDbContext dbContext,
            IIdentityResolver identityResolver,
            UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _identityResolver = identityResolver;
            _userManager = userManager;
        }

        public async Task<JobTag> CreateAsync(JobTagCreate create)
        {
            var jobTag = await _dbContext.CreateOrGetJobTagAsync(_identityResolver, _userManager, create);
            await _dbContext.SaveChangesAsync();
            return jobTag;
        }
    }
}
