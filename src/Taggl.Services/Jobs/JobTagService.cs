using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;
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
        private readonly ILookupNormalizer _lookupNormalizer;

        public JobTagService(
            ApplicationDbContext dbContext,
            ILookupNormalizer lookupNormalizer)
        {
            _dbContext = dbContext;
            _lookupNormalizer = lookupNormalizer;
        }

        public async Task<JobTag> CreateAsync(JobTagCreate create)
        {
            var jobTag = await _dbContext.CreateOrGetJobTagAsync(create);
            await _dbContext.SaveChangesAsync();
            return jobTag;
        }
    }
}
