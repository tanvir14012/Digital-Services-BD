using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Services_BD.Utilities
{
    public static class StringUtils
    {
        public static string Truncate(this string str, int maxChars)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            return str.Length > maxChars ? str.Substring(0, maxChars) : str;
        }
    }

}
