using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Jobs;

namespace Taggl.Framework.Models.Professionals
{
    public class ProfessionalExpertise
    {
        public Guid Id { get; set; }

        public Guid ProfessionalId { get; set; }

        public virtual Professional Professional { get; set; }

        public Guid JobTagId { get; set; }

        public virtual JobTag JobTag { get; set; }
    }
}
