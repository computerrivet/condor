using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Condor.Core.Templates.Helpers
{
    public static class Html
    {
        public static IHtmlString Raw(string value)
        {
            return (IHtmlString)new HtmlString(value);
        }

        public static IHtmlString Raw(object value)
        {
            return (IHtmlString)new HtmlString(value == null ? (string)null : value.ToString());
        }
    }
}