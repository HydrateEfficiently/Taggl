using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using Taggl.Framework.Models.Professionals;

namespace Taggl.Framework.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid? RelationshipsId { get; set; }

        public virtual ApplicationUserRelationships Relationships { get; set; }
    }
}
