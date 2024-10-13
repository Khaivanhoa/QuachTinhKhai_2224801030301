using System.Web;
using System.Web.Mvc;

namespace QuachTinhKhai_2224801030301
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
