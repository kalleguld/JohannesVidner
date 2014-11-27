using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JohannesVidnerProject.Helpers
{
    public static class StringHelper
    {
        public static string Fmt(this string fmtString, params object[] paramStrings)
        {
            return string.Format(fmtString, paramStrings);
        }
    }
}