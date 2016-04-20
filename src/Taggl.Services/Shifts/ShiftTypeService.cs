using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;
using Taggl.Services.Identity;
using Taggl.Services.Shifts.Models;
using Taggl.Services.Shifts.Queries;

namespace Taggl.Services.Shifts
{
    public interface IShiftTypeService
    {
        Task<ShiftType> CreateAsync(ShiftTypeCreate create);
    }

    public class ShiftTypeService : IShiftTypeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IIdentityResolver _identityResolver;
        private readonly IRoleResolver _roleResolver;
        private readonly IAuditFactory _auditFactory;

        public ShiftTypeService(
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

        public async Task<ShiftType> CreateAsync(ShiftTypeCreate create)
        {
            var shiftType = await _dbContext.CreateOrGetShiftTypeAsync(
                _roleResolver, _auditFactory, create);
            await _dbContext.SaveChangesAsync();
            return shiftType;
        }
    }
}
