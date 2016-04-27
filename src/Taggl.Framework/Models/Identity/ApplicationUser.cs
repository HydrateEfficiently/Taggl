using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taggl.Framework.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string Initials
        {
            get
            {
                var initials = HasFullName ?
                    $"{FirstName[0]}{LastName[0]}" :
                    Email[0].ToString();
                return initials.ToUpperInvariant();
            }
        }

        [NotMapped]
        public string DisplayName
        {
            get
            {
                if (HasFullName)
                {
                    return $"{FirstName} {LastName}";
                }
                return Email;
            }
        }

        [NotMapped]
        public bool HasFullName
        {
            get
            {
                return !string.IsNullOrEmpty(FirstName) && 
                    !string.IsNullOrEmpty(LastName);
            }
        }
    }
}
