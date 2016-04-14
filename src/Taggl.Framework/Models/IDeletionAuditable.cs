using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models
{
    public interface IDeletionAuditable
    {
        DateTime? Deleted { get; set; }

        string DeletedById { get; set; }

        ApplicationUser DeletedBy { get; set; }
    }

    public static class DeletionAuditableExtensions
    {
        public static void Delete(
            this IDeletionAuditable deletionAuditable,
            Audit audit)
        {
            deletionAuditable.Deleted = audit.Actioned;
            deletionAuditable.DeletedById = audit.ActionedById;
        }
    }
}
