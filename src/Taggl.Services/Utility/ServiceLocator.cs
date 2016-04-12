using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Services.Utility
{
    public static class ServiceLocator
    {
        public static IServiceProvider Current { get; set; }
    }
}
