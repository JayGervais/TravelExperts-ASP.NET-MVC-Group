using System.Web;
using System.Web.Mvc;

namespace TravelExperts_CPRG214_Final_JayGervais
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
