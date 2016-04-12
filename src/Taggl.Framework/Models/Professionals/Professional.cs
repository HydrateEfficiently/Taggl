using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Professionals
{
    public class Professional
    {
        public Guid Id { get; set; }

        [InverseProperty(nameof(ProfessionalExpertise.Professional))]
        public virtual ICollection<ProfessionalExpertise> Expertise { get; set; }
    }
}
