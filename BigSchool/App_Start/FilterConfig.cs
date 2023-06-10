using System.Web;
using System.Web.Mvc;

namespace _2011770131_Trần_Hân_Nhi_BigSchool
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
