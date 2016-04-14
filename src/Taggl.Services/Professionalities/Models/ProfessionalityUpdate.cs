using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Jobs.Models;

namespace Taggl.Services.Professionalities.Models
{
    public class ProfessionalityUpdate
    {
        public string UserId { get; set; }

        public IEnumerable<ExpertiseResult> Expertise { get; set; }
            = Enumerable.Empty<ExpertiseResult>();
    }
}
