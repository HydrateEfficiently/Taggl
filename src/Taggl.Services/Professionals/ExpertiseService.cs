using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ExpertiseService(
            ApplicationDbContext dbContext,
            IIdentityResolver identityResolver)
        {
            _dbContext = dbContext;
            _identityResolver = identityResolver;
        }

        public async Task<ProfessionalExpertise> CreateAsync(JobTagCreate create)
        {
            var identityId = _identityResolver.Resolve().GetId();
            var professionality = await _dbContext.UserRelationships.GetProfessionalityByUser(identityId);
            var jobTag = await _dbContext.CreateOrGetJobTagAsync(create);

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
