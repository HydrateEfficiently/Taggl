using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Professionalities;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity;
using Taggl.Services.Shifts.Models;
using Taggl.Services.Shifts.Queries;
using Taggl.Services.Professionalities.Queries;

namespace Taggl.Services.Professionalities
{
    public interface IExpertiseService
    {
        Task<Expertise> CreateAsync(ShiftTypeCreate create);
    }

    public class ExpertiseService : IExpertiseService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityResolver _identityResolver;
        private readonly IRoleResolver _roleResolver;
        private readonly IAuditFactory _auditFactory;

        public ExpertiseService(
            ApplicationDbContext dbContext,
            IIdentityResolver identityResolver,
            IRoleResolver roleResolver,
            IAuditFactory auditFactory)
        {
            _dbContext = dbContext;
            _identityResolver = identityResolver;
            _roleResolver = roleResolver;
            _auditFactory = auditFactory;
        }

        public async Task<Expertise> CreateAsync(ShiftTypeCreate create)
        {
            var identityId = _identityResolver.Resolve().GetId();
            var professionality = await _dbContext.UserRelationships.GetProfessionalityByUser(identityId);
            var expertise = await _dbContext.CreateExpertiseAsync(
                _roleResolver, _auditFactory, professionality.Id, create.Name); // TODO: Currently mapping ShiftTypeCreate => string => ShiftTypeCreate
            await _dbContext.SaveChangesAsync();
            return expertise;
        }
    }
}
