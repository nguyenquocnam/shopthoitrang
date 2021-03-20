using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopthucung.Areas.admin.code
{
    public class HtmltoW
    {
        public static string decodeC(string text)
        {
            var s = text.Replace("&", "&amp;");
            s = s.Replace("<", "&lt;");
            s = s.Replace(">", "&gt;");
            s = s.Replace("\"", "&quot;");
            s = s.Replace("\'", "&#039;");
            return s;
        }
        public static string replaceC(string text)
        {
            var s = text.Replace("&amp;", "&");
            s = s.Replace("&lt;", "<");
            s = s.Replace("&gt;", ">");
            s = s.Replace("&quot;", "\"");
            s = s.Replace("&#039;", "\'");
            return s;
        }
    }
}