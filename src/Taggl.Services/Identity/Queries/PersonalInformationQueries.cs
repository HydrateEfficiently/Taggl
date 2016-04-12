using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Services.Identity.Queries
{
    public static class PersonalInformationQueries
    {
        public static async Task<PersonalInformation> GetAsync(
            this IQueryable<PersonalInformation> queryable,
            Guid id)
        {
            return await queryable.FirstAsync(pi => pi.Id == id);
        }
    }
}
