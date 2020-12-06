using System.Web;
using System.Web.Mvc;

namespace Dizajn_i_Arhitektura_na_Softver
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
