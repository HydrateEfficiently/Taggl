using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;

namespace Taggl.Services.Jobs.Queries
{
    public static class JobTagQueries
    {
        public static Task<JobTag> GetByNormalizedNameAsync(
            this IQueryable<JobTag> queryable,
            string normalizedName)
        {
            return queryable.FirstOrDefaultAsync(j => j.NormalizedName == normalizedName);
        }
    }
}
