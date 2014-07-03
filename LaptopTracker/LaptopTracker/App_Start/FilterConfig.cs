using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;


namespace LaptopTracker
{
    /// <summary>
    /// Registers global filters.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters != null)
            {
                filters.Add(new HandleErrorAttribute()); 
            }
        }
    }
}
