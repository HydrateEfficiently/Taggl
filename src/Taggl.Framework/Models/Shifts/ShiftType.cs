using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Shifts
{
    [GeneratedEntity(TableName = "ShiftTypes")]
    public class ShiftType
        : ICreateAuditable, ISearchableName
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public string NameNormalized { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public bool IsSearchable { get; set; }

        public int ColorSwitch { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public DateTime Created { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public string CreatedById { get; set; }

        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public virtual ApplicationUser CreatedBy { get; set; }
    }
}
