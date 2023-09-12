using System.Web;
using System.Web.Mvc;

namespace ExploreCaliDbF {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
