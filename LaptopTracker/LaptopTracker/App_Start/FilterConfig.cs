﻿using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;


namespace LaptopTracker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters != null)
            {
                filters.Add(new HandleErrorAttribute()); 
            }
        }
    }
}
