using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Services.Identity.Models
{
    public enum ResolvedUserStatus
    {
        Unknown,

        Registered,

        Pending,

        Active,

        Deactived
    }
}
