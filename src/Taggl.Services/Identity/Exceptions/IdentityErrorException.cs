using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Taggl.Services.Identity.Exceptions
{
    public class IdentityErrorException : Exception
    {
        public IEnumerable<string> Errors { get; set; }

        public IdentityErrorException(params string[] errors) : base()
        {
            Errors = errors;
        }

        public IdentityErrorException(IdentityResult createResult)
            : this(createResult.Errors
                .Select(e => e.Description)
                .ToArray()) {
        }
    }
}
