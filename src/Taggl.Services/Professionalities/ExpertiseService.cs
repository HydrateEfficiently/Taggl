using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Professionalities;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Jobs.Models;
using Taggl.Services.Jobs.Queries;
using Taggl.Services.Professionalities.Queries;

namespace Taggl.Services.Professionalities
{
    public interface IExpertiseService
    {
        Task<ProfessionalExpertise> CreateAsync(JobTagCreate create);
    }

    public class ExpertiseService : IExpertiseService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityResolver _identityResolver;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExpertiseService(
            ApplicationDbContext dbContext,
            IIdentityResolver identityResolver,
            UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _identityResolver = identityResolver;
            _userManager = userManager;
        }

        public async Task<ProfessionalExpertise> CreateAsync(JobTagCreate create)
        {
            var identityId = _identityResolver.Resolve().GetId();
            var professionality = await _dbContext.UserRelationships.GetProfessionalityByUser(identityId);
            var jobTag = await _dbContext.CreateOrGetJobTagAsync(_identityResolver, _userManager, create);

            var expertise = new ProfessionalExpertise()
            {
                JobTag = jobTag,
                Professionality = professionality
            };
            _dbContext.ProfessionalExpertise.Add(expertise);
            await _dbContext.SaveChangesAsync();
            
            return expertise;
        }
    }
}
