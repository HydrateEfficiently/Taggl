using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Professionalities;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity;
using Taggl.Services.Jobs.Models;
using Taggl.Services.Jobs.Queries;

namespace Taggl.Services.Professionalities.Queries
{
    public static class ExpertiseQueries
    {
        public static async Task<Expertise> CreateExpertiseAsync(
            this ApplicationDbContext dbContext,
            IRoleResolver roleResolver,
            Audit audit,
            Guid professionalityId,
            string jobTagName)
        {
            var jobTag = await dbContext.CreateOrGetJobTagAsync(
                roleResolver, audit, new JobTagCreate() { Name = jobTagName });
            var expertise = new Expertise() { JobTag = jobTag, ProfessionalityId = professionalityId };
            expertise.Create(audit);
            dbContext.Expertise.Add(expertise);
            return expertise;
        }

        public static IQueryable<Expertise> QueryByProfessionality(
            this IQueryable<Expertise> queryable,
            Guid professionalityId)
        {
            return queryable
                .Where(e => e.ProfessionalityId == professionalityId)
                .Where(e => !e.Deleted.HasValue);
        }
    }
}
