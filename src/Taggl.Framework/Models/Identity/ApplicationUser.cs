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
        public Guid? PersonalInformationId { get; set; }

        public virtual PersonalInformation PersonalInformation { get; set; }

        public Guid? ProfessionalId { get; set; }

        public virtual Professional Professional { get; set; }
    }
}
