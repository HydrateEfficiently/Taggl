using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Framework.Models.Identity
{
    public static class ApplicationUserExtensions
    {
        public static string GetDisplayName(this ApplicationUser user)
        {
            if (!string.IsNullOrEmpty(user.FirstName) &&
                !string.IsNullOrEmpty(user.LastName))
            {
                return $"{user.FirstName} {user.LastName}";
            }
            return user.Email;
        }
    }
}
