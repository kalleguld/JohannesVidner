using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using Resources;

namespace JohannesVidnerProject.Helpers
{
    public class CultureHelper
    {
        private static ICollection<CultureInfo> _availableCultures;

        public static ICollection<CultureInfo> AvailableCultures
        {
            get
            {
                if (_availableCultures != null) return _availableCultures;

                _availableCultures = new List<CultureInfo>
                {
                    new CultureInfo("da"),
                    new CultureInfo("en"),
                    new CultureInfo("de")
                };

                return _availableCultures;
            }
        }
    }
}