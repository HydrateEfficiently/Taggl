using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Core;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Gyms
{
    [GeneratedEntity(TableName = "Gyms")]
    public class Gym : 
        ICreateAuditable,
        IUpdateAuditable,
        IDeleteAuditable,
        ISearchableName
    {
        [DtoGenerateIgnore(DtoType.Create)]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        [DtoGenerateIgnore(DtoType.Create, DtoType.Update)]
        public string NameNormalized { get; set; }

        [DtoGenerateIgnore]
        public bool IsSearchable { get; set; }

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
    }
}