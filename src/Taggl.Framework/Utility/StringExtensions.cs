using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Framework.Utility
{
    public static class StringExtensions
    {
        public static string TrimInnerExcess(this string str)
        {
            return string.Join(" ", str.Split(' ').Select(s => s.Trim()));
        }
    }
}
