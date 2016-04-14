using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Jobs;

namespace Taggl.Framework.Models.Professionalities
{
    public class Expertise : ICreationAuditable, IDeletionAuditable
    {
        public Guid Id { get; set; }

        public Guid ProfessionalityId { get; set; }
        
        public virtual Professionality Professionality { get; set; }

        public Guid JobTagId { get; set; }

        public virtual JobTag JobTag { get; set; }

        public DateTime Created { get; set; }

        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public DateTime? Deleted { get; set; }

        public string DeletedById { get; set; }

        public virtual ApplicationUser DeletedBy { get; set; }
    }
}
