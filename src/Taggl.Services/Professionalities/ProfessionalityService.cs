using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Models.Professionalities;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Shifts;
using Taggl.Services.Shifts.Models;
using Taggl.Services.Professionalities.Models;
using Taggl.Services.Professionalities.Queries;
using Microsoft.Data.Entity;
using Taggl.Framework.Models;
using Taggl.Services.Identity;

namespace Taggl.Services.Professionalities
{
    public interface IProfessionalityService
    {
        Task<ProfessionalityResult> GetAsync(string userId);

        Task<ProfessionalityResult> UpdateAsync(ProfessionalityUpdate update);
    }

    public class ProfessionalityService : IProfessionalityService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRoleResolver _roleResolver;
        private readonly IAuditFactory _auditFactory;

        public ProfessionalityService(
            ApplicationDbContext dbContext,
            IRoleResolver roleResolver,
            IAuditFactory auditFactory)
        {
            _dbContext = dbContext;
            _roleResolver = roleResolver;
            _auditFactory = auditFactory;
        }

        // TODO: Authorize
        public async Task<ProfessionalityResult> GetAsync(string userId)
        {
            var professionality = await _dbContext.ApplicationUserRelationships
                .QueryProfessionalityByUser(userId)
                .GetForResultAsync(_dbContext);
            return new ProfessionalityResult(professionality).AddUserId(userId);
        }

        public async Task<ProfessionalityResult> UpdateAsync(ProfessionalityUpdate update)
        {
            var professionality = await _dbContext.ApplicationUserRelationships
                .QueryProfessionalityByUser(update.UserId)
                .GetForResultAsync(_dbContext);
            var existingExpertise = professionality.Expertise;
            var currentExpertise = update.Expertise;

            var expertiseToDelete = existingExpertise.Except(
                currentExpertise, e => e.Id, e => e.Id);
            expertiseToDelete.ForEach(e => e.Delete(_auditFactory.CreateAudit()));

            var expertiseToAdd = currentExpertise.Where(e => e.Id == Guid.Empty);
            var creationTasks = expertiseToAdd.Select(e =>
                _dbContext.CreateExpertiseAsync(_roleResolver, _auditFactory, professionality.Id, e.ShiftTypeName));
            var createdExpertise = await Task.WhenAll(creationTasks);

            await _dbContext.SaveChangesAsync();

            return await GetAsync(update.UserId); // TODO: Hitting DB again unnessecarily?
        }
    }
}
