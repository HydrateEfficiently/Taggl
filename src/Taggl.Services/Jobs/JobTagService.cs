using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;
using Taggl.Services.Jobs.Models;
using Taggl.Services.Jobs.Queries;

namespace Taggl.Services.Jobs
{
    public interface IJobTagService
    {
        Task<JobTag> CreateAsync(JobTag jobTag);
    }

    public class JobTagService : IJobTagService
    {
        private readonly ApplicationDbContext _dbContext;

        public JobTagService(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JobTag> CreateAsync(JobTag jobTag)
        {
            var normalizedName = GetNormalizedName(jobTag.Name);
            var createdJobTag = await _dbContext.JobTags.GetByNormalizedNameAsync(normalizedName);
            if (createdJobTag == null)
            {
                _dbContext.JobTags.Add(jobTag);
                await _dbContext.SaveChangesAsync();
                createdJobTag = jobTag;
            }
            return createdJobTag;
        }

        public async Task<IEnumerable<JobTagResult>> SearchAsync(string pattern)
        {
            var normalizedPattern = GetNormalizedName(pattern);

        }

        private string GetNormalizedName(string name)
        {
            return string.Join("_", name.Split(' ').Select(s => s.Trim())).ToLowerInvariant();
        }
    }
}
