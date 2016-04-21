using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Constants;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity;
using Taggl.Services.Shifts.Models;

namespace Taggl.Services.Shifts.Queries
{
    public static class ShiftTypeQueries
    {
        public static async Task<ShiftType> CreateOrGetShiftTypeAsync(
            this ApplicationDbContext dbContext,
            IRoleResolver roleResolver,
            IAuditFactory auditFactory,
            ShiftTypeCreate create)
        {
            var shiftType = create.Map();
            var existingShiftType = await dbContext.ShiftTypes.GetMatchAsync(shiftType);

            if (existingShiftType == null)
            {
                dbContext.ShiftTypes.Add(shiftType.AuditCreated(auditFactory.CreateAudit()));
                existingShiftType = shiftType;
            }

            if (await roleResolver.IsInRoleAsync(ApplicationRoles.Administrator))
            {
                existingShiftType.IsSearchable = true;
            }

            return existingShiftType;
        }
    }
}
