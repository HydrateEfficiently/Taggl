using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Framework.Models.Identity
{
    public class PersonalInformation
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Updated { get; set; }

        public string UpdateById { get; set; }

        public virtual ApplicationUser UpdatedBy { get; set; }
    }
}
