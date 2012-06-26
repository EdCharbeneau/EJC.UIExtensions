using System.Collections.Generic;
using System.Web.Routing;

namespace EJC.Helpers
{
    public static class CommonExtensions
    {
        public static RouteValueDictionary ToRouteValueDictionary(this IDictionary<string, object> dictionary)
        {
            return dictionary == null ? new RouteValueDictionary() : new RouteValueDictionary(dictionary);
        }
    }
}