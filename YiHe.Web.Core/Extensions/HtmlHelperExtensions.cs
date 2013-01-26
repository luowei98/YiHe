using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace YiHe.Web.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        private static readonly string[] IDS = new[] {"id", "cid", "tid"};

        public static string ControllerName(this HtmlHelper helper)
        {
            return helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
        }

        public static string ActionName(this HtmlHelper helper)
        {
            return helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
        }

        public static string RouteId(this HtmlHelper helper)
        {
            IValueProvider provider = helper.ViewContext.Controller.ValueProvider;

            foreach (ValueProviderResult id in IDS.Select(provider.GetValue).Where(id => id != null))
            {
                return id.RawValue.ToString();
            }

            return "";
        }

        public static string ActivePage(this HtmlHelper helper, string controller, string action)
        {
            return controller == helper.ControllerName() && action == helper.ActionName() ? "selected" : "";
        }

        public static IHtmlString SplitText(this HtmlHelper helper, string text, string spliter = "p")
        {
            string[] textarr = text.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            string contacter = string.Format("</{0}><{0}>", spliter);
            string s = string.Format("<{0} class='first-line'>{1}</{0}>", spliter, string.Join(contacter, textarr));
            return helper.Raw(s);
        }
    }
}