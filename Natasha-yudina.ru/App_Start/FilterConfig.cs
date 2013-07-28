using System.Web;
using System.Web.Mvc;

namespace Natasha_yudina.ru
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}