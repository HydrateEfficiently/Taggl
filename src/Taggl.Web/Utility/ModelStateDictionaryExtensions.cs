using Microsoft.AspNet.Mvc.ModelBinding;
using Taggl.Services.Identity;
using Taggl.Services.Identity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Web.Utility
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddIdentityErrors(
            this ModelStateDictionary modelState,
            IdentityErrorException ex)
        {
            foreach (string error in ex.Errors)
            {
                modelState.AddModelError(string.Empty, error);
            }
        }
    }
}
