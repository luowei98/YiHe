using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;


namespace YiHe.Web.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ControllerName(this HtmlHelper helper)
        {
            return helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
        }

        public static string ActionName(this HtmlHelper helper)
        {
            return helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
        }

        public static string ActivePage(this HtmlHelper helper, string controller, string action)
        {
            return controller == helper.ControllerName() && action == helper.ActionName() ? "selected" : "";
        }

        public static IHtmlString SplitText(this HtmlHelper helper, string text)
        {
            var textarr = text.Split(new [] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            return helper.Raw("<p>" + string.Join("</p><p>", textarr) + "</p>");
        }
    }
}
