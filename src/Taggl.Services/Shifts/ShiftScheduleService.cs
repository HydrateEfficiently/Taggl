using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Services;
using Taggl.Services.Gyms.Queries;
using Taggl.Services.Identity;
using Taggl.Services.Shifts.Models;
using Taggl.Services.Shifts.Queries;

namespace Taggl.Services.Shifts
{
    public interface IShiftScheduleService {
        Task<IEnumerable<ShiftScheduleResult>> ListAsync(string userId);

        Task<ShiftScheduleResult> GetAsync(Guid id);

        Task<ShiftScheduleResult> CreateAsync(ShiftScheduleCreate create);
        
        //Task<ShiftScheduleResult> UpdateAsync(UpdateShiftSchedule update);
                
        Task DeleteAsync(Guid id);
    }

    public class ShiftScheduleService : IShiftScheduleService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityResolver _identityResolver;
        private readonly IRoleResolver _roleResolver;
        private readonly IAuditFactory _auditFactory;
        
        public ShiftScheduleService(
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
        
        public async Task<IEnumerable<ShiftScheduleResult>> ListAsync(string userId)
        {
            return (await _dbContext.ShiftSchedules
                .Where(s => s.CreatedById == userId)
                .ToListAsync()).Select(s => new ShiftScheduleResult(s));
        }

        public async Task<ShiftScheduleResult> GetAsync(Guid id)
        {
            var result = await _dbContext.ShiftSchedules
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            return new ShiftScheduleResult(result);
        }

        public async Task<ShiftScheduleResult> CreateAsync(ShiftScheduleCreate create)
        {
            var shiftSchedule = create.Map();
            var audit = _auditFactory.CreateAudit();
            shiftSchedule.AuditCreated(audit).AuditUpdated(audit);
            _dbContext.ShiftSchedules.Add(shiftSchedule);
            await _dbContext.CreateOrGetGymAsync(_roleResolver, _auditFactory, create.Gym);
            await _dbContext.CreateOrGetShiftTypeAsync(_roleResolver, _auditFactory, create.ShiftType);
            await _dbContext.SaveChangesAsync();
            return new ShiftScheduleResult(shiftSchedule);
        }
        
        //public async Task<ShiftScheduleResult> UpdateAsync(UpdateShiftSchedule update)
        //{
        //    var shiftSchedule = update.Map().Update(_auditFactory.CreateAudit());
        //    await _dbContext.SaveChangesAsync();
        //    return new ShiftScheduleResult(shiftSchedule);
        //}
                
        public async Task DeleteAsync(Guid id)
        {
            var result = await _dbContext.ShiftSchedules
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            _dbContext.ShiftSchedules.Remove(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}