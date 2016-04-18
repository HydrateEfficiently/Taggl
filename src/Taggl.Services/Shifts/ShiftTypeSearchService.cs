using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Shifts;
using Taggl.Services.Shifts.Queries;

namespace Taggl.Services.Shifts
{
    public interface IShiftTypeSearchService
    {
        Task<IEnumerable<ShiftType>> Search(string pattern);
    }

    public class ShiftTypeSearchService : IShiftTypeSearchService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IShiftTypeFormatter _shiftTypeFormatter;

        public ShiftTypeSearchService(
            ApplicationDbContext dbContext,
            IShiftTypeFormatter shiftTypeFormatter)
        {
            _dbContext = dbContext;
            _shiftTypeFormatter = shiftTypeFormatter;
        }

        public async Task<IEnumerable<ShiftType>> Search(string pattern)
        {
            return await _dbContext.ShiftTypes
                .WhereSearchable()
                .WherePatternMatched(_shiftTypeFormatter, pattern)
                .ToListAsync();
        }
    }
}
