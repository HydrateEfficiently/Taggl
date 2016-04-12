using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Services.Identity.Queries
{
    public static class ApplicationUserQueries
    {
        public static async Task<ApplicationUser> GetAsync(
            this IQueryable<ApplicationUser> queryable,
            string id)
        {
            return await queryable
                .Where(u => u.Id == id)
                .Include(u => u.Relationships).ThenInclude(u => u.Professional)
                .Include(u => u.Relationships).ThenInclude(u => u.Status)
                .FirstAsync();
        }
    }
}
