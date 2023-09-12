using System.Web;
using System.Web.Mvc;

namespace ATMEntryPoint
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()); // we'll talk about this later
            //filters.Add(new MyLoggingFilterAttribute());
        }
    }
}
