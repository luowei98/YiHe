using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace YiHe.Web.Core.ActionFilters
{
    public class AntiForgeryTokenFilterProvider : IFilterProvider
    {
        #region IFilterProvider Members

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var result = new List<Filter>();

            string incomingVerb = controllerContext.HttpContext.Request.HttpMethod;

            if (String.Equals(incomingVerb, "POST", StringComparison.OrdinalIgnoreCase))
            {
                result.Add(new Filter(new ValidateAntiForgeryTokenAttribute(), FilterScope.Global, null));
            }

            return result;
        }

        #endregion
    }
}