using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Utility;

namespace Taggl.Services.Shifts
{
    public interface IShiftTypeFormatter
    {
        string FormatName(string name);

        string NormalizeName(string name);
    }

    public class ShiftTypeFormatter : IShiftTypeFormatter
    {
        private readonly ILookupNormalizer _lookupNormalizer;

        public ShiftTypeFormatter(
            ILookupNormalizer lookupNormalizer)
        {
            _lookupNormalizer = lookupNormalizer;
        }

        public string FormatName(string name)
        {
            return name.Trim().TrimInnerExcess();
        }

        public string NormalizeName(string name)
        {
            return _lookupNormalizer.Normalize(FormatName(name));
        }
    }
}
