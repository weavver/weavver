using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

public class HTMLPurifierLib
{
     public static string Sanitize(string unsafeHTML)
     {
          var sanitizer = new Html.HtmlSanitizer();
          // sanitizer.AllowedTags = new[] { "a", "p", "br", "img" };
          var sanitized = sanitizer.Sanitize(unsafeHTML, HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
          return sanitized;
     }
}