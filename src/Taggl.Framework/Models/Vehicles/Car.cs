using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Vehicles
{
    public class Car : IUpdateAuditable, IDeleteAuditable, ICreateAuditable
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public DateTime Updated { get; set; }

        public string UpdatedById { get; set; }

        public virtual ApplicationUser UpdatedBy { get; set; }

        public DateTime? Deleted { get; set; }

        public string DeletedById { get; set; }

        public virtual ApplicationUser DeletedBy { get; set; }
    }
}
