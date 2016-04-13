using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Framework.Models.Jobs
{
    public class JobTag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NameNormalized { get; set; }

        public bool IsSearchable { get; set; }
    }
}
