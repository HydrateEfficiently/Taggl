using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Professionalities;
using Taggl.Services.Identity.Queries;

namespace Taggl.Services.Professionalities.Queries
{
    public static class ProfessionalityQueries
    {
        public static async Task<Professionality> GetProfessionalityByUser(
            this IQueryable<ApplicationUserRelationships> queryable,
            string userId)
        {
            return await queryable
                .QueryByUser(userId)
                .Select(r => r.Professional)
                .FirstOrDefaultAsync();
        }
    }
}
