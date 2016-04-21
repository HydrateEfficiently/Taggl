using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services.Audits;
using Taggl.CodeGeneration.Services.Properties;

namespace Taggl.CodeGeneration.Generators.Entity
{
    public class EntityTemplateModel
    {
        public string AreaName { get; internal set; }
        public string EntityName { get; internal set; }
        public string FrameworkEntitiesNamespace { get; internal set; }
        public string IdentityTypeName { get; internal set; }
        public List<string> Interfaces { get; internal set; }
        public List<PropertyDeclarationModel> Properties { get; internal set; }
        public bool HasInterface { get { return Interfaces.Count() > 0; } }
        public string FrameworkEntityNamespace { get; internal set; }
        public List<AuditDeclarationModel> Audits { get; internal set; }
        public bool HasAudit { get { return Audits.Count() > 0; } }
        public string TableName { get; internal set; }
        public string GenerationCoreNamespace { get; internal set; }
    }
}
