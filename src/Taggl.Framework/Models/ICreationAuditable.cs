using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models
{
    public interface ICreationAuditable
    {
        DateTime Created { get; set; }

        string CreatedById { get; set; }

        ApplicationUser CreatedBy { get; set; }
    }

    public static class CreationAuditableExtensions
    {
        public static void Create(
            this ICreationAuditable creationAuditable,
            Audit audit)
        {
            creationAuditable.Created = audit.Actioned;
            creationAuditable.CreatedById = audit.ActionedById;
        }
    }
}
