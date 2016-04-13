using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Professionalities.Models;
using Taggl.Services.Professionalities.Queries;

namespace Taggl.Services.Professionalities
{
    public interface IProfessionalityService
    {
        Task<ProfessionalityResult> GetAsync(string userId);
    }

    public class ProfessionalityService : IProfessionalityService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfessionalityService(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // TODO: Authorize
        public async Task<ProfessionalityResult> GetAsync(string userId)
        {
            var professionality = await _dbContext.UserRelationships
                .QueryProfessionalityByUser(userId)
                .GetForResultAsync();

            return new ProfessionalityResult(professionality);
        }
    }
}
