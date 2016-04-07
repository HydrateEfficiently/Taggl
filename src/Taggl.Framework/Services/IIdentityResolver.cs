﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Taggl.Framework.Services
{
    public interface IIdentityResolver
    {
        ClaimsPrincipal Resolve();

        bool IsSignedIn();
    }
}
