using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Gyms
{
    public class Gym : 
        ICreateAuditable,
        IUpdateAuditable,
        IDeleteAuditable,
        ISearchableName
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string NameNormalized { get; set; }

        public bool IsSearchable { get; set; }

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