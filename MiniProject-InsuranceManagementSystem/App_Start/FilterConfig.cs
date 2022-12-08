using System.Web;
using System.Web.Mvc;

namespace MiniProject_InsuranceManagementSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
