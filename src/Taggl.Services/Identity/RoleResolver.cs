﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Services.Identity
{
    public interface IRoleResolver
    {
        Task<bool> IsInRoleAsync(string role);
    }

    public class RoleResolver : IRoleResolver
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICurrentUserProvider _currentUserProvider;

        public RoleResolver(
            UserManager<ApplicationUser> userManager,
            ICurrentUserProvider currentUserProvider)
        {
            _userManager = userManager;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<bool> IsInRoleAsync(string role)
        {
            var currentUser = await _currentUserProvider.GetApplicationUserAsync();
            return await _userManager.IsInRoleAsync(currentUser, role);
        }
    }
}
