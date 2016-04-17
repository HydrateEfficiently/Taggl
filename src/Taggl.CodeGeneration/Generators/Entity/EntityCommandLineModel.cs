using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands;
using Taggl.CodeGeneration.Commands.Models;

namespace Taggl.CodeGeneration.Generators.Entity
{
    public class EntityCommandLineModel : FromEntityCommandLineModel,
        HasIdentityCommandLineModel
    {
        [Option(Name = "area", ShortName = "a", Description = "The namespace name below the root entities namespace.")]
        public string Area { get; set; }

        [Option(Name = "identity", ShortName = "i", Description = "The type of the identity property, \"Id\", g: guid (default), i: int")]
        public string IdentityTypeName { get; set; }

        [Option(Name = "auditCreate", ShortName = "c", Description = "A flag which determines if the entity should inherit from ICreateAuditable")]
        public bool AuditCreate { get; set; }

        [Option(Name = "auditUpdate", ShortName = "u", Description = "A flag which determines if the entity should inherit from IUpdateAuditable")]
        public bool AuditUpdate { get; set; }

        [Option(Name = "auditDelete", ShortName = "d", Description = "A flag which determines if the entity should inherit from IDeleteAuditable")]
        public bool AuditDelete { get; set; }
    }
}
