using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Constants;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Gyms;
using Taggl.Services.Gyms.Models;
using Taggl.Services.Identity;

namespace Taggl.Services.Gyms.Queries
{
    public static class GymQueries
    {
        public static async Task<Gym> CreateOrGetGymAsync(
            this ApplicationDbContext dbContext,
            IRoleResolver roleResolver,
            IAuditFactory auditFactory,
            GymCreate create)
        {
            var gym = create.Map();
            var existingGym = await dbContext.Gyms.GetMatchAsync(gym);

            if (existingGym == null)
            {
                dbContext.Gyms.Add(gym.AuditCreated(auditFactory.CreateAudit()));
                existingGym = gym;
            }

            if (await roleResolver.IsInRoleAsync(ApplicationRoles.Administrator))
            {
                existingGym.IsSearchable = true;
            }

            return existingGym;
        }
    }
}
