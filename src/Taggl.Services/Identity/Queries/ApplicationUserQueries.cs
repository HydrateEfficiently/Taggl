﻿using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Services.Identity.Queries
{
    public static class ApplicationUserQueries
    {
        public static async Task<ApplicationUser> GetUserAsync(
            this IQueryable<ApplicationUserRelationships> queryable,
            string userId)
        {
            return await queryable
                .QueryByUser(userId)
                .Select(r => r.User)
                .FirstAsync();
        }
    }
}
