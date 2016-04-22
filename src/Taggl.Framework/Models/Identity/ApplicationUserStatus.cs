using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;

namespace Taggl.Framework.Models.Identity
{
    [GeneratedEntity(TableName = "UserStatuses")]
    public class ApplicationUserStatus
    {
        public Guid Id { get; set; }

        public DateTime? Approved { get; set; }

        public string ApprovedById { get; set; }

        public virtual ApplicationUser ApprovedBy { get; set; }
    }
}
