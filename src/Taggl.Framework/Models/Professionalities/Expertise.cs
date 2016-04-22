using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Shifts;

namespace Taggl.Framework.Models.Professionalities
{
    [GeneratedEntity(TableName = "Expertise")]
    public class Expertise : ICreateAuditable, IDeleteAuditable
    {
        public Guid Id { get; set; }

        public Guid ProfessionalityId { get; set; }
        
        public virtual Professionality Professionality { get; set; }

        public Guid ShiftTypeId { get; set; }

        public virtual ShiftType ShiftType { get; set; }

        public DateTime Created { get; set; }

        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public DateTime? Deleted { get; set; }

        public string DeletedById { get; set; }

        public virtual ApplicationUser DeletedBy { get; set; }
    }
}
