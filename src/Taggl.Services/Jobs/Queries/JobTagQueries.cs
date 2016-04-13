using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;
using Taggl.Services.Jobs.Models;

namespace Taggl.Services.Jobs.Queries
{
    public static class JobTagQueries
    {
        public static async Task<JobTag> CreateOrGetJobTagAsync(
            this ApplicationDbContext dbContext,
            JobTagCreate create)
        {
            var jobTag = create.Map();
            var existingJobTag = await dbContext.JobTags.GetMatchAsync(jobTag);
            if (existingJobTag == null)
            {
                dbContext.JobTags.Add(jobTag);
                return jobTag;
            }
            else
            {
                return existingJobTag;
            }
        }

        public static async Task<JobTag> GetMatchAsync(
            this IQueryable<JobTag> queryable,
            JobTag jobTag)
        {
            return await queryable.FirstOrDefaultAsync(j => j.NameNormalized == jobTag.NameNormalized);
        }
    }
}
