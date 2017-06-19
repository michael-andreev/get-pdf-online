using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Localization
{
    public static class LocalizationHelper
    {
        public static CultureInfo ExtractCultureFromPath(PathString path)
        {
            //Quick and dirty parsing of language from url path, which looks like /locale/controller
            var parts = path.Value
                         .Split('/')
                         .Where(p => !String.IsNullOrWhiteSpace(p)).ToList();

            if (parts.Count > 0)
            {
                var cultureSegmentIndex = 0;
                var hasCulture = Regex.IsMatch(
                          parts[cultureSegmentIndex],
                          @"^[a-z]{2}(?:-[A-Z]{2})?$");

                if (hasCulture)
                {
                    return new CultureInfo(parts[cultureSegmentIndex]);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
