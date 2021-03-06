﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Data.Entity;
using Bug2Bug.Models;
using Bug2Bug.Logic;

namespace Bug2Bug
{
   public class Global : HttpApplication
   {
      void Application_Start(object sender, EventArgs e)
      {
         // Code that runs on application startup
         BundleConfig.RegisterBundles(BundleTable.Bundles);
         AuthConfig.RegisterOpenAuth();
         RouteConfig.RegisterRoutes(RouteTable.Routes);
         Database.SetInitializer(new ProductDatabaseInitializer());
      }

      void Application_End(object sender, EventArgs e)
      {
         //  Code that runs on application shutdown

      }

      void Application_Error(object sender, EventArgs e)
      {
         // Code that runs when an unhandled error occurs

      }
   }
}
