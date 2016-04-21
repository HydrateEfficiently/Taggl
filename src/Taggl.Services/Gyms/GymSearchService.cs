using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;
using Taggl.Services.Gyms.Models;

namespace Taggl.Services.Gyms
{
    public interface IGymSearchService
    {
        Task<IEnumerable<GymResult>> Search(string pattern);
    }

    public class GymSearchService : IGymSearchService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISearchableNameFormatter _searchableNameFormatter;

        public GymSearchService(
            ApplicationDbContext dbContext,
            ISearchableNameFormatter searchableNameFormatter)
        {
            _dbContext = dbContext;
            _searchableNameFormatter = searchableNameFormatter;
        }

        public async Task<IEnumerable<GymResult>> Search(string pattern)
        {
            return (await _dbContext.Gyms
                .WhereSearchable<Gym>()
                .WherePatternMatched<Gym>(_searchableNameFormatter, pattern)
                .Include(g => g.CreatedBy)
                .ToListAsync()).Select(g => new GymResult(g));
        }
    }
}
