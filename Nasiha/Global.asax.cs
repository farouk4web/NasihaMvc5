using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nasiha
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var defaultLanguge = ConfigurationManager.AppSettings["DefaultLanguge"].ToString();
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];

            if (cookie != null && cookie.Value != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
            }

            // on th last version I set default language from web.config
            // now get it form his location 
            //  Ex : 
            // from Egypt ====> Ar
            // from Australia ====> en

            else
            {
               Thread.CurrentThread.CurrentCulture = new CultureInfo("En-AU");
               Thread.CurrentThread.CurrentUICulture = new CultureInfo(defaultLanguge);
            }
        }


    }
}
