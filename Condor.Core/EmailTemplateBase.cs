using System.Web.Mvc;

using RazorTemplates.Core;

namespace Condor.Core
{
    public abstract class EmailTemplateBase : TemplateBase
    {
        private HtmlHelper htmlHelper;  

        public HtmlHelper Html
        {
            get
            {
                if (htmlHelper == null)
                    htmlHelper = new HtmlHelper(null, null);

                return htmlHelper;
            }
        }
    }
}