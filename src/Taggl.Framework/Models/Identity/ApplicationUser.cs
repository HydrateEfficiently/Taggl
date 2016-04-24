using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Taggl.Framework.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName))
                {
                    return $"{FirstName} {LastName}";
                }
                return Email;
            }
        }
    }
}
