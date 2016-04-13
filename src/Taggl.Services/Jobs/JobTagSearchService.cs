using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;
using Taggl.Services.Jobs.Queries;

namespace Taggl.Services.Jobs
{
    public interface IJobTagSearchService
    {
        Task<IEnumerable<JobTag>> Search(string pattern);
    }

    public class JobTagSearchService : IJobTagSearchService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IJobTagFormatter _jobTagFormatter;

        public JobTagSearchService(
            ApplicationDbContext dbContext,
            IJobTagFormatter jobTagFormatter)
        {
            _dbContext = dbContext;
            _jobTagFormatter = jobTagFormatter;
        }

        public async Task<IEnumerable<JobTag>> Search(string pattern)
        {
            return await _dbContext.JobTags
                .WhereSearchable()
                .WherePatternMatched(_jobTagFormatter, pattern)
                .ToListAsync();
        }
    }
}
