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
            var personalInformation = user.PersonalInformation;
            if (!string.IsNullOrEmpty(personalInformation.FirstName) &&
                !string.IsNullOrEmpty(personalInformation.LastName))
            {
                return $"{personalInformation.FirstName} {personalInformation.LastName}";
            }
            return user.Email;
        }
    }
}
