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

        [InverseProperty(nameof(Professionalities.Expertise.Professionality))]
        public virtual ICollection<Expertise> Expertise { get; set; } = new List<Expertise>();
    }
}
