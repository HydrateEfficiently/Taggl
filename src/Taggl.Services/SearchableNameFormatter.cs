using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Utility;

namespace Taggl.Services
{
    public interface ISearchableNameFormatter
    {
        string FormatName(string name);

        string NormalizeName(string name);
    }

    public class SearchableNameFormatter : ISearchableNameFormatter
    {
        private readonly ILookupNormalizer _lookupNormalizer;

        public SearchableNameFormatter(
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
