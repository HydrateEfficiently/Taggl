using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Identity.Models;

namespace Taggl.Services.Identity
{
    public interface IUserStatusResolver
    {
        ResolvedUserStatus Resolve(ApplicationUserStatus status);
    }

    public class UserStatusResolver : IUserStatusResolver
    {
        public ResolvedUserStatus Resolve(ApplicationUserStatus status)
        {
            if (!status.ApplicationUser.EmailConfirmed)
            {
                return ResolvedUserStatus.Registered;
            }
            
            if (!status.Approved.HasValue)
            {
                return ResolvedUserStatus.Pending;
            }

            return ResolvedUserStatus.Active;
        }
    }
}
