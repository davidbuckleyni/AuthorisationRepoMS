using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MISSystem.Web.Helpers {
    public static class HelperMethods {

        public static string ConvertTo_ProperCase(string text) {
            TextInfo myTI = new CultureInfo("en-GB", false).TextInfo;
            return myTI.ToTitleCase(text.ToLower());
        }
    }
    
}
