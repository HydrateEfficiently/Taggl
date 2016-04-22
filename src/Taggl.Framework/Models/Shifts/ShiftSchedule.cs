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
    public class ShiftSchedule : ICreateAuditable, IUpdateAuditable, IDeleteAuditable
    {
        public Guid Id { get; set; }
        
        public Guid ShiftTypeId { get; set; }
        
        public virtual ShiftType ShiftType { get; set; }
        
        public Guid GymId { get; set; }
        
        public virtual Gym Gym { get; set; }
        
        public DateTime FromDate { get; set; }
        
        public TimeSpan Duration { get; set; }

        #region Auditing

        public DateTime Created { get; set; }
        
        public string CreatedById { get; set; }
        
        public virtual ApplicationUser CreatedBy { get; set; }
        
        public DateTime Updated { get; set; }
        
        public string UpdatedById { get; set; }
        
        public virtual ApplicationUser UpdatedBy { get; set; }
        
        public DateTime? Deleted { get; set; }
        
        public string DeletedById { get; set; }
        
        public virtual ApplicationUser DeletedBy { get; set; }

        #endregion
    }
}