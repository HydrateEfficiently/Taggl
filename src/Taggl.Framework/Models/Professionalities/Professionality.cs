using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Identity;

namespace Taggl.Framework.Models.Professionalities
{
    public class Professionality
    {
        public Guid Id { get; set; }

        [InverseProperty(nameof(ProfessionalExpertise.Professionality))]
        public virtual ICollection<ProfessionalExpertise> Expertise { get; set; }
            = new List<ProfessionalExpertise>();
    }
}
