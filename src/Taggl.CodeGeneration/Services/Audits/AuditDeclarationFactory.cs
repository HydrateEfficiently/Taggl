using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services.Properties;
using Taggl.CodeGeneration.Utility;
using Taggl.Framework.Models;
using Taggl.Framework.Models.Identity;

namespace Taggl.CodeGeneration.Services.Audits
{
    public interface IAuditDeclarationFactory
    {
        AuditDeclarationModel CreateAuditProperties(string auditCommand);
    }

    public class AuditDeclarationFactory : IAuditDeclarationFactory
    {
        public AuditDeclarationModel CreateAuditProperties(string auditCommand)
        {
            bool isNullable = false;
            string fromInterface = null;
            string auditName = null;
            string auditNameLower = auditCommand.ToLowerInvariant();
            if (auditNameLower == "c")
            {
                auditName = nameof(ICreateAuditable.Created);
                isNullable = typeof(ICreateAuditable).IsPropertyNullable(auditName);
                fromInterface = nameof(ICreateAuditable);
            }
            else if (auditNameLower == "u")
            {
                auditName = nameof(IUpdateAuditable.Updated);
                isNullable = typeof(IUpdateAuditable).IsPropertyNullable(auditName);
                fromInterface = nameof(IUpdateAuditable);
            }
            else if (auditNameLower == "d")
            {
                auditName = nameof(IDeleteAuditable.Deleted);
                isNullable = typeof(IDeleteAuditable).IsPropertyNullable(auditName);
                fromInterface = nameof(IDeleteAuditable);
            }
            else
            {
                auditName = auditCommand;
                if (auditCommand.EndsWith("?"))
                {
                    auditName = auditCommand.Replace("?", string.Empty);
                    isNullable = true;
                }
            }

            return new AuditDeclarationModel()
            {
                Name = auditName,
                IsNullable = isNullable,
                FromInterface = fromInterface
            };
        }
    }
}
