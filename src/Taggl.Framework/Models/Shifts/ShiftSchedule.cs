using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;
using Taggl.Framework.Models.Gyms;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Shifts
{
    [GeneratedEntity(TableName = "ShiftSchedules")]
    public class ShiftSchedule : HasKey<Guid>, ICreateAuditable, IUpdateAuditable, IDeleteAuditable
    {
        [DtoGenerateIgnore(DtoType.Create)]
        public Guid Id { get; set; }
        
        public Guid ShiftTypeId { get; set; }

        [DtoGenerateIgnore(DtoType.Create)]
        public virtual ShiftType ShiftType { get; set; }
        
        public Guid GymId { get; set; }

        [DtoGenerateIgnore(DtoType.Create)]
        public virtual Gym Gym { get; set; }
        
        public DateTime FromDate { get; set; }

        [DtoGenerateIgnore(DtoType.Create)]
        public TimeSpan Duration { get; set; }

        #region Auditing

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public DateTime Created { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public string CreatedById { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public virtual ApplicationUser CreatedBy { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public DateTime Updated { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public string UpdatedById { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public virtual ApplicationUser UpdatedBy { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public DateTime? Deleted { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public string DeletedById { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public virtual ApplicationUser DeletedBy { get; set; }

        #endregion
    }
}