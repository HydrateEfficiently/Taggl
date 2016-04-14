using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Constants;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Jobs;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity;
using Taggl.Services.Jobs.Models;

namespace Taggl.Services.Jobs.Queries
{
    public static class JobTagQueries
    {
        public static async Task<JobTag> CreateOrGetJobTagAsync(
            this ApplicationDbContext dbContext,
            IRoleResolver roleResolver,
            Audit audit,
            JobTagCreate create)
        {
            var jobTag = create.Map();
            var existingJobTag = await dbContext.JobTags.GetMatchAsync(jobTag);

            if (existingJobTag == null)
            {
                jobTag.Create(audit);
                dbContext.JobTags.Add(jobTag);
                existingJobTag = jobTag;
            }

            if (await roleResolver.IsInRoleAsync(ApplicationRoles.Administrator))
            {
                existingJobTag.IsSearchable = true;
            }

            return existingJobTag;
        }

        public static async Task<JobTag> GetMatchAsync(
            this IQueryable<JobTag> queryable,
            JobTag jobTag)
        {
            return await queryable.FirstOrDefaultAsync(j => j.NameNormalized == jobTag.NameNormalized);
        }

        public static IQueryable<JobTag> WherePatternMatched(
            this IQueryable<JobTag> queryable,
            IJobTagFormatter jobTagFormatter,
            string pattern)
        {
            string patternNormalized = jobTagFormatter.NormalizeName(pattern);
            return queryable.Where(j => j.NameNormalized.Contains(patternNormalized));
        }

        public static IQueryable<JobTag> WhereSearchable(
            this IQueryable<JobTag> queryable)
        {
            return queryable.Where(j => j.IsSearchable);
        }
    }
}
