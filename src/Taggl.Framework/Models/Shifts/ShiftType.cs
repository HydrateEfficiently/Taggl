using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core.Attributes;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Shifts
{
    [GeneratedEntity(TableName = "ShiftTypes")]
    public class ShiftType
        : ICreateAuditable, ISearchableName
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameNormalized { get; set; }

        public bool IsSearchable { get; set; }

        public DateTime Created { get; set; }

        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
    }
}
