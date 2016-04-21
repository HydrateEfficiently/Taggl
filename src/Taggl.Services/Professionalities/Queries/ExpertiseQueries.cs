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
using Taggl.Services.Shifts.Models;
using Taggl.Services.Shifts.Queries;

namespace Taggl.Services.Professionalities.Queries
{
    public static class ExpertiseQueries
    {
        public static async Task<Expertise> CreateExpertiseAsync(
            this ApplicationDbContext dbContext,
            IRoleResolver roleResolver,
            IAuditFactory auditFactory,
            Guid professionalityId,
            string shiftTypeName)
        {
            var shiftType = await dbContext.CreateOrGetShiftTypeAsync(
                roleResolver, auditFactory, new ShiftTypeCreate() { Name = shiftTypeName });
            var expertise = new Expertise() { ShiftType = shiftType, ProfessionalityId = professionalityId }
                .AuditCreated(auditFactory.CreateAudit());
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
