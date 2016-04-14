using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Professionalities;

namespace Taggl.Framework.Models.Identity
{
    public class ApplicationUserRelationships
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Guid StatusId { get; set; }

        public ApplicationUserStatus Status { get; set; }

        public Guid ProfessionalityId { get; set; }

        public virtual Professionality Professionality { get; set; }
    }
}
