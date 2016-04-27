using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Services;
using Taggl.Services.Gyms.Models;
using Taggl.Services.Gyms.Queries;
using Taggl.Services.Identity;
using Taggl.Services.Shifts.Models;
using Taggl.Services.Shifts.Queries;

namespace Taggl.Services.Shifts
{
    public interface IShiftScheduleService {
        Task<IEnumerable<ShiftScheduleResult>> ListAsync(string userId, DateTime date);

        Task<ShiftScheduleResult> GetAsync(Guid id);

        Task<ShiftScheduleResult> CreateAsync(ShiftScheduleCreate create);
        
        Task<ShiftScheduleResult> UpdateAsync(ShiftScheduleUpdate update);
                
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
        
        public async Task<IEnumerable<ShiftScheduleResult>> ListAsync(string userId, DateTime date)
        {
            return (await _dbContext.ShiftSchedules
                .WhereCreatedByUser(userId)
                .WhereIsOnDate(date)
                .IncludeForResult()
                .ToListAsync()).Select(s => new ShiftScheduleResult(s));
        }

        public async Task<ShiftScheduleResult> GetAsync(Guid id)
        {
            var result = await _dbContext.ShiftSchedules
                .Find(id)
                .IncludeForResult()
                .FirstOrDefaultAsync();
            return new ShiftScheduleResult(result);
        }

        public async Task<ShiftScheduleResult> CreateAsync(ShiftScheduleCreate create)
        {
            var shiftSchedule = create.Map();
            var audit = _auditFactory.CreateAudit();
            shiftSchedule.AuditCreated(audit).AuditUpdated(audit);

            if (create.ShiftTypeId != Guid.Empty)
            {
                shiftSchedule.ShiftTypeId = create.ShiftTypeId;
            }
            else if (!string.IsNullOrEmpty(create.ShiftTypeName))
            {
                shiftSchedule.ShiftType = await _dbContext.CreateOrGetShiftTypeAsync(
                    _roleResolver, _auditFactory, new ShiftTypeCreate() { Name = create.ShiftTypeName });
            }
            else
            {
                throw new Exception(); // TODO: Validation
            }

            if (create.GymId != Guid.Empty)
            {
                shiftSchedule.GymId = create.GymId;
            }
            else if (!string.IsNullOrEmpty(create.GymName))
            {
                shiftSchedule.Gym = await _dbContext.CreateOrGetGymAsync(
                    _roleResolver, _auditFactory, new GymCreate() { Name = create.GymName });
            }
            else
            {
                throw new Exception(); // TODO: Validation
            }
            
            await _dbContext.SaveChangesAsync();
            return await GetAsync(shiftSchedule.Id);
        }

        public async Task<ShiftScheduleResult> UpdateAsync(ShiftScheduleUpdate update)
        {
            var shiftSchedule = await _dbContext.ShiftSchedules.Find(update.Id).FirstOrDefaultAsync();
            update.Map(shiftSchedule).AuditUpdated(_auditFactory.CreateAudit());
            await _dbContext.SaveChangesAsync();
            return await GetAsync(shiftSchedule.Id);
        }

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