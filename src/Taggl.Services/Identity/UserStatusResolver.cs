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
        ResolvedUserStatus Resolve(ApplicationUserRelationships userRelationships);
    }

    public class UserStatusResolver : IUserStatusResolver
    {
        public ResolvedUserStatus Resolve(ApplicationUserRelationships userRelationships)
        {
            if (!userRelationships.User.EmailConfirmed)
            {
                return ResolvedUserStatus.Registered;
            }

            var status = userRelationships.Status;
            if (!status.Approved.HasValue)
            {
                return ResolvedUserStatus.Pending;
            }

            return ResolvedUserStatus.Active;
        }
    }
}
