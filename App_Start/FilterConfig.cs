﻿using System.Web;
using System.Web.Mvc;

namespace Etkinlik_Takip_Sistemi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
