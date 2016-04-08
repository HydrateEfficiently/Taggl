using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Services;

namespace Taggl.Initializer.Services.Framework
{
    public class StubbedUrlResolver : IUrlResolver
    {
        public string ResolveConfirmationEmailUrl(string userId, string emailConfirmationToken)
        {
            return string.Empty;
        }
    }
}
