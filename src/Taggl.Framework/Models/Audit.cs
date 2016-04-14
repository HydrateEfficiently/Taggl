using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Services;
using Taggl.Framework.Utility;

namespace Taggl.Framework.Models
{
    public class Audit
    {
        public DateTime Actioned { get; set; }

        public string ActionedById { get; set; }

        public Audit(DateTime actioned, string actionedId)
        {
            Actioned = actioned;
            ActionedById = actionedId;
        }
    }
}
