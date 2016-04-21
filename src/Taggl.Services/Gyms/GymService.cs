using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Gyms;
using Taggl.Framework.Services;
using Taggl.Services.Gyms.Models;
using Taggl.Services.Gyms.Queries;
using Taggl.Services.Identity;

namespace Taggl.Services.Gyms
{
    public interface IGymService {
        Task<IEnumerable<GymResult>> ListAsync(string userId);

        Task<GymResult> GetAsync(Guid id);

        Task<GymResult> CreateAsync(GymCreate create);
        
        //Task<GymResult> UpdateAsync(UpdateGym update);
                
        Task DeleteAsync(Guid id);
    }

    public class GymService : IGymService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityResolver _identityResolver;
        private readonly IRoleResolver _roleResolver;
        private readonly IAuditFactory _auditFactory;
        
        public GymService(
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
        
        public async Task<IEnumerable<GymResult>> ListAsync(string userId)
        {
            return (await _dbContext.Gyms
                .Where(g => g.CreatedById == userId)
                .ToListAsync()).Select(g => new GymResult(g));
        }

        public async Task<GymResult> GetAsync(Guid id)
        {
            var result = await _dbContext.Gyms
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
            return new GymResult(result);
        }

        public async Task<GymResult> CreateAsync(GymCreate create)
        {
            var gym = await _dbContext.CreateOrGetGymAsync(
                _roleResolver, _auditFactory, create);
            await _dbContext.SaveChangesAsync();
            return new GymResult(gym);
        }
        
        //public async Task<GymResult> UpdateAsync(UpdateGym update)
        //{
        //    var gym = update.Map().Update(_auditFactory.CreateAudit());
        //    await _dbContext.SaveChangesAsync();
        //    return new GymResult(gym);
        //}
                
        public async Task DeleteAsync(Guid id)
        {
            var result = (await _dbContext.Gyms
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync())
                .AuditDeleted(_auditFactory.CreateAudit());
            _dbContext.Gyms.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}